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
public class GroupQuery : IDeepEquatable<GroupQuery>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; set; }

    [JsonPropertyName("creationDate")]
    public GroupsV2.GroupDateRange CreationDate { get; set; }

    [JsonPropertyName("sortBy")]
    public GroupsV2.GroupSortBy SortBy { get; set; }

    [JsonPropertyName("groupMemberCountFilter")]
    public int? GroupMemberCountFilter { get; set; }

    [JsonPropertyName("localeFilter")]
    public string LocaleFilter { get; set; }

    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; set; }

    public bool DeepEquals(GroupQuery? other)
    {
        return other is not null &&
               Name == other.Name &&
               GroupType == other.GroupType &&
               CreationDate == other.CreationDate &&
               SortBy == other.SortBy &&
               GroupMemberCountFilter == other.GroupMemberCountFilter &&
               LocaleFilter == other.LocaleFilter &&
               TagText == other.TagText &&
               ItemsPerPage == other.ItemsPerPage &&
               CurrentPage == other.CurrentPage &&
               RequestContinuationToken == other.RequestContinuationToken;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupQuery? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (GroupType != other.GroupType)
        {
            GroupType = other.GroupType;
            OnPropertyChanged(nameof(GroupType));
        }
        if (CreationDate != other.CreationDate)
        {
            CreationDate = other.CreationDate;
            OnPropertyChanged(nameof(CreationDate));
        }
        if (SortBy != other.SortBy)
        {
            SortBy = other.SortBy;
            OnPropertyChanged(nameof(SortBy));
        }
        if (GroupMemberCountFilter != other.GroupMemberCountFilter)
        {
            GroupMemberCountFilter = other.GroupMemberCountFilter;
            OnPropertyChanged(nameof(GroupMemberCountFilter));
        }
        if (LocaleFilter != other.LocaleFilter)
        {
            LocaleFilter = other.LocaleFilter;
            OnPropertyChanged(nameof(LocaleFilter));
        }
        if (TagText != other.TagText)
        {
            TagText = other.TagText;
            OnPropertyChanged(nameof(TagText));
        }
        if (ItemsPerPage != other.ItemsPerPage)
        {
            ItemsPerPage = other.ItemsPerPage;
            OnPropertyChanged(nameof(ItemsPerPage));
        }
        if (CurrentPage != other.CurrentPage)
        {
            CurrentPage = other.CurrentPage;
            OnPropertyChanged(nameof(CurrentPage));
        }
        if (RequestContinuationToken != other.RequestContinuationToken)
        {
            RequestContinuationToken = other.RequestContinuationToken;
            OnPropertyChanged(nameof(RequestContinuationToken));
        }
    }
}