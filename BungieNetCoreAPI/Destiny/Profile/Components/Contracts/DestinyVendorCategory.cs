using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorCategory
    {
        public int DisplayCategoryIndex { get; }
        public ReadOnlyCollection<int> ItemIndexes { get; }

        [JsonConstructor]
        internal DestinyVendorCategory(int displayCategoryIndex, int[] itemIndexes)
        {
            DisplayCategoryIndex = displayCategoryIndex;
            ItemIndexes = itemIndexes.AsReadOnlyOrEmpty();
        }
    }
}
