using BlogApp.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogUnitTestProject
{
    public class BlogDbContextFixture : IDisposable

    {
        //Install-Package Microsoft.EntityFrameworkCore.Sqlite
        private readonly SqliteConnection _connection;
        private readonly DbContextOptions<BlogDbContext> _contextOptions;
        private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

        public BlogDbContextFixture()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<BlogDbContext>().UseSqlite(_connection).Options;
            _operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            using var db = this.GetConnection();
            db.Database.EnsureCreated();
        }

        public BlogDbContext GetConnection()
        {
            return new BlogDbContext(_contextOptions, _operationalStoreOptions);
        }
        public void Dispose()
        {
            _connection.Close();
        }
    }
}
