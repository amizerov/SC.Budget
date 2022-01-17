using System.Drawing;

namespace SC.Common.Services
{
	public static class ColorService
	{
		public static Color ToLight(this Color c, int diff)
		{
			int ligth(int from)
			{
				var res = from + diff;
				if (res > 255) return 255;
				if (res < 0) return 0;
				return res;
			}

			return Color.FromArgb(c.A, ligth(c.R), ligth(c.G), ligth(c.B));
		}
		public static Color Mix(this Color c, int a, int r, int g, int b)
		{
			int mix(int x1, int x2)
			{
				var res = (double)(x1 + x2) / 2;
				if (res > 255) return 255;
				if (res < 0) return 0;
				return (int)res;
			}

			return Color.FromArgb(mix(c.A, a), mix(c.R, r), mix(c.G, g), mix(c.B, b));
		}

		public static Color Mix(this Color c, Color color) => Mix(c, color.A, color.R, color.G, color.B);
	}
}
