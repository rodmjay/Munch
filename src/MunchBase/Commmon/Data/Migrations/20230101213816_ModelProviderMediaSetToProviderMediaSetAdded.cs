using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class ModelProviderMediaSetToProviderMediaSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ModelProviderMediaSet_ProviderId_MediaSetId",
                table: "ModelProviderMediaSet",
                columns: new[] { "ProviderId", "MediaSetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ModelProviderMediaSet_MediaSetProvider_ProviderId_MediaSetId",
                table: "ModelProviderMediaSet",
                columns: new[] { "ProviderId", "MediaSetId" },
                principalTable: "MediaSetProvider",
                principalColumns: new[] { "ProviderId", "MediaSetId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelProviderMediaSet_MediaSetProvider_ProviderId_MediaSetId",
                table: "ModelProviderMediaSet");

            migrationBuilder.DropIndex(
                name: "IX_ModelProviderMediaSet_ProviderId_MediaSetId",
                table: "ModelProviderMediaSet");
        }
    }
}
