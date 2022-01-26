namespace DotNetBungieAPI.Generated.Models.Interpolation;

public class InterpolationPoint : IDeepEquatable<InterpolationPoint>
{
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    public bool DeepEquals(InterpolationPoint? other)
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

    public void Update(InterpolationPoint? other)
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