using SC.Common.Model;

namespace SwissClean.MVP.MainView.ViewModels
{
	public class SelectionResOpViewModel
	{
		public CResOPDto ResOp { get; set; }
		public string[] ResourceNames { get; set; }
		//public string[] PositionNames { get; set; }
		public TabelViewModel[] Tabels { get; set; }
	}
}
