namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyRitual : IDeepEquatable<TrendingEntryDestinyRitual>
{
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    [JsonPropertyName("dateStart")]
    public DateTime? DateStart { get; set; }

    [JsonPropertyName("dateEnd")]
    public DateTime? DateEnd { get; set; }

    /// <summary>
    ///     A destiny event does not necessarily have a related Milestone, but if it does the details will be returned here.
    /// </summary>
    [JsonPropertyName("milestoneDetails")]
    public Destiny.Milestones.DestinyPublicMilestone MilestoneDetails { get; set; }

    /// <summary>
    ///     A destiny event will not necessarily have milestone "custom content", but if it does the details will be here.
    /// </summary>
    [JsonPropertyName("eventContent")]
    public Destiny.Milestones.DestinyMilestoneContent EventContent { get; set; }

    public bool DeepEquals(TrendingEntryDestinyRitual? other)
    {
        return other is not null &&
               Image == other.Image &&
               Icon == other.Icon &&
               Title == other.Title &&
               Subtitle == other.Subtitle &&
               DateStart == other.DateStart &&
               DateEnd == other.DateEnd &&
               (MilestoneDetails is not null ? MilestoneDetails.DeepEquals(other.MilestoneDetails) : other.MilestoneDetails is null) &&
               (EventContent is not null ? EventContent.DeepEquals(other.EventContent) : other.EventContent is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingEntryDestinyRitual? other)
    {
        if (other is null) return;
        if (Image != other.Image)
        {
            Image = other.Image;
            OnPropertyChanged(nameof(Image));
        }
        if (Icon != other.Icon)
        {
            Icon = other.Icon;
            OnPropertyChanged(nameof(Icon));
        }
        if (Title != other.Title)
        {
            Title = other.Title;
            OnPropertyChanged(nameof(Title));
        }
        if (Subtitle != other.Subtitle)
        {
            Subtitle = other.Subtitle;
            OnPropertyChanged(nameof(Subtitle));
        }
        if (DateStart != other.DateStart)
        {
            DateStart = other.DateStart;
            OnPropertyChanged(nameof(DateStart));
        }
        if (DateEnd != other.DateEnd)
        {
            DateEnd = other.DateEnd;
            OnPropertyChanged(nameof(DateEnd));
        }
        if (!MilestoneDetails.DeepEquals(other.MilestoneDetails))
        {
            MilestoneDetails.Update(other.MilestoneDetails);
            OnPropertyChanged(nameof(MilestoneDetails));
        }
        if (!EventContent.DeepEquals(other.EventContent))
        {
            EventContent.Update(other.EventContent);
            OnPropertyChanged(nameof(EventContent));
        }
    }
}