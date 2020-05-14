using Common.Entity;
using System.Collections.Generic;

namespace AdvertisingService.Models
{
    public class FilterModel
    {
        public FilterModel(IEnumerable<AdvertisingCategory> categories, int? category, string title)
        {
            Categories = categories;
            SelectedCategory = category;
            SelectedTitle = title;
        }

        public IEnumerable<AdvertisingCategory> Categories { get; private set; }

        public int? SelectedCategory { get; private set; }

        public string SelectedTitle { get; private set; }
    }
}
