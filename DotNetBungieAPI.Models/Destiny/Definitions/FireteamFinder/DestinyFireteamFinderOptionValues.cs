using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyFireteamFinderOptionValues
{
    [JsonPropertyName("optionalNull")]
    public DestinyDisplayPropertiesDefinition OptionalNull { get; init; }

    [JsonPropertyName("optionalFormatString")]
    public string OptionalFormatString { get; init; }

    [JsonPropertyName("displayFormatType")]
    public FireteamFinderOptionDisplayFormat DisplayFormatType { get; init; }

    [JsonPropertyName("type")]
    public FireteamFinderOptionValueProviderType Type { get; init; }

    [JsonPropertyName("valueDefinitions")]
    public ReadOnlyCollection<DestinyFireteamFinderOptionValueDefinition> ValueDefinitions { get; init; } =
        ReadOnlyCollections<DestinyFireteamFinderOptionValueDefinition>.Empty;
}
