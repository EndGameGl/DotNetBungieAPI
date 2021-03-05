using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.Places;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Destinations
{
    /// <summary>
    /// On to one of the more confusing subjects of the API. What is a Destination, and what is the relationship between it, Activities, Locations, and Places?
    /// <para />
    /// A "Destination" is a specific region/city/area of a larger "Place". For instance, a Place might be Earth where a Destination might be Bellevue, Washington. (Please, pick a more interesting destination if you come to visit Earth).
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyDestinationDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyDestinationDefinition : IDestinyDefinition, IDeepEquatable<DestinyDestinationDefinition>
    {
        /// <summary>
        /// If the Destination has default Activity Graphs (i.e. "Map") that should be shown in the director, this is the list of those Graphs. At most, only one should be active at any given time for a Destination: these would represent, for example, different variants on a Map if the Destination is changing on a macro level based on game state.
        /// </summary>
        public ReadOnlyCollection<DestinationActivityGraphEntry> ActivityGraphEntries { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// If this Destination has a default Free-Roam activity, this is the Activity. 
        /// </summary>
        public DefinitionHashPointer<DestinyActivityDefinition> DefaultFreeroamActivity { get; }
        /// <summary>
        /// This provides the unique identifiers for every bubble in the destination (only guaranteed unique within the destination), and any intrinsic properties of the bubble.
        /// </summary>
        public ReadOnlyCollection<DestinationBubbleEntry> Bubbles { get; }
        [Obsolete("DEPRECATED - Just use bubbles, it now has this data.")]
        public ReadOnlyCollection<DestinationBubbleSettingsEntry> BubbleSettings { get; }
        /// <summary>
        /// The place that "owns" this Destination.
        /// </summary>
        public DefinitionHashPointer<DestinyPlaceDefinition> Place { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyDestinationDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinationActivityGraphEntry[] activityGraphEntries, uint defaultFreeroamActivityHash,
            DestinationBubbleEntry[] bubbles, DestinationBubbleSettingsEntry[] bubbleSettings, uint? placeHash,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            ActivityGraphEntries = activityGraphEntries.AsReadOnlyOrEmpty();
            DefaultFreeroamActivity = new DefinitionHashPointer<DestinyActivityDefinition>(defaultFreeroamActivityHash, DefinitionsEnum.DestinyActivityDefinition);
            Bubbles = bubbles.AsReadOnlyOrEmpty();
            BubbleSettings = bubbleSettings.AsReadOnlyOrEmpty();
            Place = new DefinitionHashPointer<DestinyPlaceDefinition>(placeHash, DefinitionsEnum.DestinyPlaceDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyDestinationDefinition other)
        {
            return other != null &&
                   ActivityGraphEntries.DeepEqualsReadOnlyCollections(other.ActivityGraphEntries) &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   DefaultFreeroamActivity.DeepEquals(other.DefaultFreeroamActivity) &&
                   Bubbles.DeepEqualsReadOnlyCollections(other.Bubbles) &&
                   //EqualityComparer<ReadOnlyCollection<DestinationBubbleSettingsEntry>>.Default.Equals(BubbleSettings, other.BubbleSettings) &&
                   Place.DeepEquals(other.Place) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var activityGraphEntry in ActivityGraphEntries)
            {
                activityGraphEntry.ActivityGraph.TryMapValue();
            }
            DefaultFreeroamActivity.TryMapValue();
            Place.TryMapValue();
        }
    }
}
