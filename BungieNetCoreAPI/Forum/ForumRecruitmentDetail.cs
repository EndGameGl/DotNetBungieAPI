using NetBungieAPI.User;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Forum
{
    public class ForumRecruitmentDetail
    {
        public long TopicId { get; }
        public bool MicrophoneRequired { get; }
        public ForumRecruitmentIntensityLabel Intensity { get; }
        public ForumRecruitmentToneLabel Tone { get; }
        public bool Approved { get; }
        public long? ConversationId { get; }
        public int PlayerSlotsTotal { get; }
        public int PlayerSlotsRemaining { get; }
        public ReadOnlyCollection<GeneralUser> Fireteam { get; }
        public ReadOnlyCollection<long> KickedPlayerIds { get; }

        [JsonConstructor]
        internal ForumRecruitmentDetail(long topicId, bool microphoneRequired, ForumRecruitmentIntensityLabel intensity, ForumRecruitmentToneLabel tone,
            bool approved, long? conversationId, int playerSlotsTotal, int playerSlotsRemaining, GeneralUser[] Fireteam, long[] kickedPlayerIds)
        {
            TopicId = topicId;
            MicrophoneRequired = microphoneRequired;
            Intensity = intensity;
            Tone = tone;
            Approved = approved;
            ConversationId = conversationId;
            PlayerSlotsTotal = playerSlotsTotal;
            PlayerSlotsRemaining = playerSlotsRemaining;
            this.Fireteam = Fireteam.AsReadOnlyOrEmpty();
            KickedPlayerIds = kickedPlayerIds.AsReadOnlyOrEmpty();
        }
    }
}
