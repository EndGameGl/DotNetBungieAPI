namespace DotNetBungieAPI.Generated.Models.Forum;

public class ForumRecruitmentDetail
{
    [JsonPropertyName("topicId")]
    public long TopicId { get; set; }

    [JsonPropertyName("microphoneRequired")]
    public bool MicrophoneRequired { get; set; }

    [JsonPropertyName("intensity")]
    public Forum.ForumRecruitmentIntensityLabel Intensity { get; set; }

    [JsonPropertyName("tone")]
    public Forum.ForumRecruitmentToneLabel Tone { get; set; }

    [JsonPropertyName("approved")]
    public bool Approved { get; set; }

    [JsonPropertyName("conversationId")]
    public long? ConversationId { get; set; }

    [JsonPropertyName("playerSlotsTotal")]
    public int PlayerSlotsTotal { get; set; }

    [JsonPropertyName("playerSlotsRemaining")]
    public int PlayerSlotsRemaining { get; set; }

    [JsonPropertyName("Fireteam")]
    public User.GeneralUser[]? Fireteam { get; set; }

    [JsonPropertyName("kickedPlayerIds")]
    public long[]? KickedPlayerIds { get; set; }
}
