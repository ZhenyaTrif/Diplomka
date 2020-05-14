using Common.Entity;
using Common.Patterns;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Bll.Services.Interfaces
{
    public interface IAdvertisingEntityService : IService<AdvertisingModel>
    {
        Task<IEnumerable<AdvertisingModel>> GetByAdvertisingCategoryIdAsync(int advertisingCategoryId);
    }
}
