using System;
using System.Collections.Generic;

namespace nexTwitter.Infrastructure
{
	public class PagedResult<T>
	{
		public PagedResult()
		{
			Result = new List<T>();
		}
		public int Page { get; set; }
		public int PageSize { get; set; }
		public long TotalCount { get; set; }

		public IList<T> Result { get; set; }
	}
}
