using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryJoinability
    {
        public int OpenSlots { get; }
        public DestinyGamePrivacySetting PrivacySetting { get; }
        public DestinyJoinClosedReasons ClosedReasons { get; }

        [JsonConstructor]
        internal DestinyProfileTransitoryJoinability(int openSlots, DestinyGamePrivacySetting privacySetting, DestinyJoinClosedReasons closedReasons)
        {
            OpenSlots = openSlots;
            PrivacySetting = privacySetting;
            ClosedReasons = closedReasons;
        }
    }
}
