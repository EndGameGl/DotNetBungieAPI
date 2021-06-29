using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Progressions;

namespace NetBungieAPI.Models.GroupsV2
{
    /// <summary>
    ///     The same as GroupV2ClanInfo, but includes any investment data.
    /// </summary>
    public sealed record GroupV2ClanInfoAndInvestment : GroupV2ClanInfo
    {
        [JsonPropertyName("d2ClanProgressions")]
        public ReadOnlyDictionary<uint, DestinyProgression> D2ClanProgressions { get; init; }
    }
}