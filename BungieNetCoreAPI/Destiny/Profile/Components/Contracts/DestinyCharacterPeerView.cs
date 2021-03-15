using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterPeerView
    {
        public ReadOnlyCollection<DestinyItemPeerView> Equipment { get; }

        [JsonConstructor]
        internal DestinyCharacterPeerView(DestinyItemPeerView[] equipment)
        {
            Equipment = equipment.AsReadOnlyOrEmpty();
        }
    }
}
