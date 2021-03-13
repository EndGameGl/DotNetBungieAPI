using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyCollectibleComponent
    {
        public DestinyCollectibleState State { get; }
        [JsonConstructor]
        internal DestinyCollectibleComponent(DestinyCollectibleState state)
        {
            State = state;
        }
    }
}
