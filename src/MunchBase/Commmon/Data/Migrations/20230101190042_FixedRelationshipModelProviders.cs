using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Commmon.Data.Migrations
{
    public partial class FixedRelationshipModelProviders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelProvider_Model_ProviderId",
                table: "ModelProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelProvider_Provider_ModelId",
                table: "ModelProvider");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelProvider_Model_ModelId",
                table: "ModelProvider",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelProvider_Provider_ProviderId",
                table: "ModelProvider",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelProvider_Model_ModelId",
                table: "ModelProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelProvider_Provider_ProviderId",
                table: "ModelProvider");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelProvider_Model_ProviderId",
                table: "ModelProvider",
                column: "ProviderId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelProvider_Provider_ModelId",
                table: "ModelProvider",
                column: "ModelId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
