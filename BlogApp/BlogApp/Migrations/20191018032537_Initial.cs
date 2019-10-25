using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    DatePosted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Author", "Category", "DatePosted", "Title" },
                values: new object[,]
                {
                    { 1, "James", "Sport", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports article 1" },
                    { 2, "Mary", "Food", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food article 1" },
                    { 3, "Lu", "Coding", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coding article 1" },
                    { 4, "Frank", "Weather", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheather article 1" },
                    { 5, "James", "Sport", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports article 2" },
                    { 6, "Mary", "Food", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food article 2" },
                    { 7, "Lu", "Coding", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coding article 2" },
                    { 8, "Frank", "Weather", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheather article 2" },
                    { 9, "James", "Sport", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports article 3" },
                    { 10, "Mary", "Food", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food article 3" },
                    { 11, "Lu", "Coding", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coding article 3" },
                    { 12, "Frank", "Weather", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheather article 3" },
                    { 13, "Frank", "Sport", new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports article 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
