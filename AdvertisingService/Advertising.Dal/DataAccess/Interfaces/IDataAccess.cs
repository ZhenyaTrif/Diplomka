using Advertising.Dal.Repositories.Interfaces;

namespace Advertising.Dal.DataAccess.Interfaces
{
    public interface IDataAccess
    {
        IAdvertisingRepository Advertisings { get; set; }

        IAdvertisingCategoryRepository AdvertisingCategories { get; set; }

        IAuctionLotRepository AuctionLots { get; set; }
    }
}
