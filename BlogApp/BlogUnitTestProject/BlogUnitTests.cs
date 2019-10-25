using BlogApp;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlogUnitTestProject
{
    public class BlogUnitTests : IClassFixture<BlogDbContextFixture>
    {
        private readonly BlogDbContextFixture _fixture;
        public BlogUnitTests(BlogDbContextFixture fixture)
        {
            _fixture = fixture;
        }

        
        [Fact]
        public async Task CreateBlogAsync_returns_data()
        {
            //Arrange
            using var db = _fixture.GetConnection();
            var expected = new Blog
            {
                Title = "test title",
                Category = "test category",
                Author = "test author",
                DatePosted = DateTime.Now,
            };
            IBlogRepository service = new BlogService(db);

            //Act
            Blog result = await service.CreateBlogAsync(expected);

            await db.SaveChangesAsync();

            //Arrange
            Assert.Equal(expected.Author, result.Author);
        }

        [Fact]
        public async Task DeleteBlogAsync_returns_data()
        {
            //Arrange
            await SeedAsync();
            using var db = _fixture.GetConnection();
            var entry = db.Blogs.First();
            IBlogRepository service = new BlogService(db);

            //Act
            int result = await service.DeleteBlogAsync(entry.Id);
            await db.SaveChangesAsync();

            bool is_existing = db.Blogs.Any(x => x.Id == entry.Id);

            //Assert
            Assert.False(is_existing);
            Assert.Equal(entry.Id, result);

        }

        [Fact]
        public async Task UpdateBlogAsync()
        {
            //Arrange
            await SeedAsync();
            using var db = _fixture.GetConnection();
            var expected = new Blog
            {
                Title = "test title",
                Category = "test category",
                Author = "test author",
                DatePosted = DateTime.Now,
            };
            var entry = db.Blogs.First();
            IBlogRepository service = new BlogService(db);

            //Act
            Blog result = await service.UpdateBLogAsync(entry.Id, expected);
            await db.SaveChangesAsync();

            //Assert
            Assert.Equal(expected.Title,result.Title);
        }

        [Fact]
        public async Task GetBlogAsync_returns_data()
        {
            //Arrange
            await SeedAsync();
            using var db = _fixture.GetConnection();
            var expected = db.Blogs.First();
            var resulfsat = expected.Author;
            IBlogRepository service = new BlogService(db);

            //Act
            Blog result = await service.GetBlogAsync(expected.Id);

            //Assert
            Assert.Equal(expected.Title,result.Title);
        }

        [Fact]
        public async Task GetPagedResultAsync_returns_data()
        {
            //Arrange
            await SeedAsync();
            using var db = _fixture.GetConnection();
            var blogCriteria = new BlogCriteria { Search = "category", CurrentPage = 2, PageSize = 4};
            var expected = await db.Blogs.Where(x => x.Category.Contains(blogCriteria.Search)).GetPagedResultAsync(blogCriteria);
            var expected_item = expected.Results.First();
            IBlogRepository service = new BlogService(db);

            //Act
            PagedResult<Blog> result = await service.GetPagedAsync(blogCriteria);

            //Assert
            var result_item = result.Results.First();
            Assert.Equal(expected_item.Title, result_item.Title);
        }

        private async Task SeedAsync()
        {
            using var db = _fixture.GetConnection();
            if (!db.Blogs.Any())
            {
                var rows = new List<Blog>
                {
                    new Blog
                    {
                        Title = "title",
                        Category = "Category",
                        Author = "Author",
                        DatePosted = DateTime.Now
                    }
                };

                for (int i = 0; i < 25; i++)
                {
                    rows.Add(new Blog
                    {
                        Title = $"title { i + 1}",
                        Category = $"category {i + 1}",
                        Author = $"author {i + 1}",
                        DatePosted = DateTime.Now
                    });
                }
                db.Blogs.AddRange(rows);
                await db.SaveChangesAsync();
            }
        }
    }
}
