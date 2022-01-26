namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines the conditions under which stat modifications will be applied to a Character while participating in an objective.
/// </summary>
public class DestinyObjectiveStatEntryDefinition : IDeepEquatable<DestinyObjectiveStatEntryDefinition>
{
    /// <summary>
    ///     The stat being modified, and the value used.
    /// </summary>
    [JsonPropertyName("stat")]
    public Destiny.Definitions.DestinyItemInvestmentStatDefinition Stat { get; set; }

    /// <summary>
    ///     Whether it will be applied as long as the objective is active, when it's completed, or until it's completed.
    /// </summary>
    [JsonPropertyName("style")]
    public Destiny.DestinyObjectiveGrantStyle Style { get; set; }

    public bool DeepEquals(DestinyObjectiveStatEntryDefinition? other)
    {
        return other is not null &&
               (Stat is not null ? Stat.DeepEquals(other.Stat) : other.Stat is null) &&
               Style == other.Style;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyObjectiveStatEntryDefinition? other)
    {
        if (other is null) return;
        if (!Stat.DeepEquals(other.Stat))
        {
            Stat.Update(other.Stat);
            OnPropertyChanged(nameof(Stat));
        }
        if (Style != other.Style)
        {
            Style = other.Style;
            OnPropertyChanged(nameof(Style));
        }
    }
}