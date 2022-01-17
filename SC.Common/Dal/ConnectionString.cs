﻿using System;
using System.IO;

namespace SC.Common.Dal
{
	public class ConnectionStringRepository : XmlRepository<ConnectionString>
	{
		private static readonly string FileName =
			Path.Combine(Path.GetDirectoryName(
						 Path.GetDirectoryName(
						 Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))),
						 "ConnectionString.xml");
		public ConnectionStringRepository() : base(FileName) { }
	}

	public class ConnectionString
	{
		public string Main { get; set; }
		public string Feedback { get; set; }
		public string Test { get; set; }
		public string History { get; set; }
	}
}
