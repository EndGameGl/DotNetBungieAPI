using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyLinkedGraphDefinition
{

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("unlockExpression")]
    public Destiny.Definitions.DestinyUnlockExpressionDefinition UnlockExpression { get; init; }

    [JsonPropertyName("linkedGraphId")]
    public uint LinkedGraphId { get; init; }

    [JsonPropertyName("linkedGraphs")]
    public List<Destiny.Definitions.Director.DestinyLinkedGraphEntryDefinition> LinkedGraphs { get; init; }

    [JsonPropertyName("overview")]
    public string Overview { get; init; }
}
