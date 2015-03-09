namespace VersionOne.SDK.APIClient.Queries
{
	public class Paging
	{
		private int _pagesize;
		public int PageSize { get { return _pagesize;} set { _pagesize = value;}}
		
		private int _start;
		public int Start { get { return _start;} set { _start = value;}}

		public Paging() : this(0,int.MaxValue) { }

		public Paging(int start, int pagesize)
		{
			_start = start;
			_pagesize = pagesize;
		}
		
		public string Token { get { return string.Format("{0},{1}", PageSize, Start); } }
		
		public override string ToString()
		{
			return Token;
		}
	}
}