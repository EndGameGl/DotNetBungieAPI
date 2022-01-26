namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class SchemaRecordStateBlock : IDeepEquatable<SchemaRecordStateBlock>
{
    [JsonPropertyName("featuredPriority")]
    public int FeaturedPriority { get; set; }

    [JsonPropertyName("obscuredString")]
    public string ObscuredString { get; set; }

    public bool DeepEquals(SchemaRecordStateBlock? other)
    {
        return other is not null &&
               FeaturedPriority == other.FeaturedPriority &&
               ObscuredString == other.ObscuredString;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(SchemaRecordStateBlock? other)
    {
        if (other is null) return;
        if (FeaturedPriority != other.FeaturedPriority)
        {
            FeaturedPriority = other.FeaturedPriority;
            OnPropertyChanged(nameof(FeaturedPriority));
        }
        if (ObscuredString != other.ObscuredString)
        {
            ObscuredString = other.ObscuredString;
            OnPropertyChanged(nameof(ObscuredString));
        }
    }
}