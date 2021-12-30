using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyEntitySearchResult
{

    [JsonPropertyName("suggestedWords")]
    public List<string> SuggestedWords { get; init; }

    [JsonPropertyName("results")]
    public SearchResultOfDestinyEntitySearchResultItem Results { get; init; }
}
