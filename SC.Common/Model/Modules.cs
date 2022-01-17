using System;
using System.Collections.Generic;

namespace SC.Common.Model
{
	[Flags]
	public enum Modules
	{
		None = 0 << 0,
		Proda = 1 << 0,
		Zakup = 1 << 1,
		Tabel = 1 << 2,
		Objects = 1 << 3,
		Cash = 1 << 4,
	}
	public class AccessModules
	{
		private readonly Dictionary<Role, Modules> _modules = new Dictionary<Role, Modules>
		{
			[Role.None] = Modules.None,
			[Role.Admin] = Modules.Proda | Modules.Zakup | Modules.Tabel | Modules.Objects | Modules.Cash,
			[Role.Director] = Modules.Proda | Modules.Zakup | Modules.Tabel | Modules.Objects | Modules.Cash,
			[Role.Buh] = Modules.Proda | Modules.Zakup,
			[Role.ManagerZakup] = Modules.Zakup,
			[Role.Kladovshchik] = Modules.Zakup,
			[Role.Rukovod] = Modules.Objects | Modules.Proda | Modules.Zakup | Modules.Tabel | Modules.Cash,
			[Role.Manager] = Modules.Tabel
		};

		private readonly Modules _accessModules;

		public AccessModules(CUser user)
		{
			_accessModules = _modules[user?.Role ?? Role.None];
		}

		public static implicit operator Modules(AccessModules other) => other._accessModules;
	}
}
