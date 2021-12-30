using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemTalentGridBlockDefinition
{

    [JsonPropertyName("talentGridHash")]
    public uint TalentGridHash { get; init; }

    [JsonPropertyName("itemDetailString")]
    public string ItemDetailString { get; init; }

    [JsonPropertyName("buildName")]
    public string BuildName { get; init; }

    [JsonPropertyName("hudDamageType")]
    public Destiny.DamageType HudDamageType { get; init; }

    [JsonPropertyName("hudIcon")]
    public string HudIcon { get; init; }
}
