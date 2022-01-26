namespace DotNetBungieAPI.Generated.Models.User;

public class ExactSearchRequest : IDeepEquatable<ExactSearchRequest>
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("displayNameCode")]
    public short DisplayNameCode { get; set; }

    public bool DeepEquals(ExactSearchRequest? other)
    {
        return other is not null &&
               DisplayName == other.DisplayName &&
               DisplayNameCode == other.DisplayNameCode;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ExactSearchRequest? other)
    {
        if (other is null) return;
        if (DisplayName != other.DisplayName)
        {
            DisplayName = other.DisplayName;
            OnPropertyChanged(nameof(DisplayName));
        }
        if (DisplayNameCode != other.DisplayNameCode)
        {
            DisplayNameCode = other.DisplayNameCode;
            OnPropertyChanged(nameof(DisplayNameCode));
        }
    }
}