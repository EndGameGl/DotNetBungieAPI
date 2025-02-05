namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyStringVariablesComponent
{
    [JsonPropertyName("integerValuesByHash")]
    public ReadOnlyDictionary<uint, int> IntegerValuesByHash { get; init; } =
        ReadOnlyDictionary<uint, int>.Empty;
}
