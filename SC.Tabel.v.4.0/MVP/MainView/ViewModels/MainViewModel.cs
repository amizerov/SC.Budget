using SC.Common.Model;
using System;
using System.Collections.Generic;

namespace SwissClean.MVP.MainView.ViewModels
{
	public class MainViewModel
	{
		public decimal Rest { get; set; }
		public CRequestOpDto LastRequestOp { get; set; }
		public DateTime Month { get; set; }
		public List<ResOPViewModel> ResOps { get; set; }
		public SelectionResOpViewModel SelectionResOp { get; set; }
	}
}
