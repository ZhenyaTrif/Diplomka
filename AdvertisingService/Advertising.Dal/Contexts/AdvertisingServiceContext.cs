using Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace Advertising.Dal.Contexts
{
    public class AdvertisingServiceContext : DbContext
    {
        public AdvertisingServiceContext(DbContextOptions<AdvertisingServiceContext> options)
            : base(options)
        {
            
        }

        public DbSet<AdvertisingModel> Advertisings { get; set; }

        public DbSet<AdvertisingCategory> AdvertisingCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertisingCategory>().HasData(
                new AdvertisingCategory[]
                {
                new AdvertisingCategory { Id=1, CategoryName="Audi"},
                new AdvertisingCategory { Id=2, CategoryName="BMW"},
                new AdvertisingCategory { Id=3, CategoryName="Volkswagen"},
                new AdvertisingCategory { Id=4, CategoryName="Volvo"},
                new AdvertisingCategory { Id=5, CategoryName="Lada"},
                new AdvertisingCategory { Id=6, CategoryName="Citroen"},
                new AdvertisingCategory { Id=7, CategoryName="Land Rover"},
                new AdvertisingCategory { Id=8, CategoryName="Nissan"}
                });
            modelBuilder.Entity<AdvertisingModel>().HasData(
                new AdvertisingModel[]
                {
                new AdvertisingModel { Id=1, AdvertisingName="Audi A1", Text="Авто 2013 года. Оригинальный пробег подтвержденный сервисными документами. +375293585471",
                    ImagePath ="http://cdn.motorpage.ru/Photos/800/1E66.jpg", ItemPrice="21 000", AdvertisingCategoryId=1},
                new AdvertisingModel { Id=2, AdvertisingName="Audi A4 B7", Text="Авто 2006 г. Автомобиль в отличном состоянии ,работает как Часы. +375445412518",
                    ImagePath ="https://media.motorlandby.ru/car/540731/4.jpg", ItemPrice="18 000", AdvertisingCategoryId=1},
                new AdvertisingModel { Id=3, AdvertisingName="BMW X1 E84 X-drive", Text="2009 г. Отличная комплектация. АКПП без проблем. Салон кожа. Адаптивный свет. +375297665131",
                    ImagePath ="https://s31.wheelsage.org/format/picture/picture-preview-large/b/bmw/x1_xdrive20d/bmw_x1_xdrive20d_38_016000a20c770898.jpg", ItemPrice="31 000", AdvertisingCategoryId=2},
                new AdvertisingModel { Id=4, AdvertisingName="BMW X5", Text="Авто 2003 г. Хорошее состояние +375297654131",
                    ImagePath ="https://s-turbo.by/images/shop/products/full_nakladka-perednego-bampera-ag181-bmw-x5-e53-102003-102006.jpg", ItemPrice="13 000", AdvertisingCategoryId=2},
                new AdvertisingModel { Id=5, AdvertisingName="Volkswagen Tiguan I 2013", Text="Авто в отличном состоянии +375297694131",
                    ImagePath ="https://img.automoto.ua/auto/Volkswagen-Tiguan-ne_ukazan-none-2013-6b4-17098255.jpeg", ItemPrice="25 000", AdvertisingCategoryId=3},
                new AdvertisingModel { Id=6, AdvertisingName="Volkswagen Golf VI", Text="2011 г. +375298354131",
                    ImagePath ="http://cloud.leparking.fr/2018/12/03/03/20/volkswagen-golf-vw-golf-6-r-2011-90000-km-noir_6573771276.jpg", ItemPrice="16 500", AdvertisingCategoryId=3},
                new AdvertisingModel { Id=7, AdvertisingName="Volvo 740 TURBO, 1987", Text="Для своих лет состояние идеальное +375297584937",
                    ImagePath ="https://cdn.bringatrailer.com/wp-content/uploads/2019/06/1987_volvo_740_156130611409211149IMG_0804-940x597.jpg", ItemPrice="1 500", AdvertisingCategoryId=4},
                new AdvertisingModel { Id=8, AdvertisingName="Volvo S80 I, 2001", Text="+375948374928",
                    ImagePath ="https://rzpict1.blob.core.windows.net/images/480/autoscout24.nl/RZCATSNL722034F3388F/VOLVO-S80-1.jpg", ItemPrice="15 000", AdvertisingCategoryId=4},
                new AdvertisingModel { Id=9, AdvertisingName="Lada (ВАЗ) Vesta 2018", Text="Машина только с салона. +375297394815",
                    ImagePath ="https://img-salon.a.tyt.by/catalog/vaz-lada/vesta/0d/1/5605696a794fc.jpeg", ItemPrice="22 000", AdvertisingCategoryId=5},
                new AdvertisingModel { Id=10, AdvertisingName="Lada (ВАЗ) Granta, 2019", Text="Пробег 5274 км. +375338475933",
                    ImagePath ="http://cdn.motorpage.ru/Photos/800/01a9D.jpg", ItemPrice="13 000", AdvertisingCategoryId=5},
                new AdvertisingModel { Id=11, AdvertisingName="Citroen C3 II, 2010", Text="Авто 2010 стаяла в гараже проюег 10 000 км за 9 лет. +375283947583",
                    ImagePath ="http://www.aw.by/photos/catalog/64847_1.jpg", ItemPrice="14 000", AdvertisingCategoryId=6},
                new AdvertisingModel { Id=12, AdvertisingName="Citroen C5 II, 2010", Text="Авто 2010 пробег 120 000. +375297483759",
                    ImagePath ="https://s.drom.ru/1/reviews/photos/citroen/c5/big_48587_1.jpeg", ItemPrice="16 000", AdvertisingCategoryId=6},
                new AdvertisingModel { Id=13, AdvertisingName="Land Rover Range Rover III", Text=" 2010 г. Пробез 170к. +37584938496",
                    ImagePath ="https://a.d-cd.net/32ea88as-960.jpg", ItemPrice="44 000", AdvertisingCategoryId=7},
                new AdvertisingModel { Id=14, AdvertisingName="Land Rover Discovery III SE, 2006", Text="Машина 2006 г. Пробег 320к. +375847934942",
                    ImagePath ="https://a.d-cd.net/0YAAAgAgCOA-960.jpg", ItemPrice="26 000", AdvertisingCategoryId=7},
                new AdvertisingModel { Id=15, AdvertisingName="Nissan Juke YF15, 2011", Text="С пробегом 91 000 км. Автомат +375297482759",
                    ImagePath ="https://image-cdn.beforward.jp/large/201707/783544/BF658797_0c8841.jpg", ItemPrice="21 000", AdvertisingCategoryId=8},
                new AdvertisingModel { Id=16, AdvertisingName="Nissan Terrano R20", Text="Авто 2003 г. 260к км. +375298475936",
                    ImagePath ="https://s1.cdn.autoevolution.com/images/gallery/NISSANTerrano3Doors-430_10.jpg", ItemPrice="16 000", AdvertisingCategoryId=8},
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
