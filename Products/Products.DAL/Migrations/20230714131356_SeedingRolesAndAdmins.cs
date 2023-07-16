using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRolesAndAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Admin = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()

            };

            var User = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "User".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()

            };


            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

               values: new object[] { Admin.Id, Admin.Name, Admin.NormalizedName, Admin.ConcurrencyStamp }
               );

            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

            values: new object[] { User.Id, User.Name, User.NormalizedName, User.ConcurrencyStamp }
            );


            var passwordHasher = new PasswordHasher<IdentityUser>();

            var Admin1 = new IdentityUser
            {
                UserName = "Admin1",
                Email = "Admin1@gmail.com",
                NormalizedUserName = "ADMIN1",
                NormalizedEmail = "ADMIN1@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            Admin1.PasswordHash = passwordHasher.HashPassword(Admin1, "#Admin123");


            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
                values: new object[] { Admin1.Id, Admin1.UserName, Admin1.NormalizedUserName, Admin1.Email, Admin1.NormalizedEmail, Admin1.EmailConfirmed, Admin1.PasswordHash, Admin1.SecurityStamp, Guid.NewGuid().ToString(), Admin1.PhoneNumberConfirmed, Admin1.TwoFactorEnabled, null, Admin1.LockoutEnabled, Admin1.AccessFailedCount }
            );
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { Admin1.Id, Admin.Id }
            );

            var Admin2 = new IdentityUser
            {
                UserName = "Admin2",
                Email = "Admin2@gmail.com",
                NormalizedUserName = "ADMIN2",
                NormalizedEmail = "ADMIN2@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            Admin2.PasswordHash = passwordHasher.HashPassword(Admin2, "#Admin123");


            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
                values: new object[] { Admin2.Id, Admin2.UserName, Admin2.NormalizedUserName, Admin2.Email, Admin2.NormalizedEmail, Admin2.EmailConfirmed, Admin2.PasswordHash, Admin2.SecurityStamp, Guid.NewGuid().ToString(), Admin2.PhoneNumberConfirmed, Admin2.TwoFactorEnabled, null, Admin2.LockoutEnabled, Admin2.AccessFailedCount }
            );
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { Admin2.Id, Admin.Id }
            );



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");
            migrationBuilder.Sql("DELETE FROM AspNetUsers");
            migrationBuilder.Sql("DELETE FROM AspNetUserRoles");
        }
    }
}
