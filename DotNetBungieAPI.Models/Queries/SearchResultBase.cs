namespace DotNetBungieAPI.Models.Queries;

public abstract record SearchResultBase
{
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; init; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }

    [JsonPropertyName("query")]
    public PagedQuery Query { get; init; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; init; }

    /// <summary>
    ///     If useTotalResults is true, then totalResults represents an accurate count.
    ///     <para />
    ///     If False, it does not, and may be estimated/only the size of the current page.
    ///     <para />
    ///     Either way, you should probably always only trust hasMore.
    /// </summary>
    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; init; }
}
