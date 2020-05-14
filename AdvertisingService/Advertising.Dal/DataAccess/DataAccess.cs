using Advertising.Dal.DataAccess.Interfaces;
using Advertising.Dal.Repositories.Interfaces;

namespace Advertising.Dal.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IAdvertisingRepository advertisings, IAdvertisingCategoryRepository advertisingCategories)
        {
            Advertisings = advertisings;
            AdvertisingCategories = advertisingCategories;
        }

        public IAdvertisingRepository Advertisings { get; set; }

        public IAdvertisingCategoryRepository AdvertisingCategories { get; set; }
    }
}
