using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyBooks.Models.QueryModels
{
    public class PagedCriteria
    {
        public int PageSize { get; set; }
        public int? Page { get; set; }
        public int PageIndex => (Page ?? 1) - 1;
        public int FirstRecord => ((Page ?? 1) - 1) * PageSize;
        public string OrderField { get; set; }
        public OrderDirection OrderDirection { get; set; }
    }

    public enum OrderDirection
    {
        ASC,
        DESC
    }
}
