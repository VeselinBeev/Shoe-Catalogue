using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web.Data.Migrations
{
    public partial class AddingShoeColorSpecificShoeAndManyOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoe");

            migrationBuilder.CreateTable(
                name: "ShoeColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoeSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Details = table.Column<string>(nullable: true),
                    Number = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificShoe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    ColorId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    ShoeSizeId = table.Column<int>(nullable: true),
                    Stock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificShoe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificShoe_ShoeCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ShoeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SpecificShoe_ShoeColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ShoeColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SpecificShoe_ShoeSize_ShoeSizeId",
                        column: x => x.ShoeSizeId,
                        principalTable: "ShoeSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoeSizeSpecificShoe",
                columns: table => new
                {
                    ShoeSizeId = table.Column<int>(nullable: false),
                    SpecificShoeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSizeSpecificShoe", x => new { x.ShoeSizeId, x.SpecificShoeId });
                    table.ForeignKey(
                        name: "FK_ShoeSizeSpecificShoe_ShoeSize_ShoeSizeId",
                        column: x => x.ShoeSizeId,
                        principalTable: "ShoeSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeSizeSpecificShoe_SpecificShoe_SpecificShoeId",
                        column: x => x.SpecificShoeId,
                        principalTable: "SpecificShoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizeSpecificShoe_SpecificShoeId",
                table: "ShoeSizeSpecificShoe",
                column: "SpecificShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificShoe_CategoryId",
                table: "SpecificShoe",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificShoe_ColorId",
                table: "SpecificShoe",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificShoe_ShoeSizeId",
                table: "SpecificShoe",
                column: "ShoeSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeSizeSpecificShoe");

            migrationBuilder.DropTable(
                name: "SpecificShoe");

            migrationBuilder.DropTable(
                name: "ShoeColor");

            migrationBuilder.DropTable(
                name: "ShoeSize");

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Stock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoe_ShoeCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ShoeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_CategoryId",
                table: "Shoe",
                column: "CategoryId");
        }
    }
}
