using NetBungieAPI.User;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Fireteam
{
    public class FireteamMember
    {
        public FireteamUserInfoCard DestinyUserInfo { get; }
        public UserInfoCard BungieNetUserInfo { get; }
        public long CharacterId { get; }
        public DateTime DateJoined { get; }
        public bool HasMicrophone { get; }
        public DateTime LastPlatformInviteAttemptDate { get; }
        public FireteamPlatformInviteResult LastPlatformInviteAttemptResult { get; }

        [JsonConstructor]
        internal FireteamMember(FireteamUserInfoCard destinyUserInfo, UserInfoCard bungieNetUserInfo, long characterId, DateTime dateJoined,
            bool hasMicrophone, DateTime lastPlatformInviteAttemptDate, FireteamPlatformInviteResult lastPlatformInviteAttemptResult)
        {
            DestinyUserInfo = destinyUserInfo;
            BungieNetUserInfo = bungieNetUserInfo;
            CharacterId = characterId;
            DateJoined = dateJoined;
            HasMicrophone = hasMicrophone;
            LastPlatformInviteAttemptDate = lastPlatformInviteAttemptDate;
            LastPlatformInviteAttemptResult = lastPlatformInviteAttemptResult;
        }
    }
}
