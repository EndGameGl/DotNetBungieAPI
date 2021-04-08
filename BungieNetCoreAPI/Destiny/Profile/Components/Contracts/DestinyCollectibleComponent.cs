using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCollectibleComponent
    {
        public DestinyCollectibleState State { get; init; }
        [JsonConstructor]
        internal DestinyCollectibleComponent(DestinyCollectibleState state)
        {
            State = state;
        }
    }
}
