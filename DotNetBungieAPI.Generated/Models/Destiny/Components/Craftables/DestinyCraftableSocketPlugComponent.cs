namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftableSocketPlugComponent : IDeepEquatable<DestinyCraftableSocketPlugComponent>
{
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    /// <summary>
    ///     Index into the unlock requirements to display failure descriptions
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public List<int> FailedRequirementIndexes { get; set; }

    public bool DeepEquals(DestinyCraftableSocketPlugComponent? other)
    {
        return other is not null &&
               PlugItemHash == other.PlugItemHash &&
               FailedRequirementIndexes.DeepEqualsListNaive(other.FailedRequirementIndexes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCraftableSocketPlugComponent? other)
    {
        if (other is null) return;
        if (PlugItemHash != other.PlugItemHash)
        {
            PlugItemHash = other.PlugItemHash;
            OnPropertyChanged(nameof(PlugItemHash));
        }
        if (!FailedRequirementIndexes.DeepEqualsListNaive(other.FailedRequirementIndexes))
        {
            FailedRequirementIndexes = other.FailedRequirementIndexes;
            OnPropertyChanged(nameof(FailedRequirementIndexes));
        }
    }
}