using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorCategory
    {
        public int DisplayCategoryIndex { get; init; }
        public ReadOnlyCollection<int> ItemIndexes { get; init; }

        [JsonConstructor]
        internal DestinyVendorCategory(int displayCategoryIndex, int[] itemIndexes)
        {
            DisplayCategoryIndex = displayCategoryIndex;
            ItemIndexes = itemIndexes.AsReadOnlyOrEmpty();
        }
    }
}
