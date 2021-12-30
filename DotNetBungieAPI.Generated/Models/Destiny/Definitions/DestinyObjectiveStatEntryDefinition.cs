using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyObjectiveStatEntryDefinition
{

    [JsonPropertyName("stat")]
    public Destiny.Definitions.DestinyItemInvestmentStatDefinition Stat { get; init; }

    [JsonPropertyName("style")]
    public Destiny.DestinyObjectiveGrantStyle Style { get; init; }
}
