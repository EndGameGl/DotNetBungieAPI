namespace DotNetBungieAPI.Generated.Models.Forum;

public class PostSearchResponse : IDeepEquatable<PostSearchResponse>
{
    [JsonPropertyName("relatedPosts")]
    public List<Forum.PostResponse> RelatedPosts { get; set; }

    [JsonPropertyName("authors")]
    public List<User.GeneralUser> Authors { get; set; }

    [JsonPropertyName("groups")]
    public List<GroupsV2.GroupResponse> Groups { get; set; }

    [JsonPropertyName("searchedTags")]
    public List<Tags.Models.Contracts.TagResponse> SearchedTags { get; set; }

    [JsonPropertyName("polls")]
    public List<Forum.PollResponse> Polls { get; set; }

    [JsonPropertyName("recruitmentDetails")]
    public List<Forum.ForumRecruitmentDetail> RecruitmentDetails { get; set; }

    [JsonPropertyName("availablePages")]
    public int? AvailablePages { get; set; }

    [JsonPropertyName("results")]
    public List<Forum.PostResponse> Results { get; set; }

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

    public bool DeepEquals(PostSearchResponse? other)
    {
        return other is not null &&
               RelatedPosts.DeepEqualsList(other.RelatedPosts) &&
               Authors.DeepEqualsList(other.Authors) &&
               Groups.DeepEqualsList(other.Groups) &&
               SearchedTags.DeepEqualsList(other.SearchedTags) &&
               Polls.DeepEqualsList(other.Polls) &&
               RecruitmentDetails.DeepEqualsList(other.RecruitmentDetails) &&
               AvailablePages == other.AvailablePages &&
               Results.DeepEqualsList(other.Results) &&
               TotalResults == other.TotalResults &&
               HasMore == other.HasMore &&
               (Query is not null ? Query.DeepEquals(other.Query) : other.Query is null) &&
               ReplacementContinuationToken == other.ReplacementContinuationToken &&
               UseTotalResults == other.UseTotalResults;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PostSearchResponse? other)
    {
        if (other is null) return;
        if (!RelatedPosts.DeepEqualsList(other.RelatedPosts))
        {
            RelatedPosts = other.RelatedPosts;
            OnPropertyChanged(nameof(RelatedPosts));
        }
        if (!Authors.DeepEqualsList(other.Authors))
        {
            Authors = other.Authors;
            OnPropertyChanged(nameof(Authors));
        }
        if (!Groups.DeepEqualsList(other.Groups))
        {
            Groups = other.Groups;
            OnPropertyChanged(nameof(Groups));
        }
        if (!SearchedTags.DeepEqualsList(other.SearchedTags))
        {
            SearchedTags = other.SearchedTags;
            OnPropertyChanged(nameof(SearchedTags));
        }
        if (!Polls.DeepEqualsList(other.Polls))
        {
            Polls = other.Polls;
            OnPropertyChanged(nameof(Polls));
        }
        if (!RecruitmentDetails.DeepEqualsList(other.RecruitmentDetails))
        {
            RecruitmentDetails = other.RecruitmentDetails;
            OnPropertyChanged(nameof(RecruitmentDetails));
        }
        if (AvailablePages != other.AvailablePages)
        {
            AvailablePages = other.AvailablePages;
            OnPropertyChanged(nameof(AvailablePages));
        }
        if (!Results.DeepEqualsList(other.Results))
        {
            Results = other.Results;
            OnPropertyChanged(nameof(Results));
        }
        if (TotalResults != other.TotalResults)
        {
            TotalResults = other.TotalResults;
            OnPropertyChanged(nameof(TotalResults));
        }
        if (HasMore != other.HasMore)
        {
            HasMore = other.HasMore;
            OnPropertyChanged(nameof(HasMore));
        }
        if (!Query.DeepEquals(other.Query))
        {
            Query.Update(other.Query);
            OnPropertyChanged(nameof(Query));
        }
        if (ReplacementContinuationToken != other.ReplacementContinuationToken)
        {
            ReplacementContinuationToken = other.ReplacementContinuationToken;
            OnPropertyChanged(nameof(ReplacementContinuationToken));
        }
        if (UseTotalResults != other.UseTotalResults)
        {
            UseTotalResults = other.UseTotalResults;
            OnPropertyChanged(nameof(UseTotalResults));
        }
    }
}