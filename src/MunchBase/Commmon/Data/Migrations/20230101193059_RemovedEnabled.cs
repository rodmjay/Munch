using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class RemovedEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "ModelProvider");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "ModelProvider",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ModelProvider",
                keyColumns: new[] { "ModelId", "ProviderId" },
                keyValues: new object[] { 1, 1 },
                column: "Enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "ModelProvider",
                keyColumns: new[] { "ModelId", "ProviderId" },
                keyValues: new object[] { 2, 2 },
                column: "Enabled",
                value: true);
        }
    }
}
