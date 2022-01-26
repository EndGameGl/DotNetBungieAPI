namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     An intrinsic perk on an item, and the requirements for it to be activated.
/// </summary>
public class DestinyItemPerkEntryDefinition : IDeepEquatable<DestinyItemPerkEntryDefinition>
{
    /// <summary>
    ///     If this perk is not active, this is the string to show for why it's not providing its benefits.
    /// </summary>
    [JsonPropertyName("requirementDisplayString")]
    public string RequirementDisplayString { get; set; }

    /// <summary>
    ///     A hash identifier for the DestinySandboxPerkDefinition being provided on the item.
    /// </summary>
    [JsonPropertyName("perkHash")]
    public uint PerkHash { get; set; }

    /// <summary>
    ///     Indicates whether this perk should be shown, or if it should be shown disabled.
    /// </summary>
    [JsonPropertyName("perkVisibility")]
    public Destiny.ItemPerkVisibility PerkVisibility { get; set; }

    public bool DeepEquals(DestinyItemPerkEntryDefinition? other)
    {
        return other is not null &&
               RequirementDisplayString == other.RequirementDisplayString &&
               PerkHash == other.PerkHash &&
               PerkVisibility == other.PerkVisibility;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemPerkEntryDefinition? other)
    {
        if (other is null) return;
        if (RequirementDisplayString != other.RequirementDisplayString)
        {
            RequirementDisplayString = other.RequirementDisplayString;
            OnPropertyChanged(nameof(RequirementDisplayString));
        }
        if (PerkHash != other.PerkHash)
        {
            PerkHash = other.PerkHash;
            OnPropertyChanged(nameof(PerkHash));
        }
        if (PerkVisibility != other.PerkVisibility)
        {
            PerkVisibility = other.PerkVisibility;
            OnPropertyChanged(nameof(PerkVisibility));
        }
    }
}