using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertisingService.Migrations.AdvertisingService
{
    public partial class AddAuctionLotMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionLots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LotName = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    StartPrice = table.Column<string>(nullable: false),
                    LotCategoryId = table.Column<int>(nullable: false),
                    CreaterId = table.Column<string>(nullable: true),
                    Checked = table.Column<bool>(nullable: false),
                    Opened = table.Column<bool>(nullable: false),
                    WinnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionLots", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ItemPrice",
                value: "21 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ItemPrice",
                value: "18 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ItemPrice",
                value: "31 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 4,
                column: "ItemPrice",
                value: "13 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 5,
                column: "ItemPrice",
                value: "25 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 6,
                column: "ItemPrice",
                value: "16 500");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 7,
                column: "ItemPrice",
                value: "1 500");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 8,
                column: "ItemPrice",
                value: "15 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 9,
                column: "ItemPrice",
                value: "22 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 10,
                column: "ItemPrice",
                value: "13 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 11,
                column: "ItemPrice",
                value: "14 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 12,
                column: "ItemPrice",
                value: "16 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ItemPrice", "Text" },
                values: new object[] { "44 000", " 2010 г. Пробез 170к. +37584938496" });

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 14,
                column: "ItemPrice",
                value: "26 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 15,
                column: "ItemPrice",
                value: "21 000");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 16,
                column: "ItemPrice",
                value: "16 000");

            migrationBuilder.InsertData(
                table: "AuctionLots",
                columns: new[] { "Id", "Checked", "CreaterId", "ImagePath", "LotCategoryId", "LotName", "Opened", "StartPrice", "Text", "WinnerId" },
                values: new object[] { 1, false, "06fb596d-baae-44ea-93f6-d14120c7a8f9", "https://autoreview.ru/images/Article/1689/Article_168984_860_575.jpg", 1, "Audi A6", true, "50000", "Авто 2016 года. Есть страховка. Все документамы имеются. +375293564367", "no" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionLots");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ItemPrice",
                value: "21 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ItemPrice",
                value: "18 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ItemPrice",
                value: "31 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 4,
                column: "ItemPrice",
                value: "13 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 5,
                column: "ItemPrice",
                value: "25 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 6,
                column: "ItemPrice",
                value: "16 500 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 7,
                column: "ItemPrice",
                value: "1 500 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 8,
                column: "ItemPrice",
                value: "15 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 9,
                column: "ItemPrice",
                value: "22 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 10,
                column: "ItemPrice",
                value: "13 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 11,
                column: "ItemPrice",
                value: "14 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 12,
                column: "ItemPrice",
                value: "16 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ItemPrice", "Text" },
                values: new object[] { "44 000 р.", "2010 г. Пробез 170к. +37584938496" });

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 14,
                column: "ItemPrice",
                value: "26 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 15,
                column: "ItemPrice",
                value: "21 000 р.");

            migrationBuilder.UpdateData(
                table: "Advertisings",
                keyColumn: "Id",
                keyValue: 16,
                column: "ItemPrice",
                value: "16 000 р.");
        }
    }
}
