using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Models.Destiny.Responses
{
    /// <summary>
    ///     The response object for retrieving an individual instanced item. None of these components are relevant for an item
    ///     that doesn't have an "itemInstanceId": for those, get your information from the DestinyInventoryDefinition.
    /// </summary>
    public sealed record DestinyItemResponse
    {
        /// <summary>
        ///     If the item is on a character, this will return the ID of the character that is holding the item
        /// </summary>
        [JsonPropertyName("characterId")]
        public long CharacterId { get; init; }

        /// <summary>
        ///     Common data for the item relevant to its non-instanced properties.
        /// </summary>
        [JsonPropertyName("item")]
        public SingleComponentResponseOfDestinyItemComponent Item { get; init; }

        /// <summary>
        ///     Basic instance data for the item.
        /// </summary>
        [JsonPropertyName("instance")]
        public SingleComponentResponseOfDestinyItemInstanceComponent Instance { get; init; }

        /// <summary>
        ///     Information specifically about the item's objectives.
        /// </summary>
        [JsonPropertyName("objectives")]
        public SingleComponentResponseOfDestinyItemObjectivesComponent Objectives { get; init; }

        /// <summary>
        ///     Information specifically about the perks currently active on the item.
        /// </summary>
        [JsonPropertyName("perks")]
        public SingleComponentResponseOfDestinyItemPerksComponent Perks { get; init; }

        /// <summary>
        ///     Information about how to render the item in 3D.
        /// </summary>
        [JsonPropertyName("renderData")]
        public SingleComponentResponseOfDestinyItemRenderComponent RenderData { get; init; }

        /// <summary>
        ///     Information about the computed stats of the item: power, defense, etc...
        /// </summary>
        [JsonPropertyName("stats")]
        public SingleComponentResponseOfDestinyItemStatsComponent Stats { get; init; }

        /// <summary>
        ///     Information about the talent grid attached to the item. Talent nodes can provide a variety of benefits and
        ///     abilities, and in Destiny 2 are used almost exclusively for the character's "Builds".
        /// </summary>
        [JsonPropertyName("talentGrid")]
        public SingleComponentResponseOfDestinyItemTalentGridComponent TalentGrid { get; init; }

        /// <summary>
        ///     Information about the sockets of the item: which are currently active, what potential sockets you could have and
        ///     the stats/abilities/perks you can gain from them.
        /// </summary>
        [JsonPropertyName("sockets")]
        public SingleComponentResponseOfDestinyItemSocketsComponent Sockets { get; init; }

        /// <summary>
        ///     Information about the Reusable Plugs for sockets on an item. These are plugs that you can insert into the given
        ///     socket regardless of if you actually own an instance of that plug: they are logic-driven plugs rather than
        ///     inventory-driven.
        ///     <para />
        ///     These may need to be combined with Plug Set component data to get a full picture of available plugs on a given
        ///     socket.
        /// </summary>
        [JsonPropertyName("reusablePlugs")]
        public SingleComponentResponseOfDestinyItemReusablePlugsComponent ReusablePlugs { get; init; }

        /// <summary>
        ///     Information about objectives on Plugs for a given item. See the component's documentation for more info.
        /// </summary>
        [JsonPropertyName("plugObjectives")]
        public SingleComponentResponseOfDestinyItemPlugObjectivesComponent PlugObjectives { get; init; }
    }
}