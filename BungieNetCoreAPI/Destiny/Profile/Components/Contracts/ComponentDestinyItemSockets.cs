using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemSockets
    {
        public ReadOnlyCollection<DestinyItemSocketState> Sockets { get; }

        [JsonConstructor]
        internal ComponentDestinyItemSockets(DestinyItemSocketState[] sockets)
        {
            Sockets = sockets.AsReadOnlyOrEmpty();
        }
    }
}
