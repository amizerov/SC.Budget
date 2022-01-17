using SC.Common.Dal;
using SC.Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace SC.Common.Services
{
	public class WhatUpdateService<T>
	{
		private readonly List<Unit> _unitsBefore = new List<Unit>();
		private List<Unit> _unitsToSave = new List<Unit>();
		private List<Unit> _unitsToCompare;
		private readonly IRepository<List<Unit>> _repos;

		public WhatUpdateService()
		{
			var user = ApplicationUser.User;
			var file = Path.Combine("C:\\SCAS", $"WhatUpdate_{typeof(T).Name}_{user?.RoleName}.xml");

			_repos = new XmlRepository<List<Unit>>(file);
		}

		/// <summary>Добавляем объект до обновления</summary>
		/// <param name="obj">Объект, обновление полей которго нужно отследить</param>
		public void AddBeforeUpdate(T obj)
		{
			if (obj == null) return;
			var id = GetID(obj);
			if (id == 0) return;
			var props = obj.GetType().GetProperties();
			foreach (var p in props)
			{
				_unitsBefore.Add(new Unit(id, p.Name, p.GetValue(obj)));
			}
		}
		/// <summary>Добавляем объект после обновления</summary>
		/// <param name="obj">Объект, обновление полей которго нужно отследить</param>
		public void AddAfterUpdate(T obj)
		{
			if (obj == null) return;
			var id = GetID(obj);
			if (id == 0) return;
			var units = _unitsBefore.Where(u => u.ID == id).ToArray();

			var props = obj.GetType().GetProperties();
			foreach (var p in props)
			{
				var value = p.GetValue(obj);
				var prevUnit = units.FirstOrDefault(u => u.FieldName == p.Name);
				if (prevUnit == null) continue;
				if (prevUnit.Value == null && value == null) continue;
				if (prevUnit.Value != null && prevUnit.Value.Equals(value)) continue;

				_unitsToSave.Add(new Unit(id, p.Name));
			}
		}

		/// <summary>Сохраняем результаты в файл</summary>
		public void SaveFile() => _repos.Save(_unitsToSave);

		/// <summary>Загрузка предыдущих результатов из файла</summary>
		public void LoadPrevFile() => _unitsToSave = _repos.Load();
		///<summary>Проверка обновилось ли поле по ID и имени поля</summary>
		public bool IsUpdated(int id, string fieldName)
		{
			if (_unitsToCompare == null)
			{
				_unitsToCompare = _repos.Load();
			}

			var unit = _unitsToCompare.FirstOrDefault(u => u.ID == id && u.FieldName == fieldName);
			return unit != null;
		}


		private int GetID(T obj)
		{
			try
			{
				var prop = obj.GetType().GetProperty("ID");
				if (prop == null) return 0;

				var id = (int)prop.GetValue(obj);
				return id;
			}
			catch
			{
				return 0;
			}
		}

		[DataContract]
		public class Unit
		{
			public Unit() { }
			public Unit(int id, string fieldName)
			{
				ID = id;
				FieldName = fieldName;
			}
			public Unit(int id, string fieldName, object value)
			{
				ID = id;
				FieldName = fieldName;
				Value = value;
			}

			[DataMember] public int ID { get; set; }
			[DataMember] public string FieldName { get; set; }
			public object Value { get; }
		}
	}
}
