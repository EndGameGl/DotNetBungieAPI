using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Locations;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny
{
    public class DestinyEnvironmentLocationMapping : IDeepEquatable<DestinyEnvironmentLocationMapping>
    {
        /// <summary>
        ///     A hint that the UI uses to figure out how this location is activated by the player.
        /// </summary>
        [JsonPropertyName("activationSource")]
        public string ActivationSource { get; init; }

        /// <summary>
        ///     If this is populated, this is the activity you have to be playing in order to see this location appear because of
        ///     this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific
        ///     activity when others don't)
        /// </summary>
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        /// <summary>
        ///     The location that is revealed on the director by this mapping.
        /// </summary>
        [JsonPropertyName("locationHash")]
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; init; } =
            DefinitionHashPointer<DestinyLocationDefinition>.Empty;

        /// <summary>
        ///     If this is populated, it is the item that you must possess for this location to be active because of this mapping.
        ///     (theoretically, a location can have multiple mappings, and some might require an item while others don't)
        /// </summary>
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     If this is populated, this is an objective related to the location.
        /// </summary>
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } =
            DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

        public bool DeepEquals(DestinyEnvironmentLocationMapping other)
        {
            return other != null &&
                   ActivationSource == other.ActivationSource &&
                   Activity.DeepEquals(other.Activity) &&
                   Location.DeepEquals(other.Location) &&
                   Item.DeepEquals(other.Item) &&
                   Objective.DeepEquals(other.Objective);
        }
    }
}