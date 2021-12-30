using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSetBlockDefinition
{

    [JsonPropertyName("itemList")]
    public List<Destiny.Definitions.DestinyItemSetBlockEntryDefinition> ItemList { get; init; }

    [JsonPropertyName("requireOrderedSetItemAdd")]
    public bool RequireOrderedSetItemAdd { get; init; }

    [JsonPropertyName("setIsFeatured")]
    public bool SetIsFeatured { get; init; }

    [JsonPropertyName("setType")]
    public string SetType { get; init; }

    [JsonPropertyName("questLineName")]
    public string QuestLineName { get; init; }

    [JsonPropertyName("questLineDescription")]
    public string QuestLineDescription { get; init; }

    [JsonPropertyName("questStepSummary")]
    public string QuestStepSummary { get; init; }
}
