namespace SC.Common.Model
{
	public class TrelloBoard
	{
		public TrelloCard[] Actions { get; set; }
	}

	public class TrelloCard
	{
		public string Id { get; set; }
		public string List { get; set; }
		public string Card { get; set; }
		public string Desc { get; set; }
	}

	public class TrelloData
	{
		public string Id { get; set; }
		public string List { get; set; }
		public string Card { get; set; }
		public string Desc { get; set; }
	}
}
