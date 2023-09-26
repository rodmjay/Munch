using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Common.Data.Migrations
{
    public partial class ChannelProviderIdentifierAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "ChannelProvider",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "ChannelProvider");
        }
    }
}
