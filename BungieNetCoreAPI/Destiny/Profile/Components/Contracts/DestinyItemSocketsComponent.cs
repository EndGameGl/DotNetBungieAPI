using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemSocketsComponent
    {
        public ReadOnlyCollection<DestinyItemSocketState> Sockets { get; }

        [JsonConstructor]
        internal DestinyItemSocketsComponent(DestinyItemSocketState[] sockets)
        {
            Sockets = sockets.AsReadOnlyOrEmpty();
        }
    }
}
