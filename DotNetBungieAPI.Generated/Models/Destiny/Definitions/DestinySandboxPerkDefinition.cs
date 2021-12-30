using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinySandboxPerkDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("perkIdentifier")]
    public string PerkIdentifier { get; init; }

    [JsonPropertyName("isDisplayable")]
    public bool IsDisplayable { get; init; }

    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; init; }

    [JsonPropertyName("damageTypeHash")]
    public uint? DamageTypeHash { get; init; }

    [JsonPropertyName("perkGroups")]
    public Destiny.Definitions.DestinyTalentNodeStepGroups PerkGroups { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
