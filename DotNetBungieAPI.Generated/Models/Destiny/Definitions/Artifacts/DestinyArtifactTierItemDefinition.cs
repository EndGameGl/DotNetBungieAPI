namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

public class DestinyArtifactTierItemDefinition : IDeepEquatable<DestinyArtifactTierItemDefinition>
{
    /// <summary>
    ///     The identifier of the Plug Item unlocked by activating this item in the Artifact.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    public bool DeepEquals(DestinyArtifactTierItemDefinition? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArtifactTierItemDefinition? other)
    {
        if (other is null) return;
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
    }
}