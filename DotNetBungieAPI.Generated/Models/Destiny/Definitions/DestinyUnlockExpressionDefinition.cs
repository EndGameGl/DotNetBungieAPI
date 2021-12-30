using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyUnlockExpressionDefinition
{

    [JsonPropertyName("scope")]
    public Destiny.DestinyGatingScope Scope { get; init; }
}
