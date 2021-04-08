using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProgressionReset
    {
        public int Season { get; init; }
        public int Resets { get; init; }

        [JsonConstructor]
        internal DestinyProgressionReset(int season, int resets)
        {
            Season = season;
            Resets = resets;
        }

    }
}
