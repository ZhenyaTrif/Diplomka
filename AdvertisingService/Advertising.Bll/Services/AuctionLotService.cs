using Advertising.Bll.Services.Interfaces;
using Advertising.Dal.Repositories.Interfaces;
using Common.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Bll.Services
{
    public class AuctionLotService : IAuctionLotService
    {
        private IAuctionLotRepository db;

        public AuctionLotService(IAuctionLotRepository db)
        {
            this.db = db;
        }

        public async Task<AuctionLot> CreateAsync(AuctionLot item)
        {
            return await db.CreateAsync(item);
        }

        public async Task<AuctionLot> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<AuctionLot>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<IEnumerable<AuctionLot>> GetByAdvertisingCategoryIdAsync(int advertisingCategoryId)
        {
            return await db.GetByAdvertisingCategoryId(advertisingCategoryId);
        }

        public async Task<AuctionLot> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(AuctionLot item)
        {
            await db.UpdateAsync(item);
        }
    }
}
