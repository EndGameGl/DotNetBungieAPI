namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderListingValue
{
    [JsonPropertyName("valueType")]
    public uint ValueType { get; init; }

    [JsonPropertyName("values")]
    public List<uint> Values { get; init; }
}
