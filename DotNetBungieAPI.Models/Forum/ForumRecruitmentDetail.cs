namespace DotNetBungieAPI.Models.Forum;

public sealed class ForumRecruitmentDetail
{
    [JsonPropertyName("topicId")]
    public long TopicId { get; init; }

    [JsonPropertyName("microphoneRequired")]
    public bool MicrophoneRequired { get; init; }

    [JsonPropertyName("intensity")]
    public Forum.ForumRecruitmentIntensityLabel Intensity { get; init; }

    [JsonPropertyName("tone")]
    public Forum.ForumRecruitmentToneLabel Tone { get; init; }

    [JsonPropertyName("approved")]
    public bool Approved { get; init; }

    [JsonPropertyName("conversationId")]
    public long? ConversationId { get; init; }

    [JsonPropertyName("playerSlotsTotal")]
    public int PlayerSlotsTotal { get; init; }

    [JsonPropertyName("playerSlotsRemaining")]
    public int PlayerSlotsRemaining { get; init; }

    [JsonPropertyName("Fireteam")]
    public User.GeneralUser[]? Fireteam { get; init; }

    [JsonPropertyName("kickedPlayerIds")]
    public long[]? KickedPlayerIds { get; init; }
}
