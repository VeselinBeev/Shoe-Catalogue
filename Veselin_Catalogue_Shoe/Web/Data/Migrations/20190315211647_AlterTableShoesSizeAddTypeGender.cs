using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web.Data.Migrations
{
    public partial class AlterTableShoesSizeAddTypeGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ShoeSize",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ShoeSize",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ShoeSize");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ShoeSize");
        }
    }
}
