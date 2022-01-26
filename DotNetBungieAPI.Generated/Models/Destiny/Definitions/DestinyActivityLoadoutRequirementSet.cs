namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirementSet : IDeepEquatable<DestinyActivityLoadoutRequirementSet>
{
    /// <summary>
    ///     The set of requirements that will be applied on the activity if this requirement set is active.
    /// </summary>
    [JsonPropertyName("requirements")]
    public List<Destiny.Definitions.DestinyActivityLoadoutRequirement> Requirements { get; set; }

    public bool DeepEquals(DestinyActivityLoadoutRequirementSet? other)
    {
        return other is not null &&
               Requirements.DeepEqualsList(other.Requirements);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityLoadoutRequirementSet? other)
    {
        if (other is null) return;
        if (!Requirements.DeepEqualsList(other.Requirements))
        {
            Requirements = other.Requirements;
            OnPropertyChanged(nameof(Requirements));
        }
    }
}