using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemSocketsComponent
    {
        public ReadOnlyCollection<DestinyItemSocketState> Sockets { get; init; }

        [JsonConstructor]
        internal DestinyItemSocketsComponent(DestinyItemSocketState[] sockets)
        {
            Sockets = sockets.AsReadOnlyOrEmpty();
        }
    }
}
