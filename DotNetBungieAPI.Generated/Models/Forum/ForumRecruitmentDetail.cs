namespace DotNetBungieAPI.Generated.Models.Forum;

public class ForumRecruitmentDetail : IDeepEquatable<ForumRecruitmentDetail>
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
    public List<User.GeneralUser> Fireteam { get; set; }

    [JsonPropertyName("kickedPlayerIds")]
    public List<long> KickedPlayerIds { get; set; }

    public bool DeepEquals(ForumRecruitmentDetail? other)
    {
        return other is not null &&
               TopicId == other.TopicId &&
               MicrophoneRequired == other.MicrophoneRequired &&
               Intensity == other.Intensity &&
               Tone == other.Tone &&
               Approved == other.Approved &&
               ConversationId == other.ConversationId &&
               PlayerSlotsTotal == other.PlayerSlotsTotal &&
               PlayerSlotsRemaining == other.PlayerSlotsRemaining &&
               Fireteam.DeepEqualsList(other.Fireteam) &&
               KickedPlayerIds.DeepEqualsListNaive(other.KickedPlayerIds);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ForumRecruitmentDetail? other)
    {
        if (other is null) return;
        if (TopicId != other.TopicId)
        {
            TopicId = other.TopicId;
            OnPropertyChanged(nameof(TopicId));
        }
        if (MicrophoneRequired != other.MicrophoneRequired)
        {
            MicrophoneRequired = other.MicrophoneRequired;
            OnPropertyChanged(nameof(MicrophoneRequired));
        }
        if (Intensity != other.Intensity)
        {
            Intensity = other.Intensity;
            OnPropertyChanged(nameof(Intensity));
        }
        if (Tone != other.Tone)
        {
            Tone = other.Tone;
            OnPropertyChanged(nameof(Tone));
        }
        if (Approved != other.Approved)
        {
            Approved = other.Approved;
            OnPropertyChanged(nameof(Approved));
        }
        if (ConversationId != other.ConversationId)
        {
            ConversationId = other.ConversationId;
            OnPropertyChanged(nameof(ConversationId));
        }
        if (PlayerSlotsTotal != other.PlayerSlotsTotal)
        {
            PlayerSlotsTotal = other.PlayerSlotsTotal;
            OnPropertyChanged(nameof(PlayerSlotsTotal));
        }
        if (PlayerSlotsRemaining != other.PlayerSlotsRemaining)
        {
            PlayerSlotsRemaining = other.PlayerSlotsRemaining;
            OnPropertyChanged(nameof(PlayerSlotsRemaining));
        }
        if (!Fireteam.DeepEqualsList(other.Fireteam))
        {
            Fireteam = other.Fireteam;
            OnPropertyChanged(nameof(Fireteam));
        }
        if (!KickedPlayerIds.DeepEqualsListNaive(other.KickedPlayerIds))
        {
            KickedPlayerIds = other.KickedPlayerIds;
            OnPropertyChanged(nameof(KickedPlayerIds));
        }
    }
}