using NetBungieAPI.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Fireteam
{
    public class FireteamSummary
    {
        public long FireteamId { get; }
        public long GroupId { get; }
        public FireteamPlatform Platform { get; }
        public DestinyActivityModeType ActivityType { get; }
        public bool IsImmediate { get; }
        public DateTime? ScheduledTime { get; }
        public long OwnerMembershipId { get; }
        public int PlayerSlotCount { get; }
        public int? AlternateSlotCount { get; }
        public int AvailablePlayerSlotCount { get; }
        public int AvailableAlternateSlotCount { get; }
        public string Title { get; }
        public DateTime DateCreated { get; }
        public DateTime? DateModified { get; }
        public bool IsPublic { get; }
        public string Locale { get; }
        public bool IsValid { get; }
        public DateTime DatePlayerModified { get; }
        public string TitleBeforeModeration { get; }

        [JsonConstructor]
        internal FireteamSummary(long fireteamId, long groupId, FireteamPlatform platform, DestinyActivityModeType activityType, bool isImmediate, DateTime? scheduledTime,
            long ownerMembershipId, int playerSlotCount, int? alternateSlotCount, int availablePlayerSlotCount, int availableAlternateSlotCount,
            string title, DateTime dateCreated, DateTime? dateModified, bool isPublic, string locale, bool isValid, DateTime datePlayerModified,
            string titleBeforeModeration)
        {
            FireteamId = fireteamId;
            GroupId = groupId;
            Platform = platform;
            ActivityType = activityType;
            IsImmediate = isImmediate;
            ScheduledTime = scheduledTime;
            OwnerMembershipId = ownerMembershipId;
            PlayerSlotCount = playerSlotCount;
            AlternateSlotCount = alternateSlotCount;
            AvailablePlayerSlotCount = availablePlayerSlotCount;
            AvailableAlternateSlotCount = availableAlternateSlotCount;
            Title = title;
            DateCreated = dateCreated;
            DateModified = dateModified;
            IsPublic = isPublic;
            Locale = locale;
            IsValid = isValid;
            DatePlayerModified = datePlayerModified;
            TitleBeforeModeration = titleBeforeModeration;
        }
    }
}
