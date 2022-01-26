namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This appears to be information used when rendering rewards. We don't currently use it on BNet.
/// </summary>
public class DestinyItemSummaryBlockDefinition : IDeepEquatable<DestinyItemSummaryBlockDefinition>
{
    /// <summary>
    ///     Apparently when rendering an item in a reward, this should be used as a sort priority. We're not doing it presently.
    /// </summary>
    [JsonPropertyName("sortPriority")]
    public int SortPriority { get; set; }

    public bool DeepEquals(DestinyItemSummaryBlockDefinition? other)
    {
        return other is not null &&
               SortPriority == other.SortPriority;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSummaryBlockDefinition? other)
    {
        if (other is null) return;
        if (SortPriority != other.SortPriority)
        {
            SortPriority = other.SortPriority;
            OnPropertyChanged(nameof(SortPriority));
        }
    }
}