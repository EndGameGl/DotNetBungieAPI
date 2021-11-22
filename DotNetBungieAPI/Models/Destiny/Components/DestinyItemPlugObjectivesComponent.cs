using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemPlugObjectivesComponent
    {
        /// <summary>
        ///     This set of data is keyed by the Item Hash (DestinyInventoryItemDefinition) of the plug whose objectives are being
        ///     returned, with the value being the list of those objectives.
        ///     <para />
        ///     What if two plugs with the same hash are returned for an item, you ask?
        ///     <para />
        ///     Good question! They share the same item-scoped state, and as such would have identical objective state as a result.
        ///     How's that for convenient.
        ///     <para />
        ///     Sometimes, Plugs may have objectives: generally, these are used for flavor and display purposes. For instance, a
        ///     Plug might be tracking the number of PVP kills you have made. It will use the parent item's data about that
        ///     tracking status to determine what to show, and will generally show it using the DestinyObjectiveDefinition's
        ///     progressDescription property. Refer to the plug's itemHash and objective property for more information if you would
        ///     like to display even more data.
        /// </summary>
        [JsonPropertyName("objectivesPerPlug")]
        public
            ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>,
                ReadOnlyCollection<DestinyObjectiveProgress>> ObjectivesPerPlug
        { get; init; } =
            ReadOnlyDictionaries<DefinitionHashPointer<DestinyInventoryItemDefinition>,
                ReadOnlyCollection<DestinyObjectiveProgress>>.Empty;
    }
}