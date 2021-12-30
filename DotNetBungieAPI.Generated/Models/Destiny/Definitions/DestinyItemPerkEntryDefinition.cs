using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemPerkEntryDefinition
{

    [JsonPropertyName("requirementDisplayString")]
    public string RequirementDisplayString { get; init; }

    [JsonPropertyName("perkHash")]
    public uint PerkHash { get; init; }

    [JsonPropertyName("perkVisibility")]
    public Destiny.ItemPerkVisibility PerkVisibility { get; init; }
}
