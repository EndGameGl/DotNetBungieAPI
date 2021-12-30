using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupQuery
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; init; }

    [JsonPropertyName("creationDate")]
    public GroupsV2.GroupDateRange CreationDate { get; init; }

    [JsonPropertyName("sortBy")]
    public GroupsV2.GroupSortBy SortBy { get; init; }

    [JsonPropertyName("groupMemberCountFilter")]
    public int? GroupMemberCountFilter { get; init; }

    [JsonPropertyName("localeFilter")]
    public string LocaleFilter { get; init; }

    [JsonPropertyName("tagText")]
    public string TagText { get; init; }

    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; init; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; init; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; init; }
}
