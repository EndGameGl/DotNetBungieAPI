using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupMembershipSearchResponse
{

    [JsonPropertyName("results")]
    public List<GroupsV2.GroupMembership> Results { get; init; }

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
