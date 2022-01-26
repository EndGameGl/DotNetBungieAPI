namespace DotNetBungieAPI.Generated.Models.Applications;

public class ApiUsage : IDeepEquatable<ApiUsage>
{
    /// <summary>
    ///     Counts for on API calls made for the time range.
    /// </summary>
    [JsonPropertyName("apiCalls")]
    public List<Applications.Series> ApiCalls { get; set; }

    /// <summary>
    ///     Instances of blocked requests or requests that crossed the warn threshold during the time range.
    /// </summary>
    [JsonPropertyName("throttledRequests")]
    public List<Applications.Series> ThrottledRequests { get; set; }

    public bool DeepEquals(ApiUsage? other)
    {
        return other is not null &&
               ApiCalls.DeepEqualsList(other.ApiCalls) &&
               ThrottledRequests.DeepEqualsList(other.ThrottledRequests);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ApiUsage? other)
    {
        if (other is null) return;
        if (!ApiCalls.DeepEqualsList(other.ApiCalls))
        {
            ApiCalls = other.ApiCalls;
            OnPropertyChanged(nameof(ApiCalls));
        }
        if (!ThrottledRequests.DeepEqualsList(other.ThrottledRequests))
        {
            ThrottledRequests = other.ThrottledRequests;
            OnPropertyChanged(nameof(ThrottledRequests));
        }
    }
}