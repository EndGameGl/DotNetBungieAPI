using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorCategoriesComponent
    {
        public ReadOnlyCollection<DestinyVendorCategory> Categories { get; }

        [JsonConstructor]
        internal DestinyVendorCategoriesComponent(DestinyVendorCategory[] categories)
        {
            Categories = categories.AsReadOnlyOrEmpty();
        }
    }
}
