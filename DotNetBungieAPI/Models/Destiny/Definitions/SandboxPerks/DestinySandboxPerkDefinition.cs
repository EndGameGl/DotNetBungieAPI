using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.DamageTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SandboxPerks
{
    /// <summary>
    ///     Perks are modifiers to a character or item that can be applied situationally.
    ///     <para />
    ///     - Perks determine a weapons' damage type.
    ///     <para />
    ///     - Perks put the Mods in Modifiers (they are literally the entity that bestows the Sandbox benefit for whatever
    ///     fluff text about the modifier in the Socket, Plug or Talent Node)
    ///     <para />
    ///     - Perks are applied for unique alterations of state in Objectives
    ///     <para />
    ///     Anyways, I'm sure you can see why perks are so interesting.
    ///     <para />
    ///     What Perks often don't have is human readable information, so we attempt to reverse engineer that by pulling that
    ///     data from places that uniquely refer to these perks: namely, Talent Nodes and Plugs. That only gives us a subset of
    ///     perks that are human readable, but those perks are the ones people generally care about anyways. The others are
    ///     left as a mystery, their true purpose mostly unknown and undocumented.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinySandboxPerkDefinition)]
    public sealed record DestinySandboxPerkDefinition : IDestinyDefinition, IDeepEquatable<DestinySandboxPerkDefinition>
    {
        /// <summary>
        ///     These display properties are by no means guaranteed to be populated. Usually when it is, it's only because we
        ///     back-filled them with the displayProperties of some Talent Node or Plug item that happened to be uniquely providing
        ///     that perk.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     The string identifier for the perk.
        /// </summary>
        [JsonPropertyName("perkIdentifier")]
        public string PerkIdentifier { get; init; }

        /// <summary>
        ///     If true, you can actually show the perk in the UI. Otherwise, it doesn't have useful player-facing information.
        /// </summary>
        [JsonPropertyName("isDisplayable")]
        public bool IsDisplayable { get; init; }

        /// <summary>
        ///     If this perk grants a damage type to a weapon, the damage type will be defined here.
        ///     <para />
        ///     Unless you have a compelling reason to use this enum value, use the damageTypeHash instead to look up the actual
        ///     DestinyDamageTypeDefinition.
        /// </summary>
        [JsonPropertyName("damageType")]
        public DamageType DamageTypeEnumValue { get; init; }

        /// <summary>
        ///     DestinyDamageTypeDefinition, if this perk has a damage type.
        ///     <para />
        ///     This is preferred over using the damageType enumeration value, which has been left purely because it is
        ///     occasionally convenient.
        /// </summary>
        [JsonPropertyName("damageTypeHash")]
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; } =
            DefinitionHashPointer<DestinyDamageTypeDefinition>.Empty;

        /// <summary>
        ///     An old holdover from the original Armory, this was an attempt to group perks by functionality.
        ///     <para />
        ///     It is as yet unpopulated, and there will be quite a bit of work needed to restore it to its former working order.
        /// </summary>
        [JsonPropertyName("perkGroups")]
        public DestinyTalentNodeStepGroups PerkGroups { get; init; }

        public bool DeepEquals(DestinySandboxPerkDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   DamageTypeEnumValue == other.DamageTypeEnumValue &&
                   DamageType.DeepEquals(other.DamageType) &&
                   IsDisplayable == other.IsDisplayable &&
                   PerkIdentifier == other.PerkIdentifier &&
                   PerkGroups.DeepEquals(other.PerkGroups) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySandboxPerkDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            DamageType.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            DamageType.SetLocale(locale);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}