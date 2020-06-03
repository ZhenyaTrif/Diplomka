using Common.Entity;
using System.Collections.Generic;

namespace AdvertisingService.Models
{
    public class SearchListModel<T>
    {
        public IEnumerable<T> Ads { get; set; }

        public PageModel PageModel { get; set; }

        public FilterModel FilterModel { get; set; }
    }
}
