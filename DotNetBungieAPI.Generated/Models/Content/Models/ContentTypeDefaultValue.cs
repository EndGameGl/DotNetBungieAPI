namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypeDefaultValue : IDeepEquatable<ContentTypeDefaultValue>
{
    [JsonPropertyName("whenClause")]
    public string WhenClause { get; set; }

    [JsonPropertyName("whenValue")]
    public string WhenValue { get; set; }

    [JsonPropertyName("defaultValue")]
    public string DefaultValue { get; set; }

    public bool DeepEquals(ContentTypeDefaultValue? other)
    {
        return other is not null &&
               WhenClause == other.WhenClause &&
               WhenValue == other.WhenValue &&
               DefaultValue == other.DefaultValue;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ContentTypeDefaultValue? other)
    {
        if (other is null) return;
        if (WhenClause != other.WhenClause)
        {
            WhenClause = other.WhenClause;
            OnPropertyChanged(nameof(WhenClause));
        }
        if (WhenValue != other.WhenValue)
        {
            WhenValue = other.WhenValue;
            OnPropertyChanged(nameof(WhenValue));
        }
        if (DefaultValue != other.DefaultValue)
        {
            DefaultValue = other.DefaultValue;
            OnPropertyChanged(nameof(DefaultValue));
        }
    }
}