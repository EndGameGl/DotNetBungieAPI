namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines the conditions under which an intrinsic perk is applied while participating in an Objective.
/// <para />
///     These perks will generally not be benefit-granting perks, but rather a perk that modifies gameplay in some interesting way.
/// </summary>
public class DestinyObjectivePerkEntryDefinition : IDeepEquatable<DestinyObjectivePerkEntryDefinition>
{
    /// <summary>
    ///     The hash identifier of the DestinySandboxPerkDefinition that will be applied to the character.
    /// </summary>
    [JsonPropertyName("perkHash")]
    public uint PerkHash { get; set; }

    /// <summary>
    ///     An enumeration indicating whether it will be applied as long as the Objective is active, when it's completed, or until it's completed.
    /// </summary>
    [JsonPropertyName("style")]
    public Destiny.DestinyObjectiveGrantStyle Style { get; set; }

    public bool DeepEquals(DestinyObjectivePerkEntryDefinition? other)
    {
        return other is not null &&
               PerkHash == other.PerkHash &&
               Style == other.Style;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyObjectivePerkEntryDefinition? other)
    {
        if (other is null) return;
        if (PerkHash != other.PerkHash)
        {
            PerkHash = other.PerkHash;
            OnPropertyChanged(nameof(PerkHash));
        }
        if (Style != other.Style)
        {
            Style = other.Style;
            OnPropertyChanged(nameof(Style));
        }
    }
}