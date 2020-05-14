using Advertising.Bll.BusinessLogic.Interfaces;
using Advertising.Bll.Services.Interfaces;

namespace Advertising.Bll.BusinessLogic
{
    public class BusinessLogic: IBusinessLogic
    {
        public BusinessLogic(IAdvertisingEntityService ads, IAdvertisingCategoryService advertisingCategories)
        {
            Advertisings = ads;

            AdvertisingCategories = advertisingCategories;
        }

        public IAdvertisingEntityService Advertisings { get; set; }

        public IAdvertisingCategoryService AdvertisingCategories { get; set; }
    }
}
