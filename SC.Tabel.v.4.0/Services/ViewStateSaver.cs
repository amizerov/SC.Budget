using DevExpress.Utils.Extensions;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using SwissClean.MVP;

namespace SwissClean.Services
{
	public class TreeListStateSaver : IDisposable
	{
		private readonly TreeList _control;
		private readonly List<(string Id, bool Expanded)> _states;
		private readonly int _selectionId;

		public TreeListStateSaver(TreeList control)
		{
			_control = control;
			_selectionId = control.Selection.FirstOrDefault()?.Id ?? -1;

			_states = new List<(string Id, bool Expanded)>();
			_control.Nodes.ForEach(AddNode);
		}

		private void AddNode(TreeListNode from)
		{
			if (_control.GetRow(from.Id) is IViewModel vm)
			{
				_states.Add((vm.ID, from.Expanded));
			}
			from.Nodes?.ForEach(AddNode);
		}


		public void Dispose()
		{
			_control.Nodes.ForEach(SetNode);
		}

		private void SetNode(TreeListNode to)
		{
			if (_control.GetRow(to.Id) is IViewModel vm)
			{
				to.Expanded = _states.FirstOrDefault(s => s.Id == vm.ID).Expanded;
			}

			if(to.Id == _selectionId) _control.SelectNode(to);

			to.Nodes?.ForEach(SetNode);
		}
	}
}
