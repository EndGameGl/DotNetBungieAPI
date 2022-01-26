namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactCharacterScoped : IDeepEquatable<DestinyArtifactCharacterScoped>
{
    [JsonPropertyName("artifactHash")]
    public uint ArtifactHash { get; set; }

    [JsonPropertyName("pointsUsed")]
    public int PointsUsed { get; set; }

    [JsonPropertyName("resetCount")]
    public int ResetCount { get; set; }

    [JsonPropertyName("tiers")]
    public List<Destiny.Artifacts.DestinyArtifactTier> Tiers { get; set; }

    public bool DeepEquals(DestinyArtifactCharacterScoped? other)
    {
        return other is not null &&
               ArtifactHash == other.ArtifactHash &&
               PointsUsed == other.PointsUsed &&
               ResetCount == other.ResetCount &&
               Tiers.DeepEqualsList(other.Tiers);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArtifactCharacterScoped? other)
    {
        if (other is null) return;
        if (ArtifactHash != other.ArtifactHash)
        {
            ArtifactHash = other.ArtifactHash;
            OnPropertyChanged(nameof(ArtifactHash));
        }
        if (PointsUsed != other.PointsUsed)
        {
            PointsUsed = other.PointsUsed;
            OnPropertyChanged(nameof(PointsUsed));
        }
        if (ResetCount != other.ResetCount)
        {
            ResetCount = other.ResetCount;
            OnPropertyChanged(nameof(ResetCount));
        }
        if (!Tiers.DeepEqualsList(other.Tiers))
        {
            Tiers = other.Tiers;
            OnPropertyChanged(nameof(Tiers));
        }
    }
}