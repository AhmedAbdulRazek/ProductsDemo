using Microsoft.EntityFrameworkCore.Migrations;
using Products.DAL.Entities;

#nullable disable

namespace Products.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Mobile = new Category()
            {
                Name = "Mobile"
            };

            var TV = new Category()
            {
                Name = "TV"
            };

            var Car = new Category()
            {
                Name = "Car"
            };

            var Laptop = new Category()
            {
                Name = "Laptop"
            };


            migrationBuilder.InsertData(
               table: "Categories",
               columns: new[] { "Name" },

               values: new object[] { Mobile.Name}
               );

            migrationBuilder.InsertData(
               table: "Categories",
               columns: new[] { "Name" },

               values: new object[] { TV.Name }
               );


            migrationBuilder.InsertData(
               table: "Categories",
               columns: new[] { "Name" },

               values: new object[] { Car.Name }
               );

            migrationBuilder.InsertData(
               table: "Categories",
               columns: new[] { "Name" },

               values: new object[] { Laptop.Name }
               );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
