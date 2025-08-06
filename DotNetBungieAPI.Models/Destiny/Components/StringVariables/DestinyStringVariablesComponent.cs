namespace DotNetBungieAPI.Models.Destiny.Components.StringVariables;

public sealed class DestinyStringVariablesComponent
{
    [JsonPropertyName("integerValuesByHash")]
    public Dictionary<uint, int>? IntegerValuesByHash { get; init; }
}
