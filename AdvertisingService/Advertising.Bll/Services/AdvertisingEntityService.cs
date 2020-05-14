using Advertising.Bll.Services.Interfaces;
using Advertising.Dal.Repositories.Interfaces;
using Common.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Bll.Services
{
    public class AdvertisingEntityService : IAdvertisingEntityService
    {
        private IAdvertisingRepository db;

        public AdvertisingEntityService(IAdvertisingRepository db)
        {
            this.db = db;
        }

        public async Task<AdvertisingModel> CreateAsync(AdvertisingModel item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<AdvertisingModel> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<AdvertisingModel>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<IEnumerable<AdvertisingModel>> GetByAdvertisingCategoryIdAsync(int advertisingCategoryId)
        {
            return await db.GetByAdvertisingCategoryId(advertisingCategoryId);
        }

        public async Task<AdvertisingModel> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(AdvertisingModel item)
        {
            await db.UpdateAsync(item);
        }
    }
}
