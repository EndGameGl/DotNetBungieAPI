namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

/// <summary>
///     Represents a Seasonal Artifact and all data related to it for the requested Account.
/// <para />
///     It can be combined with Character-scoped data for a full picture of what a character has available/has chosen, or just these settings can be used for overview information.
/// </summary>
public class DestinyArtifactProfileScoped : IDeepEquatable<DestinyArtifactProfileScoped>
{
    [JsonPropertyName("artifactHash")]
    public uint ArtifactHash { get; set; }

    [JsonPropertyName("pointProgression")]
    public Destiny.DestinyProgression PointProgression { get; set; }

    [JsonPropertyName("pointsAcquired")]
    public int PointsAcquired { get; set; }

    [JsonPropertyName("powerBonusProgression")]
    public Destiny.DestinyProgression PowerBonusProgression { get; set; }

    [JsonPropertyName("powerBonus")]
    public int PowerBonus { get; set; }

    public bool DeepEquals(DestinyArtifactProfileScoped? other)
    {
        return other is not null &&
               ArtifactHash == other.ArtifactHash &&
               (PointProgression is not null ? PointProgression.DeepEquals(other.PointProgression) : other.PointProgression is null) &&
               PointsAcquired == other.PointsAcquired &&
               (PowerBonusProgression is not null ? PowerBonusProgression.DeepEquals(other.PowerBonusProgression) : other.PowerBonusProgression is null) &&
               PowerBonus == other.PowerBonus;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArtifactProfileScoped? other)
    {
        if (other is null) return;
        if (ArtifactHash != other.ArtifactHash)
        {
            ArtifactHash = other.ArtifactHash;
            OnPropertyChanged(nameof(ArtifactHash));
        }
        if (!PointProgression.DeepEquals(other.PointProgression))
        {
            PointProgression.Update(other.PointProgression);
            OnPropertyChanged(nameof(PointProgression));
        }
        if (PointsAcquired != other.PointsAcquired)
        {
            PointsAcquired = other.PointsAcquired;
            OnPropertyChanged(nameof(PointsAcquired));
        }
        if (!PowerBonusProgression.DeepEquals(other.PowerBonusProgression))
        {
            PowerBonusProgression.Update(other.PowerBonusProgression);
            OnPropertyChanged(nameof(PowerBonusProgression));
        }
        if (PowerBonus != other.PowerBonus)
        {
            PowerBonus = other.PowerBonus;
            OnPropertyChanged(nameof(PowerBonus));
        }
    }
}