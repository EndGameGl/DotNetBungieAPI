namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GetGroupsForMemberResponse : IDeepEquatable<GetGroupsForMemberResponse>
{
    /// <summary>
    ///     A convenience property that indicates if every membership this user has that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
    /// <para />
    ///      The key is the Group ID for the group being checked, and the value is true if the users' memberships for that group are all inactive.
    /// </summary>
    [JsonPropertyName("areAllMembershipsInactive")]
    public Dictionary<long, bool> AreAllMembershipsInactive { get; set; }

    [JsonPropertyName("results")]
    public List<GroupsV2.GroupMembership> Results { get; set; }

    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery Query { get; set; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; set; }

    /// <summary>
    ///     If useTotalResults is true, then totalResults represents an accurate count.
    /// <para />
    ///     If False, it does not, and may be estimated/only the size of the current page.
    /// <para />
    ///     Either way, you should probably always only trust hasMore.
    /// <para />
    ///     This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
    /// </summary>
    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; set; }

    public bool DeepEquals(GetGroupsForMemberResponse? other)
    {
        return other is not null &&
               AreAllMembershipsInactive.DeepEqualsDictionaryNaive(other.AreAllMembershipsInactive) &&
               Results.DeepEqualsList(other.Results) &&
               TotalResults == other.TotalResults &&
               HasMore == other.HasMore &&
               (Query is not null ? Query.DeepEquals(other.Query) : other.Query is null) &&
               ReplacementContinuationToken == other.ReplacementContinuationToken &&
               UseTotalResults == other.UseTotalResults;
    }
}