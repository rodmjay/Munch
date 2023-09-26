using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class SeedChannelProvidersAndProducers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChannelProducer",
                columns: new[] { "ChannelId", "ProducerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ChannelProvider",
                columns: new[] { "ChannelId", "ProviderId", "Identifier" },
                values: new object[] { 1, 1, "testnamehere" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChannelProducer",
                keyColumns: new[] { "ChannelId", "ProducerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ChannelProvider",
                keyColumns: new[] { "ChannelId", "ProviderId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
