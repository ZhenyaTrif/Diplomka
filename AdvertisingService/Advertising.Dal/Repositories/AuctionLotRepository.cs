using Advertising.Dal.Contexts;
using Advertising.Dal.Repositories.Interfaces;
using Common.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Dal.Repositories
{
    public class AuctionLotRepository: IAuctionLotRepository
    {
        private readonly AdvertisingServiceContext db;

        public AuctionLotRepository(AdvertisingServiceContext db)
        {
            this.db = db;
        }

        public async Task<AuctionLot> CreateAsync(AuctionLot item)
        {
            if (item != null)
            {
                db.AuctionLots.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<AuctionLot> DeleteAsync(int id)
        {
            AuctionLot item = await db.AuctionLots.FindAsync(id);

            if (item != null)
            {
                db.AuctionLots.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<AuctionLot>> GetAllAsync()
        {
            return await db.AuctionLots.ToListAsync();
        }

        public async Task<IEnumerable<AuctionLot>> GetByAdvertisingCategoryId(int advertisingCategoryId)
        {
            var ads = (await GetAllAsync()) as List<AuctionLot>;

            return ads.FindAll(note => note.LotCategoryId == advertisingCategoryId);
        }

        public async Task<AuctionLot> GetItemByIdAsync(int id)
        {
            return await db.AuctionLots.FindAsync(id);
        }

        public async Task UpdateAsync(AuctionLot item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
