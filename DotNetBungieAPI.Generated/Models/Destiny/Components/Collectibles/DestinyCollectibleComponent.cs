namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyCollectibleComponent : IDeepEquatable<DestinyCollectibleComponent>
{
    [JsonPropertyName("state")]
    public Destiny.DestinyCollectibleState State { get; set; }

    public bool DeepEquals(DestinyCollectibleComponent? other)
    {
        return other is not null &&
               State == other.State;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCollectibleComponent? other)
    {
        if (other is null) return;
        if (State != other.State)
        {
            State = other.State;
            OnPropertyChanged(nameof(State));
        }
    }
}