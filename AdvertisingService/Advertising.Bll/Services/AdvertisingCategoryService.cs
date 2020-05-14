using Advertising.Bll.Services.Interfaces;
using Advertising.Dal.Repositories.Interfaces;
using Common.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Bll.Services
{
    public class AdvertisingCategoryService : IAdvertisingCategoryService
    {
        private IAdvertisingCategoryRepository db;

        public AdvertisingCategoryService(IAdvertisingCategoryRepository db)
        {
            this.db = db;
        }

        public async Task<AdvertisingCategory> CreateAsync(AdvertisingCategory item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<AdvertisingCategory> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<AdvertisingCategory>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<AdvertisingCategory> GetItemByIdAsync(int id)
        {
            AdvertisingCategory advertisingCategory = await db.GetItemByIdAsync(id);

            if (advertisingCategory == null)
            {
                return new AdvertisingCategory();
            }

            return advertisingCategory;
        }

        public async Task UpdateAsync(AdvertisingCategory item)
        {
            await db.UpdateAsync(item);
        }
    }
}
