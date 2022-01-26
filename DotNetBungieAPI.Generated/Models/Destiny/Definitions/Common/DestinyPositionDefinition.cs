namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Common;

public class DestinyPositionDefinition : IDeepEquatable<DestinyPositionDefinition>
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("z")]
    public int Z { get; set; }

    public bool DeepEquals(DestinyPositionDefinition? other)
    {
        return other is not null &&
               X == other.X &&
               Y == other.Y &&
               Z == other.Z;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPositionDefinition? other)
    {
        if (other is null) return;
        if (X != other.X)
        {
            X = other.X;
            OnPropertyChanged(nameof(X));
        }
        if (Y != other.Y)
        {
            Y = other.Y;
            OnPropertyChanged(nameof(Y));
        }
        if (Z != other.Z)
        {
            Z = other.Z;
            OnPropertyChanged(nameof(Z));
        }
    }
}