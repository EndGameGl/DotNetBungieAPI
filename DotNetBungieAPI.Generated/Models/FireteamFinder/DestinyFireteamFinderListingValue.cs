namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderListingValue
{
    [JsonPropertyName("valueType")]
    public uint? ValueType { get; set; }

    [JsonPropertyName("values")]
    public List<uint> Values { get; set; }
}
