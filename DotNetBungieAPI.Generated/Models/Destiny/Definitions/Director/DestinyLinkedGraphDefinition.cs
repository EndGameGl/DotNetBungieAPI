namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     This describes links between the current graph and others, as well as when that link is relevant.
/// </summary>
public class DestinyLinkedGraphDefinition : IDeepEquatable<DestinyLinkedGraphDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("unlockExpression")]
    public Destiny.Definitions.DestinyUnlockExpressionDefinition UnlockExpression { get; set; }

    [JsonPropertyName("linkedGraphId")]
    public uint LinkedGraphId { get; set; }

    [JsonPropertyName("linkedGraphs")]
    public List<Destiny.Definitions.Director.DestinyLinkedGraphEntryDefinition> LinkedGraphs { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    public bool DeepEquals(DestinyLinkedGraphDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               Name == other.Name &&
               (UnlockExpression is not null ? UnlockExpression.DeepEquals(other.UnlockExpression) : other.UnlockExpression is null) &&
               LinkedGraphId == other.LinkedGraphId &&
               LinkedGraphs.DeepEqualsList(other.LinkedGraphs) &&
               Overview == other.Overview;
    }
}