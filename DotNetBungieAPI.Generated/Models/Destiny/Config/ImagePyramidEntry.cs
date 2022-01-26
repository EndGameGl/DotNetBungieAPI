namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

public class ImagePyramidEntry : IDeepEquatable<ImagePyramidEntry>
{
    /// <summary>
    ///     The name of the subfolder where these images are located.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     The factor by which the original image size has been reduced.
    /// </summary>
    [JsonPropertyName("factor")]
    public float Factor { get; set; }

    public bool DeepEquals(ImagePyramidEntry? other)
    {
        return other is not null &&
               Name == other.Name &&
               Factor == other.Factor;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ImagePyramidEntry? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (Factor != other.Factor)
        {
            Factor = other.Factor;
            OnPropertyChanged(nameof(Factor));
        }
    }
}