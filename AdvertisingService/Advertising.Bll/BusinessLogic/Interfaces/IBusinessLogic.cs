using Advertising.Bll.Services.Interfaces;

namespace Advertising.Bll.BusinessLogic.Interfaces
{
    public interface IBusinessLogic
    {
        IAdvertisingEntityService Advertisings { get; set; }

        IAdvertisingCategoryService AdvertisingCategories { get; set; }

        IAuctionLotService AuctionLots { get; set; }
    }
}
