using NetBungieAPI.Models.Destiny.Progressions;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupV2ClanInfoAndInvestment : GroupV2ClanInfo
    {
        [JsonPropertyName("d2ClanProgressions")]
        public ReadOnlyDictionary<uint, DestinyProgression> D2ClanProgressions { get; init; }
    }
}
