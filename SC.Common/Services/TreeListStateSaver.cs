﻿using DevExpress.Utils.Extensions;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using SC.Common.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SC.Common.Services
{
	public interface IViewModel
	{
		string ViewModelID { get; }
	}
	public sealed class TreeListStateSaver : IDisposable
	{
		private readonly TreeList _treeList;
		private List<string> _expandedIds = new List<string>();
		private string _selectedId;
		private string _selectedColumnName;
		private int _topVisibleNodeIndex;
		private object _tag;

		public TreeListStateSaver(TreeList treeList)
		{
			_treeList = treeList;
			_treeList.Nodes.ForEach(GetExpanded);
			_selectedId = (_treeList.GetRow(_treeList.FocusedNode?.Id ?? -1) as IViewModel)?.ViewModelID;
			_selectedColumnName = _treeList.FocusedColumn?.Name;
			_topVisibleNodeIndex = _treeList.TopVisibleNodeIndex;
			_tag = _treeList.Tag;
			_treeList.Tag = Updating;
		}
		public static object Updating { get; } = new object();

		private void GetExpanded(TreeListNode node)
		{
			if (node.Expanded && _treeList.GetRow(node.Id) is IViewModel vm)
			{
				_expandedIds.Add(vm.ViewModelID);
			}
			node.Nodes?.ForEach(GetExpanded);
		}
		private void SetState(TreeListNode node)
		{
			if (!(_treeList.GetRow(node.Id) is IViewModel vm)) return;
			if (_expandedIds?.Any(id => vm.ViewModelID == id) ?? false) node.Expanded = true;
			if (vm.ViewModelID == _selectedId && _selectedId.NoEmpty())
			{
				_treeList.SetFocusedNode(node);
			}
			node.Nodes?.ForEach(SetState);
		}

		public void SaveLayoutToXml(string xmlFile)
		{
			new XmlRepository<Data>(xmlFile).Save(new Data
			{
				ExpandedIds = _expandedIds,
				SelectedColumnName = _selectedColumnName,
				SelectedId = _selectedId,
				TopVisibleNodeIndex = _topVisibleNodeIndex,
			});
		}
		public void RestoreLayoutFromXml(string xmlFile)
		{
			var data = new XmlRepository<Data>(xmlFile).Load();
			_expandedIds = data.ExpandedIds;
			_selectedColumnName = data.SelectedColumnName;
			_selectedId = data.SelectedId;
			_topVisibleNodeIndex = data.TopVisibleNodeIndex;
		}

		public void Dispose()
		{
			try
			{
				_treeList.BeginInit();

				_treeList.Nodes.ForEach(SetState);
				_treeList.TopVisibleNodeIndex = _topVisibleNodeIndex;
				_treeList.Tag = _tag;

				_treeList.EndInit();

				var focusedColumn = _treeList.Columns
					.FirstOrDefault(c => c.Name == _selectedColumnName);
				if (focusedColumn != null) _treeList.FocusedColumn = focusedColumn;
			}
			catch { }
		}

		[DataContract]
		[Serializable]
		public class Data
		{
			[DataMember]
			public List<string> ExpandedIds { get; set; }
			[DataMember]
			public string SelectedId { get; set; }
			[DataMember]
			public string SelectedColumnName { get; set; }
			[DataMember]
			public int TopVisibleNodeIndex { get; set; }
		}
	}
}