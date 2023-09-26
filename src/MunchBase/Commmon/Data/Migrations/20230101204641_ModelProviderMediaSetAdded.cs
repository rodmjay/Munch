using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class ModelProviderMediaSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelProviderMediaSet",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    MediaSetId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProviderMediaSet", x => new { x.ModelId, x.MediaSetId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ModelProviderMediaSet_ModelMediaSet_MediaSetId_ModelId",
                        columns: x => new { x.MediaSetId, x.ModelId },
                        principalTable: "ModelMediaSet",
                        principalColumns: new[] { "MediaSetId", "ModelId" });
                    table.ForeignKey(
                        name: "FK_ModelProviderMediaSet_ModelProvider_ModelId_ProviderId",
                        columns: x => new { x.ModelId, x.ProviderId },
                        principalTable: "ModelProvider",
                        principalColumns: new[] { "ModelId", "ProviderId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelProviderMediaSet_MediaSetId_ModelId",
                table: "ModelProviderMediaSet",
                columns: new[] { "MediaSetId", "ModelId" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelProviderMediaSet_ModelId_ProviderId",
                table: "ModelProviderMediaSet",
                columns: new[] { "ModelId", "ProviderId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelProviderMediaSet");
        }
    }
}
