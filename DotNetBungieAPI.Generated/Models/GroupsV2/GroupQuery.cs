using System.Text.Json.Serialization;

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
