﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNH_Web_APis.Migrations
{
    /// <inheritdoc />
    public partial class _15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<string>(
            //     name: "Description",
            //     table: "Users",
            //     type: "longtext",
            //     nullable: false)
            //     .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
            //     name: "Description",
            //     table: "Users");
        }
    }
}
