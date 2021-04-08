using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterPeerView
    {
        public ReadOnlyCollection<DestinyItemPeerView> Equipment { get; init; }

        [JsonConstructor]
        internal DestinyCharacterPeerView(DestinyItemPeerView[] equipment)
        {
            Equipment = equipment.AsReadOnlyOrEmpty();
        }
    }
}
