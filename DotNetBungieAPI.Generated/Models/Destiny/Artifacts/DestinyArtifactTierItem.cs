namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactTierItem : IDeepEquatable<DestinyArtifactTierItem>
{
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    public bool DeepEquals(DestinyArtifactTierItem? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash &&
               IsActive == other.IsActive;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArtifactTierItem? other)
    {
        if (other is null) return;
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (IsActive != other.IsActive)
        {
            IsActive = other.IsActive;
            OnPropertyChanged(nameof(IsActive));
        }
    }
}