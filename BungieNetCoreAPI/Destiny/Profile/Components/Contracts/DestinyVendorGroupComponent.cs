using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorGroupComponent
    {
        public ReadOnlyCollection<DestinyVendorGroup> Groups { get; }
        [JsonConstructor]
        internal DestinyVendorGroupComponent(DestinyVendorGroup[] groups)
        {
            Groups = groups.AsReadOnlyOrEmpty();
        }
    }
}
