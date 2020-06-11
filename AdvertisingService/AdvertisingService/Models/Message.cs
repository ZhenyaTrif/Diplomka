using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisingService.Models
{
    public class Message
    {
        public List<AuctionLot> lot { get; set; }

        public List<ApplicationUser> creator { get; set; }

        public Message(List<AuctionLot> lott, List<ApplicationUser> usser)
        {
            lot = lott;
            creator = usser;
        }
    }
}
