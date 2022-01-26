namespace DotNetBungieAPI.Generated.Models.Interpolation;

public class InterpolationPointFloat : IDeepEquatable<InterpolationPointFloat>
{
    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("weight")]
    public float Weight { get; set; }

    public bool DeepEquals(InterpolationPointFloat? other)
    {
        return other is not null &&
               Value == other.Value &&
               Weight == other.Weight;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(InterpolationPointFloat? other)
    {
        if (other is null) return;
        if (Value != other.Value)
        {
            Value = other.Value;
            OnPropertyChanged(nameof(Value));
        }
        if (Weight != other.Weight)
        {
            Weight = other.Weight;
            OnPropertyChanged(nameof(Weight));
        }
    }
}