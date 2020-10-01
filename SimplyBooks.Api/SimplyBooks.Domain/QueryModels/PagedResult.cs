using System.Collections.Generic;

namespace SimplyBooks.Domain.QueryModels
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Items = new List<T>();
        }

        public int Total { get; set; }
        public int PageIndex { get; set; }
        public IList<T> Items { get; set; }
    }
}
