using Advertising.Dal.Contexts;
using Advertising.Dal.Repositories.Interfaces;
using Common.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Dal.Repositories
{
    public class AdvertisingRepository : IAdvertisingRepository
    {
        private readonly AdvertisingServiceContext db;

        public AdvertisingRepository(AdvertisingServiceContext db)
        {
            this.db = db;
        }

        public async Task<AdvertisingModel> CreateAsync(AdvertisingModel item)
        {
            if (item != null)
            {
                db.Advertisings.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<AdvertisingModel> DeleteAsync(int id)
        {
            AdvertisingModel item = await db.Advertisings.FindAsync(id);

            if (item != null)
            {
                db.Advertisings.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<AdvertisingModel>> GetAllAsync()
        {
            return await db.Advertisings.ToListAsync();
        }

        public async Task<IEnumerable<AdvertisingModel>> GetByAdvertisingCategoryId(int advertisingCategoryId)
        {
            var ads = (await GetAllAsync()) as List<AdvertisingModel>;

            return ads.FindAll(note => note.AdvertisingCategoryId == advertisingCategoryId);
        }

        public async Task<AdvertisingModel> GetItemByIdAsync(int id)
        {
            return await db.Advertisings.FindAsync(id);
        }

        public async Task UpdateAsync(AdvertisingModel item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
