using SC.Proda.Models;
using System.IO;

namespace SC.Proda.Tools
{
	public class Text
	{
		public static void Load(string file)
		{
			StreamReader sr = new StreamReader(file);
			string line = "";
			while (!sr.EndOfStream)
			{
				line = sr.ReadLine();
				var b = line.Split(';');
				var d = b[0];
				var n = b[1];
				var o = b[2];
				var s = b[3];
				CSchet schet = new CSchet(n);
				CProject p = schet.Project;
				if (p.Name == "Верный")
				{
					CObject obj = new CObject();
					obj.Name = n;
					obj.Address = o;
					p.Objects.Add(obj);
				}
			}
			sr.Close();
		}
	}
}
