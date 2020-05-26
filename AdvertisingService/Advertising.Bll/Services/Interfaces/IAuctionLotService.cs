using Common.Entity;
using Common.Patterns;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Bll.Services.Interfaces
{
    public interface IAuctionLotService : IService<AuctionLot>
    {
        Task<IEnumerable<AuctionLot>> GetByAdvertisingCategoryIdAsync(int advertisingCategoryId);
    }
}
