using Common.Entity;
using Common.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Dal.Repositories.Interfaces
{
    public interface IAdvertisingRepository : IRepository<AdvertisingModel>
    {
        Task<IEnumerable<AdvertisingModel>> GetByAdvertisingCategoryId(int advertisingCategoryId);
    }
}
