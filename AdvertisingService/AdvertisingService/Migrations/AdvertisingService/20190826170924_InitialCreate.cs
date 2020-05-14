using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertisingService.Migrations.AdvertisingService
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertisingName = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<string>(nullable: true),
                    AdvertisingCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdvertisingCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Volkswagen" },
                    { 4, "Volvo" },
                    { 5, "Lada" },
                    { 6, "Citroen" },
                    { 7, "Land Rover" },
                    { 8, "Nissan" }
                });

            migrationBuilder.InsertData(
                table: "Advertisings",
                columns: new[] { "Id", "AdvertisingCategoryId", "AdvertisingName", "ImagePath", "ItemPrice", "Text" },
                values: new object[,]
                {
                    { 14, 7, "Land Rover Discovery III SE, 2006", "https://a.d-cd.net/0YAAAgAgCOA-960.jpg", "26 000 р.", "Машина 2006 г. Пробег 320к. +375847934942" },
                    { 13, 7, "Land Rover Range Rover III", "https://a.d-cd.net/32ea88as-960.jpg", "44 000 р.", "2010 г. Пробез 170к. +37584938496" },
                    { 12, 6, "Citroen C5 II, 2010", "https://s.drom.ru/1/reviews/photos/citroen/c5/big_48587_1.jpeg", "16 000 р.", "Авто 2010 пробег 120 000. +375297483759" },
                    { 11, 6, "Citroen C3 II, 2010", "http://www.aw.by/photos/catalog/64847_1.jpg", "14 000 р.", "Авто 2010 стаяла в гараже проюег 10 000 км за 9 лет. +375283947583" },
                    { 10, 5, "Lada (ВАЗ) Granta, 2019", "http://cdn.motorpage.ru/Photos/800/01a9D.jpg", "13 000 р.", "Пробег 5274 км. +375338475933" },
                    { 9, 5, "Lada (ВАЗ) Vesta 2018", "https://img-salon.a.tyt.by/catalog/vaz-lada/vesta/0d/1/5605696a794fc.jpeg", "22 000 р.", "Машина только с салона. +375297394815" },
                    { 8, 4, "Volvo S80 I, 2001", "https://rzpict1.blob.core.windows.net/images/480/autoscout24.nl/RZCATSNL722034F3388F/VOLVO-S80-1.jpg", "15 000 р.", "+375948374928" },
                    { 4, 2, "BMW X5", "https://s-turbo.by/images/shop/products/full_nakladka-perednego-bampera-ag181-bmw-x5-e53-102003-102006.jpg", "13 000 р.", "Авто 2003 г. Хорошее состояние +375297654131" },
                    { 6, 3, "Volkswagen Golf VI", "http://cloud.leparking.fr/2018/12/03/03/20/volkswagen-golf-vw-golf-6-r-2011-90000-km-noir_6573771276.jpg", "16 500 р.", "2011 г. +375298354131" },
                    { 5, 3, "Volkswagen Tiguan I 2013", "https://img.automoto.ua/auto/Volkswagen-Tiguan-ne_ukazan-none-2013-6b4-17098255.jpeg", "25 000 р.", "Авто в отличном состоянии +375297694131" },
                    { 15, 8, "Nissan Juke YF15, 2011", "https://image-cdn.beforward.jp/large/201707/783544/BF658797_0c8841.jpg", "21 000 р.", "С пробегом 91 000 км. Автомат +375297482759" },
                    { 3, 2, "BMW X1 E84 X-drive", "https://s31.wheelsage.org/format/picture/picture-preview-large/b/bmw/x1_xdrive20d/bmw_x1_xdrive20d_38_016000a20c770898.jpg", "31 000 р.", "2009 г. Отличная комплектация. АКПП без проблем. Салон кожа. Адаптивный свет. +375297665131" },
                    { 2, 1, "Audi A4 B7", "https://media.motorlandby.ru/car/540731/4.jpg", "18 000 р.", "Авто 2006 г. Автомобиль в отличном состоянии ,работает как Часы. +375445412518" },
                    { 1, 1, "Audi A1", "http://cdn.motorpage.ru/Photos/800/1E66.jpg", "21 000 р.", "Авто 2013 года. Оригинальный пробег подтвержденный сервисными документами. +375293585471" },
                    { 7, 4, "Volvo 740 TURBO, 1987", "https://cdn.bringatrailer.com/wp-content/uploads/2019/06/1987_volvo_740_156130611409211149IMG_0804-940x597.jpg", "1 500 р.", "Для своих лет состояние идеальное +375297584937" },
                    { 16, 8, "Nissan Terrano R20", "https://s1.cdn.autoevolution.com/images/gallery/NISSANTerrano3Doors-430_10.jpg", "16 000 р.", "Авто 2003 г. 260к км. +375298475936" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisingCategories");

            migrationBuilder.DropTable(
                name: "Advertisings");
        }
    }
}
