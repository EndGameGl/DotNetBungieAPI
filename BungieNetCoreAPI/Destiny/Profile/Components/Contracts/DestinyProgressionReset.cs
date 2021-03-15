using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProgressionReset
    {
        public int Season { get; }
        public int Resets { get; }

        [JsonConstructor]
        internal DestinyProgressionReset(int season, int resets)
        {
            Season = season;
            Resets = resets;
        }

    }
}
