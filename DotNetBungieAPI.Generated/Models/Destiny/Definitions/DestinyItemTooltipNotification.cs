namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyItemTooltipNotification : IDeepEquatable<DestinyItemTooltipNotification>
{
    [JsonPropertyName("displayString")]
    public string DisplayString { get; set; }

    [JsonPropertyName("displayStyle")]
    public string DisplayStyle { get; set; }

    public bool DeepEquals(DestinyItemTooltipNotification? other)
    {
        return other is not null &&
               DisplayString == other.DisplayString &&
               DisplayStyle == other.DisplayStyle;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemTooltipNotification? other)
    {
        if (other is null) return;
        if (DisplayString != other.DisplayString)
        {
            DisplayString = other.DisplayString;
            OnPropertyChanged(nameof(DisplayString));
        }
        if (DisplayStyle != other.DisplayStyle)
        {
            DisplayStyle = other.DisplayStyle;
            OnPropertyChanged(nameof(DisplayStyle));
        }
    }
}