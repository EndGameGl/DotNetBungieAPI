using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Quests;

namespace NetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    ///     Plugs are non-instanced items that can provide Stat and Perk benefits when socketed into an instanced item. Items
    ///     have Sockets, and Plugs are inserted into Sockets.
    ///     <para />
    ///     This component finds all items that are considered "Plugs" in your inventory, and return information about the plug
    ///     aside from any specific Socket into which it could be inserted.
    /// </summary>
    public sealed record DestinyItemPlugComponent
    {
        /// <summary>
        ///     Sometimes, Plugs may have objectives: these are often used for flavor and display purposes, but they can be used
        ///     for any arbitrary purpose (both fortunately and unfortunately). Recently (with Season 2) they were expanded in use
        ///     to be used as the "gating" for whether the plug can be inserted at all. For instance, a Plug might be tracking the
        ///     number of PVP kills you have made. It will use the parent item's data about that tracking status to determine what
        ///     to show, and will generally show it using the DestinyObjectiveDefinition's progressDescription property. Refer to
        ///     the plug's itemHash and objective property for more information if you would like to display even more data.
        /// </summary>
        [JsonPropertyName("plugObjectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> PlugObjectives { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();

        /// <summary>
        ///     The hash identifier of the DestinyInventoryItemDefinition that represents this plug.
        /// </summary>
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     If true, this plug has met all of its insertion requirements. Big if true.
        /// </summary>
        [JsonPropertyName("canInsert")]
        public bool CanInsert { get; init; }

        /// <summary>
        ///     If true, this plug will provide its benefits while inserted.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool IsEnabled { get; init; }

        /// <summary>
        ///     If the plug cannot be inserted for some reason, this will have the indexes into the plug item definition's
        ///     plug.insertionRules property, so you can show the reasons why it can't be inserted.
        ///     <para />
        ///     This list will be empty if the plug can be inserted.
        /// </summary>
        [JsonPropertyName("insertFailIndexes")]
        public ReadOnlyCollection<int> InsertFailIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        /// <summary>
        ///     If a plug is not enabled, this will be populated with indexes into the plug item definition's plug.enabledRules
        ///     property, so that you can show the reasons why it is not enabled.
        ///     <para />
        ///     This list will be empty if the plug is enabled.
        /// </summary>
        [JsonPropertyName("enableFailIndexes")]
        public ReadOnlyCollection<int> EnableFailIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
    }
}