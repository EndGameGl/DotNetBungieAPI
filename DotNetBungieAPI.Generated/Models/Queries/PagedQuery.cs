namespace DotNetBungieAPI.Generated.Models.Queries;

public class PagedQuery : IDeepEquatable<PagedQuery>
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; set; }

    public bool DeepEquals(PagedQuery? other)
    {
        return other is not null &&
               ItemsPerPage == other.ItemsPerPage &&
               CurrentPage == other.CurrentPage &&
               RequestContinuationToken == other.RequestContinuationToken;
    }
}