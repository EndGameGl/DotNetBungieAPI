namespace DotNetBungieAPI.Generated.Models.Queries;

public sealed class PagedQuery
{

    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; init; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; init; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; init; }
}
