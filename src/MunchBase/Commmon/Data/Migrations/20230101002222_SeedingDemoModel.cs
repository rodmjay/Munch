using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class SeedingDemoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "Code3", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "Iso2", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "eng", "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "Mia Malkova", "mia", true, "Mia", "US", "Malkova", false, null, "MIA", "MIA@MALKOVA.COM", "AQAAAAEAACcQAAAAEIVVeEi6VZ2YB3JUwyExMUFOL9E6rS4Px8AHXK0osa6ncEsGkS0mFtBesBmGurNFuA==", "123-123-1234", false, "", false, "mia@malkova.com" });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Demo Model" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
