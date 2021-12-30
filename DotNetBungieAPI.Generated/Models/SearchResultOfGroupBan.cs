using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class SearchResultOfGroupBan
{

    [JsonPropertyName("results")]
    public List<GroupsV2.GroupBan> Results { get; init; }

    [JsonPropertyName("totalResults")]
    public int TotalResults { get; init; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery Query { get; init; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; init; }

    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; init; }
}
