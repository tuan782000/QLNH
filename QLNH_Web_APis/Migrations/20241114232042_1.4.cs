using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNH_Web_APis.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<DateTime>(
            //     name: "Created",
            //     table: "Users",
            //     type: "datetime(6)",
            //     nullable: false,
            //     defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // migrationBuilder.AddColumn<int>(
            //     name: "CreatedUserId",
            //     table: "Users",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddColumn<bool>(
            //     name: "Deleted",
            //     table: "Users",
            //     type: "tinyint(1)",
            //     nullable: false,
            //     defaultValue: false);

            // migrationBuilder.AddColumn<bool>(
            //     name: "OffDuty",
            //     table: "Users",
            //     type: "tinyint(1)",
            //     nullable: false,
            //     defaultValue: false);

            // migrationBuilder.AddColumn<int>(
            //     name: "RoleId",
            //     table: "Users",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddColumn<DateTime>(
            //     name: "Updated",
            //     table: "Users",
            //     type: "datetime(6)",
            //     nullable: false,
            //     defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // migrationBuilder.AddColumn<int>(
            //     name: "UpdatedUserId",
            //     table: "Users",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Users_RoleId",
            //     table: "Users",
            //     column: "RoleId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Users_Roles_RoleId",
            //     table: "Users",
            //     column: "RoleId",
            //     principalTable: "Roles",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Users_Roles_RoleId",
            //     table: "Users");

            // migrationBuilder.DropIndex(
            //     name: "IX_Users_RoleId",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "Created",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "CreatedUserId",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "Deleted",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "OffDuty",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "RoleId",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "Updated",
            //     table: "Users");

            // migrationBuilder.DropColumn(
            //     name: "UpdatedUserId",
            //     table: "Users");
        }
    }
}
