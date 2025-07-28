namespace DotNetBungieAPI.Generated.Models.Queries;

public class PagedQuery
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; set; }
}
