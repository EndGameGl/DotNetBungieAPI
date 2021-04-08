using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryJoinability
    {
        public int OpenSlots { get; init; }
        public DestinyGamePrivacySetting PrivacySetting { get; init; }
        public DestinyJoinClosedReasons ClosedReasons { get; init; }

        [JsonConstructor]
        internal DestinyProfileTransitoryJoinability(int openSlots, DestinyGamePrivacySetting privacySetting, DestinyJoinClosedReasons closedReasons)
        {
            OpenSlots = openSlots;
            PrivacySetting = privacySetting;
            ClosedReasons = closedReasons;
        }
    }
}
