using SC.Common.Model;
using System;
using System.Collections.Generic;

namespace SwissClean.MVP.MainView
{
	public class RejectOperationEventArgs : EventArgs
	{
		public IResOpByCashUnit ResOpByCashUnit { get; set; }
		public ResOPViewModel ViewModel { get; set; }
		public COperationDto Operation { get; set; }
	}

	public class PayEventArgs : EventArgs
	{
		public ResOPViewModel ResOpViewModel { get; set; }
		public List<ResOPViewModel> Resources { get; set; }
	}
	public class ResOpEventArgs : EventArgs
	{
		public ResOPViewModel ViewModel { get; set; }
		public string FieldNameChanged { get; set; }
	}
}
