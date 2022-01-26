namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactTier : IDeepEquatable<DestinyArtifactTier>
{
    [JsonPropertyName("tierHash")]
    public uint TierHash { get; set; }

    [JsonPropertyName("isUnlocked")]
    public bool IsUnlocked { get; set; }

    [JsonPropertyName("pointsToUnlock")]
    public int PointsToUnlock { get; set; }

    [JsonPropertyName("items")]
    public List<Destiny.Artifacts.DestinyArtifactTierItem> Items { get; set; }

    public bool DeepEquals(DestinyArtifactTier? other)
    {
        return other is not null &&
               TierHash == other.TierHash &&
               IsUnlocked == other.IsUnlocked &&
               PointsToUnlock == other.PointsToUnlock &&
               Items.DeepEqualsList(other.Items);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArtifactTier? other)
    {
        if (other is null) return;
        if (TierHash != other.TierHash)
        {
            TierHash = other.TierHash;
            OnPropertyChanged(nameof(TierHash));
        }
        if (IsUnlocked != other.IsUnlocked)
        {
            IsUnlocked = other.IsUnlocked;
            OnPropertyChanged(nameof(IsUnlocked));
        }
        if (PointsToUnlock != other.PointsToUnlock)
        {
            PointsToUnlock = other.PointsToUnlock;
            OnPropertyChanged(nameof(PointsToUnlock));
        }
        if (!Items.DeepEqualsList(other.Items))
        {
            Items = other.Items;
            OnPropertyChanged(nameof(Items));
        }
    }
}