using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Common.Data.Migrations
{
    public partial class ChannelProducersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChannelProducer",
                columns: table => new
                {
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelProducer", x => new { x.ProducerId, x.ChannelId });
                    table.ForeignKey(
                        name: "FK_ChannelProducer_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChannelProducer_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelProducer_ChannelId",
                table: "ChannelProducer",
                column: "ChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelProducer");
        }
    }
}
