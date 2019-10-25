using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public abstract class PagedResultBase : IPageCriteria
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }
        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
