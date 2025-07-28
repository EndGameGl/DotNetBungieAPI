namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     This describes links between the current graph and others, as well as when that link is relevant.
/// </summary>
public class DestinyLinkedGraphDefinition
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("unlockExpression")]
    public Destiny.Definitions.DestinyUnlockExpressionDefinition? UnlockExpression { get; set; }

    [JsonPropertyName("linkedGraphId")]
    public uint LinkedGraphId { get; set; }

    [JsonPropertyName("linkedGraphs")]
    public Destiny.Definitions.Director.DestinyLinkedGraphEntryDefinition[]? LinkedGraphs { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }
}
