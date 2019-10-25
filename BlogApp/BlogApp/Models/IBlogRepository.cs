using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public interface IBlogRepository
    {
        Task<PagedResult<Blog>> GetPagedAsync(BlogCriteria blogCriteria);
        Task<Blog> GetBlogAsync(int id);
        Task<int> DeleteBlogAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> UpdateBLogAsync(int id, Blog changedBlog);
             
    }
}
