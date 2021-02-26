using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using BungieNetCoreAPI.Destiny.Definitions.ActivityTypes;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.Places;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Unity;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// The static data about Activities in Destiny 2.
    /// <para/>
    /// Note that an Activity must be combined with an ActivityMode to know - from a Gameplay perspective - what the user is "Playing".
    /// <para/>
    /// In most PvE activities, this is fairly straightforward. A Story Activity can only be played in the Story Activity Mode.
    /// <para/>
    /// However, in PvP activities, the Activity alone only tells you the map being played, or the Playlist that the user chose to enter.You'll need to know the Activity Mode they're playing to know that they're playing Mode X on Map Y.
    /// Activity Definitions tell a great deal of information about what *could* be relevant to a user: what rewards they can earn, what challenges could be performed, what modifiers could be applied.To figure out which of these properties is actually live, you'll need to combine the definition with "Live" data from one of the Destiny endpoints.
    /// <para/>
    /// Activities also have Activity Types, but unfortunately in Destiny 2 these are even less reliable of a source of information than they were in Destiny 1. I will be looking into ways to provide more reliable sources for type information as time goes on, but for now we're going to have to deal with the limitations. See DestinyActivityTypeDefinition for more information.
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyActivityDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyActivityDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityDefinition>
    {
        /// <summary>
        /// Unfortunately, in practice this is almost never populated. In theory, this is supposed to tell which Activity Graph to show if you bring up the director while in this activity.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphListEntry> ActivityGraphList { get; }
        /// <summary>
        /// The difficulty level of the activity.
        /// </summary>
        public int ActivityLevel { get; }
        /// <summary>
        /// The recommended light level for this activity.
        /// </summary>
        public int ActivityLightLevel { get; }
        /// <summary>
        /// A list of location mappings that are affected by this activity.
        /// </summary>
        public ReadOnlyCollection<ActivityLocationMappingDefinition> ActivityLocationMappings { get; }
        /// <summary>
        /// The activity modes
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> ActivityModes { get; }
        /// <summary>
        /// The activity modes - if any - in enum form.
        /// </summary>
        public ReadOnlyCollection<DestinyActivityModeType> ActivityModeTypes { get; }
        /// <summary>
        /// Activity Type of this Activity
        /// </summary>
        public DefinitionHashPointer<DestinyActivityTypeDefinition> ActivityType { get; }
        /// <summary>
        /// An activity can have many Challenges, of which any subset of them may be active for play at any given period of time. This gives the information about the challenges and data that we use to understand when they're active and what rewards they provide. Sadly, at the moment there's no central definition for challenges: much like "Skulls" were in Destiny 1, these are defined on individual activities and there can be many duplicates/near duplicates across the Destiny 2 ecosystem. I have it in mind to centralize these in a future revision of the API, but we are out of time.
        /// </summary>
        public ReadOnlyCollection<ActivityChallengeEntry> Challenges { get; }
        public uint CompletionUnlockHash { get; }
        /// <summary>
        /// Destination on which this Activity is played.
        /// </summary>
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        /// <summary>
        /// If this activity had an activity mode directly defined on it, this will be it.
        /// </summary>
        public DefinitionHashPointer<DestinyActivityModeDefinition> DirectActivityMode { get; }
        /// <summary>
        /// If this activity had an activity mode directly defined on it, this will be it, in enum form.
        /// </summary>
        public DestinyActivityModeType DirectActivityModeType { get; }
        /// <summary>
        /// The title, subtitle, and icon for the activity. We do a little post-processing on this to try and account for Activities where the designers have left this data too minimal to determine what activity is actually being played.
        /// </summary>
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// This block of data, if it exists, provides information about the guided game experience and restrictions for this activity. If it doesn't exist, the game is not able to be played as a guided game.
        /// </summary>
        public ActivityGuidedGame GuidedGame { get; }
        public bool InheritFromFreeRoam { get; }
        /// <summary>
        /// The list of phases or points of entry into an activity, along with information we can use to determine their gating and availability.
        /// </summary>
        public ReadOnlyCollection<ActivityInsertionPointEntry> InsertionPoints { get; }
        /// <summary>
        /// If True, this Activity is actually a Playlist that refers to multiple possible specific Activities and Activity Modes. For instance, a Crucible Playlist may have references to multiple Activities (Maps) with multiple Activity Modes (specific PvP gameplay modes). If this is true, refer to the playlistItems property for the specific entries in the playlist.
        /// </summary>
        public bool IsPlaylist { get; }
        /// <summary>
        /// If true, this activity is a PVP activity or playlist.
        /// </summary>
        public bool IsPvP { get; }
        /// <summary>
        /// This block of data provides information about the Activity's matchmaking attributes: how many people can join and such.
        /// </summary>
        public ActivityMatchmaking Matchmaking { get; }
        /// <summary>
        /// Activities can have Modifiers, as defined in DestinyActivityModifierDefinition. These are references to the modifiers that *can* be applied to that activity, along with data that we use to determine if that modifier is actually active at any given point in time.
        /// </summary>
        public ReadOnlyCollection<ActivityModifierEntry> Modifiers { get; }
        /// <summary>
        /// If there are status strings related to the activity and based on internal state of the game, account, or character, then this will be the definition of those strings and the states needed in order for the strings to be shown.
        /// </summary>
        public ReadOnlyCollection<ActivityUnlockString> OptionalUnlockStrings { get; }
        /// <summary>
        /// The unadulterated form of the display properties, as they ought to be shown in the Director (if the activity appears in the director).
        /// </summary>
        public DestinyDefinitionDisplayProperties OriginalDisplayProperties { get; }
        /// <summary>
        /// When Activities are completed, we generate a "Post-Game Carnage Report", or PGCR, with details about what happened in that activity (how many kills someone got, which team won, etc...) We use this image as the background when displaying PGCR information, and often use it when we refer to the Activity in general.
        /// </summary>
        public string PgcrImage { get; }
        /// <summary>
        /// The "Place" on which this Activity is played. A Place is the largest-scoped concept for location information. For instance, if the "Place" is Earth, the "Destination" would be a specific city or region on Earth.
        /// </summary>
        public DefinitionHashPointer<DestinyPlaceDefinition> Place { get; }
        /// <summary>
        /// Represents all of the possible activities that could be played in the Playlist, along with information that we can use to determine if they are active at the present time.
        /// </summary>
        public ReadOnlyCollection<ActivityPlaylistItemEntry> PlaylistItems { get; }
        /// <summary>
        /// If the activity has an icon associated with a specific release (such as a DLC), this is the path to that release's icon.
        /// </summary>
        public string ReleaseIcon { get; }
        /// <summary>
        /// If the activity will not be visible until a specific and known time, this will be the seconds since the Epoch when it will become visible.
        /// </summary>
        public int ReleaseTime { get; }
        /// <summary>
        /// The expected possible rewards for the activity. These rewards may or may not be accessible for an individual player based on their character state, the account state, and even the game's state overall. But it is a useful reference for possible rewards you can earn in the activity. These match up to rewards displayed when you hover over the Activity in the in-game Director, and often refer to Placeholder or "Dummy" items: items that tell you what you can earn in vague terms rather than what you'll specifically be earning (partly because the game doesn't even know what you'll earn specifically until you roll for it at the end)
        /// </summary>
        public ReadOnlyCollection<ActivityRewardEntry> Rewards { get; }
        /// <summary>
        /// The title, subtitle, and icon for the activity as determined by Selection Screen data, if there is any for this activity. There won't be data in this field if the activity is never shown in a selection/options screen.
        /// </summary>
        public DestinyDefinitionDisplayProperties SelectionScreenDisplayProperties { get; }
        public bool SuppressOtherRewards { get; }
        /// <summary>
        /// The difficulty tier of the activity.
        /// </summary>
        public int Tier { get; }
        /// <summary>
        /// The set of all possible loadout requirements that could be active for this activity. Only one will be active at any given time, and you can discover which one through activity-associated data such as Milestones that have activity info on them.
        /// </summary>
        public ReadOnlyCollection<ActivityLoadoutEntry> Loadouts { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyActivityDefinition(ActivityGraphListEntry[] activityGraphList, int activityLevel, int activityLightLevel, ActivityLoadoutEntry[] loadouts,
            ActivityLocationMappingDefinition[] activityLocationMappings, uint[] activityModeHashes, DestinyActivityModeType[] activityModeTypes, uint activityTypeHash,
            ActivityChallengeEntry[] challenges, uint completionUnlockHash, uint destinationHash, uint directActivityModeHash, DestinyActivityModeType directActivityModeType,
            DestinyDefinitionDisplayProperties displayProperties, ActivityGuidedGame guidedGame, bool inheritFromFreeRoam, ActivityInsertionPointEntry[] insertionPoints,
            bool isPlaylist, bool isPvP, ActivityMatchmaking matchmaking, ActivityModifierEntry[] modifiers, ActivityUnlockString[] optionalUnlockStrings,
            DestinyDefinitionDisplayProperties originalDisplayProperties, string pgcrImage, uint placeHash, ActivityPlaylistItemEntry[] playlistItems, string releaseIcon,
            int releaseTime, ActivityRewardEntry[] rewards, DestinyDefinitionDisplayProperties selectionScreenDisplayProperties, bool suppressOtherRewards, int tier,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            ActivityGraphList = activityGraphList.AsReadOnlyOrEmpty();
            ActivityLevel = activityLevel;
            ActivityLightLevel = activityLightLevel;
            ActivityLocationMappings = activityLocationMappings.AsReadOnlyOrEmpty();
            ActivityModes = activityModeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModeDefinition>(DefinitionsEnum.DestinyActivityModeDefinition);
            ActivityModeTypes = activityModeTypes.AsReadOnlyOrEmpty();
            ActivityType = new DefinitionHashPointer<DestinyActivityTypeDefinition>(activityTypeHash, DefinitionsEnum.DestinyActivityTypeDefinition);
            Challenges = challenges.AsReadOnlyOrEmpty();
            CompletionUnlockHash = completionUnlockHash;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            DirectActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(directActivityModeHash, DefinitionsEnum.DestinyActivityModeDefinition);
            DirectActivityModeType = directActivityModeType;
            DisplayProperties = displayProperties;
            GuidedGame = guidedGame;
            InheritFromFreeRoam = inheritFromFreeRoam;
            InsertionPoints = insertionPoints.AsReadOnlyOrEmpty();
            IsPlaylist = isPlaylist;
            IsPvP = isPvP;
            Matchmaking = matchmaking;
            Modifiers = modifiers.AsReadOnlyOrEmpty();
            OptionalUnlockStrings = optionalUnlockStrings.AsReadOnlyOrEmpty();
            OriginalDisplayProperties = originalDisplayProperties;
            PgcrImage = pgcrImage;
            Place = new DefinitionHashPointer<DestinyPlaceDefinition>(placeHash, DefinitionsEnum.DestinyPlaceDefinition);
            PlaylistItems = playlistItems.AsReadOnlyOrEmpty();
            ReleaseIcon = releaseIcon;
            ReleaseTime = releaseTime;
            Rewards = rewards.AsReadOnlyOrEmpty();
            SelectionScreenDisplayProperties = selectionScreenDisplayProperties;
            SuppressOtherRewards = suppressOtherRewards;
            Tier = tier;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            Loadouts = loadouts.AsReadOnlyOrEmpty();
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
        public void MapValues()
        {
            foreach (var activityGraph in ActivityGraphList)
            {
                activityGraph.ActivityGraph.TryMapValue();
            }
            foreach (var activityLocationMapping in ActivityLocationMappings)
            {
                activityLocationMapping.Activity.TryMapValue();
                activityLocationMapping.Item.TryMapValue();
                activityLocationMapping.Location.TryMapValue();
                activityLocationMapping.Objective.TryMapValue();
            }
            foreach (var activityMode in ActivityModes)
            {
                activityMode.TryMapValue();
            }
            ActivityType.TryMapValue();
            foreach (var challenge in Challenges)
            {
                challenge.Objective.TryMapValue();
                foreach (var dummyReward in challenge.DummyRewards)
                {
                    dummyReward.Item.TryMapValue();
                }
            }
            Destination.TryMapValue();
            DirectActivityMode.TryMapValue();
            foreach (var modifier in Modifiers)
            {
                modifier.ActivityModifier.TryMapValue();
            }
            Place.TryMapValue();
            foreach (var playlistItem in PlaylistItems)
            {
                playlistItem.Activity.TryMapValue();
                playlistItem.DirectActivityMode.TryMapValue();
                foreach (var playlistItemActivityMode in playlistItem.ActivityModes)
                {
                    playlistItemActivityMode.TryMapValue();
                }
            }
            foreach (var reward in Rewards)
            {
                foreach (var rewardItem in reward.RewardItems)
                {
                    rewardItem.Item.TryMapValue();
                }
            }
            foreach (var loadout in Loadouts)
            {
                foreach (var requirement in loadout.Requirements)
                {
                    requirement.EquipmentSlot.TryMapValue();
                    foreach (var item in requirement.AllowedEquippedItems)
                    {
                        item.TryMapValue();
                    }
                }
            }
        }
        public bool DeepEquals(DestinyActivityDefinition other)
        {
            return other != null &&
                   ActivityGraphList.DeepEqualsReadOnlyCollections(other.ActivityGraphList) &&
                   ActivityLevel == other.ActivityLevel &&
                   ActivityLightLevel == other.ActivityLightLevel &&
                   ActivityLocationMappings.DeepEqualsReadOnlyCollections(other.ActivityLocationMappings) &&
                   ActivityModes.DeepEqualsReadOnlyCollections(other.ActivityModes) &&
                   ActivityModeTypes.DeepEqualsReadOnlySimpleCollection(other.ActivityModeTypes) &&
                   ActivityType.DeepEquals(other.ActivityType) &&
                   Challenges.DeepEqualsReadOnlyCollections(other.Challenges) &&
                   CompletionUnlockHash == other.CompletionUnlockHash &&
                   Destination.DeepEquals(other.Destination) &&
                   DirectActivityMode.DeepEquals(other.DirectActivityMode) &&
                   DirectActivityModeType == other.DirectActivityModeType &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   (GuidedGame != null ? GuidedGame.DeepEquals(other.GuidedGame) : other.GuidedGame == null) &&
                   InheritFromFreeRoam == other.InheritFromFreeRoam &&
                   InsertionPoints.DeepEqualsReadOnlyCollections(other.InsertionPoints) &&
                   IsPlaylist == other.IsPlaylist &&
                   IsPvP == other.IsPvP &&
                   (Matchmaking != null ? Matchmaking.DeepEquals(other.Matchmaking) : other.Matchmaking == null) &&
                   Modifiers.DeepEqualsReadOnlyCollections(other.Modifiers) &&
                   OptionalUnlockStrings.DeepEqualsReadOnlyCollections(other.OptionalUnlockStrings) &&
                   OriginalDisplayProperties.DeepEquals(other.OriginalDisplayProperties) &&
                   PgcrImage == other.PgcrImage &&
                   Place.DeepEquals(other.Place) &&
                   PlaylistItems.DeepEqualsReadOnlyCollections(other.PlaylistItems) &&
                   ReleaseIcon == other.ReleaseIcon &&
                   ReleaseTime == other.ReleaseTime &&
                   Rewards.DeepEqualsReadOnlyCollections(other.Rewards) &&
                   (SelectionScreenDisplayProperties != null ? SelectionScreenDisplayProperties.DeepEquals(other.SelectionScreenDisplayProperties) : other.SelectionScreenDisplayProperties == null) &&
                   SuppressOtherRewards == other.SuppressOtherRewards &&
                   Tier == other.Tier &&
                   Loadouts.DeepEqualsReadOnlyCollections(other.Loadouts) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public DefinitionHashPointer<DestinyActivityDefinition> GetPointer()
        {
            var repo = StaticUnityContainer.GetDestinyDefinitionRepositories();
            var settings = StaticUnityContainer.GetConfiguration().Settings;
            foreach (var locale in settings.Locales)
            {
                if (repo.TryGetDestinyDefinition<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, Hash, locale, out var definition))
                {
                    if (Equals(definition))
                        return new DefinitionHashPointer<DestinyActivityDefinition>(Hash, DefinitionsEnum.DestinyActivityDefinition, locale, definition, repo);
                }
            }
            return null;
        }
    }
}
