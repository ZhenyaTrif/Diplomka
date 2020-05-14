using Advertising.Dal.Contexts;
using Advertising.Dal.Repositories.Interfaces;
using Common.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Dal.Repositories
{
    public class AdvertisingCategoryRepository : IAdvertisingCategoryRepository
    {
        private readonly AdvertisingServiceContext db;

        public AdvertisingCategoryRepository(AdvertisingServiceContext db)
        {
            this.db = db;
        }

        public async Task<AdvertisingCategory> CreateAsync(AdvertisingCategory item)
        {
            if (item != null)
            {
                db.AdvertisingCategories.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<AdvertisingCategory> DeleteAsync(int id)
        {
            AdvertisingCategory item = await db.AdvertisingCategories.FindAsync(id);

            if (item != null)
            {
                db.AdvertisingCategories.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<AdvertisingCategory>> GetAllAsync()
        {
            return await db.AdvertisingCategories.ToListAsync();
        }

        public async Task<AdvertisingCategory> GetItemByIdAsync(int id)
        {
            return await db.AdvertisingCategories.FindAsync(id);
        }

        public async Task UpdateAsync(AdvertisingCategory item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
