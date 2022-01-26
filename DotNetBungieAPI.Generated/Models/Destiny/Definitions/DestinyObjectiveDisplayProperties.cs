namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyObjectiveDisplayProperties : IDeepEquatable<DestinyObjectiveDisplayProperties>
{
    /// <summary>
    ///     The activity associated with this objective in the context of this item, if any.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    /// <summary>
    ///     If true, the game shows this objective on item preview screens.
    /// </summary>
    [JsonPropertyName("displayOnItemPreviewScreen")]
    public bool DisplayOnItemPreviewScreen { get; set; }

    public bool DeepEquals(DestinyObjectiveDisplayProperties? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               DisplayOnItemPreviewScreen == other.DisplayOnItemPreviewScreen;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyObjectiveDisplayProperties? other)
    {
        if (other is null) return;
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (DisplayOnItemPreviewScreen != other.DisplayOnItemPreviewScreen)
        {
            DisplayOnItemPreviewScreen = other.DisplayOnItemPreviewScreen;
            OnPropertyChanged(nameof(DisplayOnItemPreviewScreen));
        }
    }
}