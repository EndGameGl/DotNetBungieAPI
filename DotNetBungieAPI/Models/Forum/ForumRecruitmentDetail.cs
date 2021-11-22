using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Forum
{
    public sealed record ForumRecruitmentDetail
    {
        [JsonPropertyName("topicId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long TopicId { get; init; }

        [JsonPropertyName("microphoneRequired")]
        public bool MicrophoneRequired { get; init; }

        [JsonPropertyName("intensity")] public ForumRecruitmentIntensityLabel Intensity { get; init; }

        [JsonPropertyName("tone")] public ForumRecruitmentToneLabel Tone { get; init; }

        [JsonPropertyName("approved")] public bool Approved { get; init; }

        [JsonPropertyName("conversationId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long? ConversationId { get; init; }

        [JsonPropertyName("playerSlotsTotal")] public int PlayerSlotsTotal { get; init; }

        [JsonPropertyName("playerSlotsRemaining")]
        public int PlayerSlotsRemaining { get; init; }

        [JsonPropertyName("Fireteam")] public ReadOnlyCollection<GeneralUser> Fireteam { get; init; }

        [JsonPropertyName("kickedPlayerIds")] public ReadOnlyCollection<long> KickedPlayerIds { get; init; }
    }
}