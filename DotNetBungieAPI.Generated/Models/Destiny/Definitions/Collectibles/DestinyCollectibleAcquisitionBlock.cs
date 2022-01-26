namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public class DestinyCollectibleAcquisitionBlock : IDeepEquatable<DestinyCollectibleAcquisitionBlock>
{
    [JsonPropertyName("acquireMaterialRequirementHash")]
    public uint? AcquireMaterialRequirementHash { get; set; }

    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    public uint? AcquireTimestampUnlockValueHash { get; set; }

    public bool DeepEquals(DestinyCollectibleAcquisitionBlock? other)
    {
        return other is not null &&
               AcquireMaterialRequirementHash == other.AcquireMaterialRequirementHash &&
               AcquireTimestampUnlockValueHash == other.AcquireTimestampUnlockValueHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCollectibleAcquisitionBlock? other)
    {
        if (other is null) return;
        if (AcquireMaterialRequirementHash != other.AcquireMaterialRequirementHash)
        {
            AcquireMaterialRequirementHash = other.AcquireMaterialRequirementHash;
            OnPropertyChanged(nameof(AcquireMaterialRequirementHash));
        }
        if (AcquireTimestampUnlockValueHash != other.AcquireTimestampUnlockValueHash)
        {
            AcquireTimestampUnlockValueHash = other.AcquireTimestampUnlockValueHash;
            OnPropertyChanged(nameof(AcquireTimestampUnlockValueHash));
        }
    }
}