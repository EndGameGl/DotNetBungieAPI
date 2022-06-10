namespace DotNetBungieAPI.Generated.Models.GroupsV2;

/// <summary>
///     NOTE: GroupQuery, as of Destiny 2, has essentially two totally different and incompatible "modes".
/// <para />
///     If you are querying for a group, you can pass any of the properties below.
/// <para />
///     If you are querying for a Clan, you MUST NOT pass any of the following properties (they must be null or undefined in your request, not just empty string/default values):
/// <para />
///     - groupMemberCountFilter - localeFilter - tagText
/// <para />
///     If you pass these, you will get a useless InvalidParameters error.
/// </summary>
public class GroupQuery
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType? GroupType { get; set; }

    [JsonPropertyName("creationDate")]
    public GroupsV2.GroupDateRange? CreationDate { get; set; }

    [JsonPropertyName("sortBy")]
    public GroupsV2.GroupSortBy? SortBy { get; set; }

    [JsonPropertyName("groupMemberCountFilter")]
    public int? GroupMemberCountFilter { get; set; }

    [JsonPropertyName("localeFilter")]
    public string? LocaleFilter { get; set; }

    [JsonPropertyName("tagText")]
    public string? TagText { get; set; }

    [JsonPropertyName("itemsPerPage")]
    public int? ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("requestContinuationToken")]
    public string? RequestContinuationToken { get; set; }
}
