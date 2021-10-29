using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.TalentGrids;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     This defines information that can only come from a talent grid on an item. Items mostly have negligible talent grid
    ///     data these days, but instanced items still retain grids as a source for some of this common information.
    ///     <para />
    ///     Builds/Subclasses are the only items left that still have talent grids with meaningful Nodes.
    /// </summary>
    public sealed record DestinyItemTalentGridBlockDefinition : IDeepEquatable<DestinyItemTalentGridBlockDefinition>
    {
        /// <summary>
        ///     If the talent grid implies a damage type, this is the enum value for that damage type.
        /// </summary>
        [JsonPropertyName("hudDamageType")]
        public DamageType HudDamageType { get; init; }

        /// <summary>
        ///     This is meant to be a subtitle for looking at the talent grid. In practice, somewhat frustratingly, this always
        ///     merely says the localized word for "Details". Great. Maybe it'll have more if talent grids ever get used for more
        ///     than builds and subclasses again.
        /// </summary>
        [JsonPropertyName("itemDetailString")]
        public string ItemDetailString { get; init; }

        /// <summary>
        ///     DestinyTalentGridDefinition attached to this item.
        /// </summary>
        [JsonPropertyName("talentGridHash")]
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; init; } =
            DefinitionHashPointer<DestinyTalentGridDefinition>.Empty;

        /// <summary>
        ///     A shortcut string identifier for the "build" in question, if this talent grid has an associated build. Doesn't map
        ///     to anything we can expose at the moment.
        /// </summary>
        [JsonPropertyName("buildName")]
        public string BuildName { get; init; }

        /// <summary>
        ///     If the talent grid has a special icon that's shown in the game UI (like builds, funny that), this is the identifier
        ///     for that icon. Sadly, we don't actually get that icon right now. I'll be looking to replace this with a path to the
        ///     actual icon itself.
        /// </summary>
        [JsonPropertyName("hudIcon")]
        public BungieNetResource HudIcon { get; init; }

        public bool DeepEquals(DestinyItemTalentGridBlockDefinition other)
        {
            return other != null &&
                   HudDamageType == other.HudDamageType &&
                   ItemDetailString == other.ItemDetailString &&
                   TalentGrid.DeepEquals(other.TalentGrid) &&
                   BuildName == other.BuildName &&
                   HudIcon == other.HudIcon;
        }
    }
}