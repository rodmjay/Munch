using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class SeedingModelProviders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModelProvider",
                columns: new[] { "ModelId", "ProviderId", "Enabled", "Username" },
                values: new object[] { 1, 1, true, null });

            migrationBuilder.InsertData(
                table: "ModelProvider",
                columns: new[] { "ModelId", "ProviderId", "Enabled", "Username" },
                values: new object[] { 2, 2, true, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModelProvider",
                keyColumns: new[] { "ModelId", "ProviderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModelProvider",
                keyColumns: new[] { "ModelId", "ProviderId" },
                keyValues: new object[] { 2, 2 });
        }
    }
}
