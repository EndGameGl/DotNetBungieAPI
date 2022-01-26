namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     If a Milestone has one or more Quests, this will contain the live information for the character's status with one of those quests.
/// </summary>
public class DestinyMilestoneQuest : IDeepEquatable<DestinyMilestoneQuest>
{
    /// <summary>
    ///     Quests are defined as Items in content. As such, this is the hash identifier of the DestinyInventoryItemDefinition that represents this quest. It will have pointers to all of the steps in the quest, and display information for the quest (title, description, icon etc) Individual steps will be referred to in the Quest item's DestinyInventoryItemDefinition.setData property, and themselves are Items with their own renderable data.
    /// </summary>
    [JsonPropertyName("questItemHash")]
    public uint QuestItemHash { get; set; }

    /// <summary>
    ///     The current status of the quest for the character making the request.
    /// </summary>
    [JsonPropertyName("status")]
    public Destiny.Quests.DestinyQuestStatus Status { get; set; }

    /// <summary>
    ///     *IF* the Milestone has an active Activity that can give you greater details about what you need to do, it will be returned here. Remember to associate this with the DestinyMilestoneDefinition's activities to get details about the activity, including what specific quest it is related to if you have multiple quests to choose from.
    /// </summary>
    [JsonPropertyName("activity")]
    public Destiny.Milestones.DestinyMilestoneActivity Activity { get; set; }

    /// <summary>
    ///     The activities referred to by this quest can have many associated challenges. They are all contained here, with activityHashes so that you can associate them with the specific activity variants in which they can be found. In retrospect, I probably should have put these under the specific Activity Variants, but it's too late to change it now. Theoretically, a quest without Activities can still have Challenges, which is why this is on a higher level than activity/variants, but it probably should have been in both places. That may come as a later revision.
    /// </summary>
    [JsonPropertyName("challenges")]
    public List<Destiny.Challenges.DestinyChallengeStatus> Challenges { get; set; }

    public bool DeepEquals(DestinyMilestoneQuest? other)
    {
        return other is not null &&
               QuestItemHash == other.QuestItemHash &&
               (Status is not null ? Status.DeepEquals(other.Status) : other.Status is null) &&
               (Activity is not null ? Activity.DeepEquals(other.Activity) : other.Activity is null) &&
               Challenges.DeepEqualsList(other.Challenges);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneQuest? other)
    {
        if (other is null) return;
        if (QuestItemHash != other.QuestItemHash)
        {
            QuestItemHash = other.QuestItemHash;
            OnPropertyChanged(nameof(QuestItemHash));
        }
        if (!Status.DeepEquals(other.Status))
        {
            Status.Update(other.Status);
            OnPropertyChanged(nameof(Status));
        }
        if (!Activity.DeepEquals(other.Activity))
        {
            Activity.Update(other.Activity);
            OnPropertyChanged(nameof(Activity));
        }
        if (!Challenges.DeepEqualsList(other.Challenges))
        {
            Challenges = other.Challenges;
            OnPropertyChanged(nameof(Challenges));
        }
    }
}