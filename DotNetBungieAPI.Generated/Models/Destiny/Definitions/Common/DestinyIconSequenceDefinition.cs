namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Common;

public class DestinyIconSequenceDefinition : IDeepEquatable<DestinyIconSequenceDefinition>
{
    [JsonPropertyName("frames")]
    public List<string> Frames { get; set; }

    public bool DeepEquals(DestinyIconSequenceDefinition? other)
    {
        return other is not null &&
               Frames.DeepEqualsListNaive(other.Frames);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyIconSequenceDefinition? other)
    {
        if (other is null) return;
        if (!Frames.DeepEqualsListNaive(other.Frames))
        {
            Frames = other.Frames;
            OnPropertyChanged(nameof(Frames));
        }
    }
}