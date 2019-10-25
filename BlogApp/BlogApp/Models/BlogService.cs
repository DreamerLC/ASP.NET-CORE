using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class BlogService : IBlogRepository
    {
        //not use static here, all one instance will be reponse all requests
        private readonly BlogDbContext _context;
        public BlogService(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            var removedBlog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            _context.Blogs.Remove(removedBlog);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<Blog> GetBlogAsync(int id)
        {
            var blog = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return blog;
        }

        public async Task<PagedResult<Blog>> GetPagedAsync(BlogCriteria blogCriteria)
        {
            var query =  _context.Blogs.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(blogCriteria.Search))
            {
                query = query.Where(x => x.Title.Contains(blogCriteria.Search) || x.Category.Contains(blogCriteria.Search)||x.Author.Contains(blogCriteria.Search));
            }
            var result = await query.GetPagedResultAsync(blogCriteria);
            return result;
        }

        public async Task<Blog> UpdateBLogAsync(int id, Blog changedBlog)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            blog.Title = changedBlog.Title;
            blog.Category = changedBlog.Category;
            blog.Author = changedBlog.Author;
            blog.DatePosted = DateTime.Now;
            await _context.SaveChangesAsync();
            return blog;

        }
    }
}
