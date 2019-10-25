using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public interface IPageCriteria
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
