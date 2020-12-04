using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using BungieNetCoreAPI.Destiny.Definitions.ActivityTypes;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.Places;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    [DestinyDefinition("DestinyActivityDefinition")]
    public class DestinyActivityDefinition : DestinyDefinition
    {
        public List<ActivityGraphListEntry> ActivityGraphList { get; }
        public int ActivityLevel { get; }
        public int ActivityLightLevel { get; }
        public List<ActivityLocationMappingDefinition> ActivityLocationMappings { get; }
        public List<DefinitionHashPointer<DestinyActivityModeDefinition>> ActivityModes { get; }
        public List<DestinyActivityModeType> ActivityModeTypes { get; }
        public DefinitionHashPointer<DestinyActivityTypeDefinition> ActivityType { get; }
        public List<ActivityChallengeEntry> Challenges { get; }
        public uint CompletionUnlockHash { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> DirectActivityMode { get; }
        public DestinyActivityModeType DirectActivityModeType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ActivityGuidedGame GuidedGame { get; }
        public bool InheritFromFreeRoam { get; }
        public List<ActivityInsertionPointEntry> InsertionPoints { get; }
        public bool IsPlaylist { get; }
        public bool IsPvP { get; }
        public ActivityMatchmaking Matchmaking { get; }
        public List<ActivityModifierEntry> Modifiers { get; }
        public List<ActivityUnlockString> OptionalUnlockStrings { get; }
        public DestinyDefinitionDisplayProperties OriginalDisplayProperties { get; }
        public string PgcrImage { get; }
        public DefinitionHashPointer<DestinyPlaceDefinition> Place { get; }
        public List<ActivityPlaylistItemEntry> PlaylistItems { get; }
        public string ReleaseIcon { get; }
        public int ReleaseTime { get; }
        public List<ActivityRewardEntry> Rewards { get; }
        public DestinyDefinitionDisplayProperties SelectionScreenDisplayProperties { get; }
        public bool SuppressOtherRewards { get; }
        public int Tier { get; }

        [JsonConstructor]
        private DestinyActivityDefinition(List<ActivityGraphListEntry> activityGraphList, int activityLevel, int activityLightLevel,
            List<ActivityLocationMappingDefinition> activityLocationMappings, List<uint> activityModeHashes, List<DestinyActivityModeType> activityModeTypes, uint activityTypeHash,
            List<ActivityChallengeEntry> challenges, uint completionUnlockHash, uint destinationHash, uint directActivityModeHash, DestinyActivityModeType directActivityModeType,
            DestinyDefinitionDisplayProperties displayProperties, ActivityGuidedGame guidedGame, bool inheritFromFreeRoam, List<ActivityInsertionPointEntry> insertionPoints,
            bool isPlaylist, bool isPvP, ActivityMatchmaking matchmaking, List<ActivityModifierEntry> modifiers, List<ActivityUnlockString> optionalUnlockStrings,
            DestinyDefinitionDisplayProperties originalDisplayProperties, string pgcrImage, uint placeHash, List<ActivityPlaylistItemEntry> playlistItems, string releaseIcon, int releaseTime,
            List<ActivityRewardEntry> rewards, DestinyDefinitionDisplayProperties selectionScreenDisplayProperties, bool suppressOtherRewards, int tier,
            bool blacklisted, uint hash, int index, bool redacted) : base(blacklisted, hash, index, redacted)
        {
            if (activityGraphList == null)
                ActivityGraphList = new List<ActivityGraphListEntry>();
            else
                ActivityGraphList = activityGraphList;

            ActivityLevel = activityLevel;
            ActivityLightLevel = activityLightLevel;
            if (activityLocationMappings == null)
                ActivityLocationMappings = new List<ActivityLocationMappingDefinition>();
            else
                ActivityLocationMappings = activityLocationMappings;
            if (activityModeHashes == null)
                ActivityModes = new List<DefinitionHashPointer<DestinyActivityModeDefinition>>();
            else
            {
                ActivityModes = new List<DefinitionHashPointer<DestinyActivityModeDefinition>>();
                foreach (var activityModeHash in activityModeHashes)
                    ActivityModes.Add(new DefinitionHashPointer<DestinyActivityModeDefinition>(activityModeHash, "DestinyActivityModeDefinition"));
            }
            if (activityModeTypes == null)
                ActivityModeTypes = new List<DestinyActivityModeType>();
            else
                ActivityModeTypes = activityModeTypes;
            ActivityType = new DefinitionHashPointer<DestinyActivityTypeDefinition>(activityTypeHash, "DestinyActivityTypeDefinition");
            if (challenges == null)
                Challenges = new List<ActivityChallengeEntry>();
            else
                Challenges = challenges;
            CompletionUnlockHash = completionUnlockHash;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, "DestinyDestinationDefinition");
            DirectActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(directActivityModeHash, "DestinyActivityModeDefinition");
            DirectActivityModeType = directActivityModeType;
            DisplayProperties = displayProperties;
            GuidedGame = guidedGame;
            InheritFromFreeRoam = inheritFromFreeRoam;
            if (insertionPoints == null)
                InsertionPoints = new List<ActivityInsertionPointEntry>();
            else
                InsertionPoints = insertionPoints;
            IsPlaylist = isPlaylist;
            IsPvP = isPvP;
            Matchmaking = matchmaking;
            if (modifiers == null)
                Modifiers = new List<ActivityModifierEntry>();
            else 
                Modifiers = modifiers;
            if (optionalUnlockStrings == null)
                OptionalUnlockStrings = new List<ActivityUnlockString>();
            else
                OptionalUnlockStrings = optionalUnlockStrings;
            OriginalDisplayProperties = originalDisplayProperties;
            PgcrImage = pgcrImage;
            Place = new DefinitionHashPointer<DestinyPlaceDefinition>(placeHash, "DestinyPlaceDefinition");
            if (playlistItems == null)
                PlaylistItems = new List<ActivityPlaylistItemEntry>();
            else
                PlaylistItems = playlistItems;
            ReleaseIcon = releaseIcon;
            ReleaseTime = releaseTime;
            if (rewards == null)
                Rewards = new List<ActivityRewardEntry>();
            else
                Rewards = rewards;
            SelectionScreenDisplayProperties = selectionScreenDisplayProperties;
            SuppressOtherRewards = suppressOtherRewards;
            Tier = tier;
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
    }
}
