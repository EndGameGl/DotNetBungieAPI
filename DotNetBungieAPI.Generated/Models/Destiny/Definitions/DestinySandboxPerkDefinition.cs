namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Perks are modifiers to a character or item that can be applied situationally.
/// <para />
///     - Perks determine a weapons' damage type.
/// <para />
///     - Perks put the Mods in Modifiers (they are literally the entity that bestows the Sandbox benefit for whatever fluff text about the modifier in the Socket, Plug or Talent Node)
/// <para />
///     - Perks are applied for unique alterations of state in Objectives
/// <para />
///     Anyways, I'm sure you can see why perks are so interesting.
/// <para />
///     What Perks often don't have is human readable information, so we attempt to reverse engineer that by pulling that data from places that uniquely refer to these perks: namely, Talent Nodes and Plugs. That only gives us a subset of perks that are human readable, but those perks are the ones people generally care about anyways. The others are left as a mystery, their true purpose mostly unknown and undocumented.
/// </summary>
public class DestinySandboxPerkDefinition : IDeepEquatable<DestinySandboxPerkDefinition>
{
    /// <summary>
    ///     These display properties are by no means guaranteed to be populated. Usually when it is, it's only because we back-filled them with the displayProperties of some Talent Node or Plug item that happened to be uniquely providing that perk.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The string identifier for the perk.
    /// </summary>
    [JsonPropertyName("perkIdentifier")]
    public string PerkIdentifier { get; set; }

    /// <summary>
    ///     If true, you can actually show the perk in the UI. Otherwise, it doesn't have useful player-facing information.
    /// </summary>
    [JsonPropertyName("isDisplayable")]
    public bool IsDisplayable { get; set; }

    /// <summary>
    ///     If this perk grants a damage type to a weapon, the damage type will be defined here.
    /// <para />
    ///     Unless you have a compelling reason to use this enum value, use the damageTypeHash instead to look up the actual DestinyDamageTypeDefinition.
    /// </summary>
    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; set; }

    /// <summary>
    ///     The hash identifier for looking up the DestinyDamageTypeDefinition, if this perk has a damage type.
    /// <para />
    ///     This is preferred over using the damageType enumeration value, which has been left purely because it is occasionally convenient.
    /// </summary>
    [JsonPropertyName("damageTypeHash")]
    public uint? DamageTypeHash { get; set; }

    /// <summary>
    ///     An old holdover from the original Armory, this was an attempt to group perks by functionality.
    /// <para />
    ///     It is as yet unpopulated, and there will be quite a bit of work needed to restore it to its former working order.
    /// </summary>
    [JsonPropertyName("perkGroups")]
    public Destiny.Definitions.DestinyTalentNodeStepGroups PerkGroups { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinySandboxPerkDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               PerkIdentifier == other.PerkIdentifier &&
               IsDisplayable == other.IsDisplayable &&
               DamageType == other.DamageType &&
               DamageTypeHash == other.DamageTypeHash &&
               (PerkGroups is not null ? PerkGroups.DeepEquals(other.PerkGroups) : other.PerkGroups is null) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinySandboxPerkDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (PerkIdentifier != other.PerkIdentifier)
        {
            PerkIdentifier = other.PerkIdentifier;
            OnPropertyChanged(nameof(PerkIdentifier));
        }
        if (IsDisplayable != other.IsDisplayable)
        {
            IsDisplayable = other.IsDisplayable;
            OnPropertyChanged(nameof(IsDisplayable));
        }
        if (DamageType != other.DamageType)
        {
            DamageType = other.DamageType;
            OnPropertyChanged(nameof(DamageType));
        }
        if (DamageTypeHash != other.DamageTypeHash)
        {
            DamageTypeHash = other.DamageTypeHash;
            OnPropertyChanged(nameof(DamageTypeHash));
        }
        if (!PerkGroups.DeepEquals(other.PerkGroups))
        {
            PerkGroups.Update(other.PerkGroups);
            OnPropertyChanged(nameof(PerkGroups));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}