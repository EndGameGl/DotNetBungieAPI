namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalRewards : IDeepEquatable<DestinyRecordIntervalRewards>
{
    [JsonPropertyName("intervalRewardItems")]
    public List<Destiny.DestinyItemQuantity> IntervalRewardItems { get; set; }

    public bool DeepEquals(DestinyRecordIntervalRewards? other)
    {
        return other is not null &&
               IntervalRewardItems.DeepEqualsList(other.IntervalRewardItems);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordIntervalRewards? other)
    {
        if (other is null) return;
        if (!IntervalRewardItems.DeepEqualsList(other.IntervalRewardItems))
        {
            IntervalRewardItems = other.IntervalRewardItems;
            OnPropertyChanged(nameof(IntervalRewardItems));
        }
    }
}