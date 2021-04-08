using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorGroupComponent
    {
        public ReadOnlyCollection<DestinyVendorGroup> Groups { get; init; }
        [JsonConstructor]
        internal DestinyVendorGroupComponent(DestinyVendorGroup[] groups)
        {
            Groups = groups.AsReadOnlyOrEmpty();
        }
    }
}
