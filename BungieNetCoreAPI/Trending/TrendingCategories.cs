using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Trending
{
    public class TrendingCategories
    {
        public ReadOnlyCollection<TrendingCategory> Categories { get; }

        [JsonConstructor]
        internal TrendingCategories(TrendingCategory[] categories)
        {
            Categories = categories.AsReadOnlyOrEmpty();
        }
    }
}
