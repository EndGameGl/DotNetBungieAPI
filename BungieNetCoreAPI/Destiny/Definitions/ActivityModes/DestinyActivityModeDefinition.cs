using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.Activities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.ActivityModes
{
    /// <summary>
    /// This definition represents an "Activity Mode" as it exists in the Historical Stats endpoints. An individual Activity Mode represents a collection of activities that are played in a certain way. For example, Nightfall Strikes are part of a "Nightfall" activity mode, and any activities played as the PVP mode "Clash" are part of the "Clash activity mode.
    /// <para/>
    /// Activity modes are nested under each other in a hierarchy, so that if you ask for - for example - "AllPvP", you will get any PVP activities that the user has played, regardless of what specific PVP mode was being played.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyActivityModeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyActivityModeDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityModeDefinition>
    {
        /// <summary>
        /// The type of play being performed in broad terms (PVP, PVE)
        /// </summary>
        public ActivityModeCategory ActivityModeCategory { get; }
        /// <summary>
        /// If this exists, the mode has specific Activities (referred to by the Key) that should instead map to other Activity Modes when they are played.
        /// </summary>
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, DestinyActivityModeType> ActivityModeMappings { get; }
        /// <summary>
        /// If FALSE, we want to ignore this type when we're showing activity modes in BNet UI. It will still be returned in case 3rd parties want to use it for any purpose.
        /// </summary>
        public bool Display { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// A Friendly identifier you can use for referring to this Activity Mode. We really only used this in our URLs, so... you know, take that for whatever it's worth.
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// If true, this mode is an aggregation of other, more specific modes rather than being a mode in itself. This includes modes that group Features/Events rather than Gameplay, such as Trials of The Nine: Trials of the Nine being an Event that is interesting to see aggregate data for, but when you play the activities within Trials of the Nine they are more specific activity modes such as Clash.
        /// </summary>
        public bool IsAggregateMode { get; }
        /// <summary>
        /// If True, this mode has oppositional teams fighting against each other rather than "Free-For-All" or Co-operative modes of play.
        /// <para/>
        /// Note that Aggregate modes are never marked as team based, even if they happen to be team based at the moment.At any time, an aggregate whose subordinates are only team based could be changed so that one or more aren't team based, and then this boolean won't make much sense(the aggregation would become "sometimes team based"). Let's not deal with that right now.
        /// </summary>
        public bool IsTeamBased { get; }
        /// <summary>
        /// The Enumeration value for this Activity Mode. Pass this identifier into Stats endpoints to get aggregate stats for this mode.
        /// </summary>
        public DestinyActivityModeType ModeType { get; }
        /// <summary>
        /// The relative ordering of activity modes.
        /// </summary>
        public int Order { get; }
        /// <summary>
        /// DestinyActivityModeDefinitions that represent all of the "parent" modes for this mode. For instance, the Nightfall Mode is also a member of AllStrikes and AllPvE.
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> ParentModes { get; }
        /// <summary>
        /// If this activity mode has a related PGCR image, this will be the path to said image.
        /// </summary>
        public string PgcrImage { get; }
        public bool SupportsFeedFiltering { get; }
        public int Tier { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyActivityModeDefinition(ActivityModeCategory activityModeCategory, Dictionary<uint, DestinyActivityModeType> activityModeMappings, bool display,
            DestinyDefinitionDisplayProperties displayProperties, string friendlyName, bool isAggregateMode, bool isTeamBased, DestinyActivityModeType modeType, int order,
            uint[] parentHashes, string pgcrImage, bool supportsFeedFiltering, int tier, bool blacklisted, uint hash, int index, bool redacted)
        {
            ActivityModeCategory = activityModeCategory;
            ActivityModeMappings = activityModeMappings.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyActivityDefinition, DestinyActivityModeType>(DefinitionsEnum.DestinyActivityDefinition);
            Display = display;
            DisplayProperties = displayProperties;
            FriendlyName = friendlyName;
            IsAggregateMode = isAggregateMode;
            IsTeamBased = isTeamBased;
            ModeType = modeType;
            Order = order;
            ParentModes = parentHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModeDefinition>(DefinitionsEnum.DestinyActivityModeDefinition);
            PgcrImage = pgcrImage;
            SupportsFeedFiltering = supportsFeedFiltering;
            Tier = tier;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
        public bool DeepEquals(DestinyActivityModeDefinition other)
        {
            return other != null &&
                   ActivityModeCategory == other.ActivityModeCategory &&
                   ActivityModeMappings.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.ActivityModeMappings) &&
                   Display == other.Display &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   FriendlyName == other.FriendlyName &&
                   IsAggregateMode == other.IsAggregateMode &&
                   IsTeamBased == other.IsTeamBased &&
                   ModeType == other.ModeType &&
                   Order == other.Order &&
                   ParentModes.DeepEqualsReadOnlyCollections(other.ParentModes) &&
                   PgcrImage == other.PgcrImage &&
                   SupportsFeedFiltering == other.SupportsFeedFiltering &&
                   Tier == other.Tier &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var actMode in ActivityModeMappings.Keys)
            {
                actMode.TryMapValue();
            }
            foreach (var parentMode in ParentModes)
            {
                parentMode.TryMapValue();
            }
        }
    }
}
