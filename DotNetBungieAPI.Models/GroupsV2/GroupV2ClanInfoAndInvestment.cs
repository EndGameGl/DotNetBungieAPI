using DotNetBungieAPI.Models.Destiny.Progressions;

namespace DotNetBungieAPI.Models.GroupsV2;

/// <summary>
///     The same as GroupV2ClanInfo, but includes any investment data.
/// </summary>
public sealed record GroupV2ClanInfoAndInvestment : GroupV2ClanInfo
{
    [JsonPropertyName("d2ClanProgressions")]
    public ReadOnlyDictionary<uint, DestinyProgression> D2ClanProgressions { get; init; }
}
