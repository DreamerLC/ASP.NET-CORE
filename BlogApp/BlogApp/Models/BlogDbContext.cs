using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    // Install-Package Microsoft.EntityframeworkCore
    public class BlogDbContext : DbContext
    {
        private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

        //Install-Package IdentityServer4.EntityFramework.Storage
        public BlogDbContext(DbContextOptions<BlogDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options)
        {
            _operationalStoreOptions = operationalStoreOptions;
        }

        public DbSet<Blog> Blogs { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Title = "Sports article 1", Category = "Sport", Author = "James", DatePosted = new DateTime(2019, 10, 1) },
                new Blog { Id = 2, Title = "Food article 1", Category = "Food", Author = "Mary", DatePosted = new DateTime(2019, 10, 1) },
                new Blog { Id = 3, Title = "Coding article 1", Category = "Coding", Author = "Lu", DatePosted = new DateTime(2019, 10, 1) },
                new Blog { Id = 4, Title = "Wheather article 1", Category = "Weather", Author = "Frank", DatePosted = new DateTime(2019, 10, 1) },
                new Blog { Id = 5, Title = "Sports article 2", Category = "Sport", Author = "James", DatePosted = new DateTime(2019, 10, 2) },
                new Blog { Id = 6, Title = "Food article 2", Category = "Food", Author = "Mary", DatePosted = new DateTime(2019, 10, 2) },
                new Blog { Id = 7, Title = "Coding article 2", Category = "Coding", Author = "Lu", DatePosted = new DateTime(2019, 10, 2) },
                new Blog { Id = 8, Title = "Wheather article 2", Category = "Weather", Author = "Frank", DatePosted = new DateTime(2019, 10, 2) },
                new Blog { Id = 9, Title = "Sports article 3", Category = "Sport", Author = "James", DatePosted = new DateTime(2019, 10, 3) },
                new Blog { Id = 10, Title = "Food article 3", Category = "Food", Author = "Mary", DatePosted = new DateTime(2019, 10, 3) },
                new Blog { Id = 11, Title = "Coding article 3", Category = "Coding", Author = "Lu", DatePosted = new DateTime(2019, 10, 3) },
                new Blog { Id = 12, Title = "Wheather article 3", Category = "Weather", Author = "Frank", DatePosted = new DateTime(2019, 10, 3) },
                new Blog { Id = 13, Title = "Sports article 3", Category = "Sport", Author = "Frank", DatePosted = new DateTime(2019, 10, 4) }
                );
        }
        */
    }
}
