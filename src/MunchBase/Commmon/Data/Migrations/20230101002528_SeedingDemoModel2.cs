using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class SeedingDemoModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "NormalizedEmail" },
                values: new object[] { "mia@maklova.com", "MIA@MALKOVA.COM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "NormalizedEmail" },
                values: new object[] { "mia", "MIA" });
        }
    }
}
