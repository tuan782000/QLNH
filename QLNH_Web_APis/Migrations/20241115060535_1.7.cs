using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNH_Web_APis.Migrations
{
    /// <inheritdoc />
    public partial class _17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CreatedUserId",
                table: "Statuses",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_RestaurantId",
                table: "Statuses",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_UpdatedUserId",
                table: "Statuses",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Restaurants_RestaurantId",
                table: "Statuses",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Users_CreatedUserId",
                table: "Statuses",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Users_UpdatedUserId",
                table: "Statuses",
                column: "UpdatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Restaurants_RestaurantId",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Users_CreatedUserId",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Users_UpdatedUserId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_CreatedUserId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_RestaurantId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_UpdatedUserId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Statuses");
        }
    }
}
