using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wall.Migrations
{
    public partial class _ProductsAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    material = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    size = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    value = table.Column<int>(nullable: false),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dc0d084-58a1-4749-81da-537c7832d080",
                column: "ConcurrencyStamp",
                value: "3a56282a-536f-4a02-86e9-33bbbe1d1e08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84ef18a5-4c20-4306-a26f-1e9c112233c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2f6fcd2-0534-447a-a2a9-01195e334490", "AQAAAAEAACcQAAAAEKbrdjAuhHeSnsK6pyeVStuv0ws+bGCBLGvG8sb/1c8j/ZCDxQmdaG5N0rZ1Hzl7wA==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "categoryName" },
                values: new object[,]
                {
                    { 1, "Футболки" },
                    { 2, "Кофти" },
                    { 3, "Куртки" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dc0d084-58a1-4749-81da-537c7832d080",
                column: "ConcurrencyStamp",
                value: "f3fc2b80-ff6e-467d-8817-7f0f2d363483");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84ef18a5-4c20-4306-a26f-1e9c112233c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff0a17f9-f18c-4977-8e4b-21a79f23d8c5", "AQAAAAEAACcQAAAAELphQsZ6wAFE9moFqON5vuEIVRiKGxdnWqnb5ruxaRNVlMdVDSPVoe0hApT170QHqQ==" });
        }
    }
}
