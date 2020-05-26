using Common.Entity;
using Common.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertising.Dal.Repositories.Interfaces
{
    public interface IAuctionLotRepository : IRepository<AuctionLot>
    {
        Task<IEnumerable<AuctionLot>> GetByAdvertisingCategoryId(int advertisingCategoryId);
    }
}
