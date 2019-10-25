using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public static class PageExtension
    {
        public static async Task<PagedResult<T>> GetPagedResultAsync<T>(this IQueryable<T> query, BlogCriteria blogCriteria) where T : class
        {
            PagedResult<T> result = new PagedResult<T>();
            if (blogCriteria.CurrentPage<=0 || blogCriteria.PageSize<=0)
            {
                result.Results = await query.AsNoTracking().ToListAsync();
                return result;
            }
            result.CurrentPage = blogCriteria.CurrentPage;
            result.PageSize = blogCriteria.PageSize;
            result.RowCount = await query.CountAsync();

            var pageCount = (double)result.RowCount / result.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (result.CurrentPage - 1) * result.PageSize;
            result.Results = await query.Skip(skip).Take(result.PageSize).ToListAsync();
            return result;
        }
    }
}
