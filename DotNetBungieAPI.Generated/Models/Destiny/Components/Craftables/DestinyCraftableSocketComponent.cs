namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftableSocketComponent : IDeepEquatable<DestinyCraftableSocketComponent>
{
    [JsonPropertyName("plugSetHash")]
    public uint PlugSetHash { get; set; }

    /// <summary>
    ///     Unlock state for plugs in the socket plug set definition
    /// </summary>
    [JsonPropertyName("plugs")]
    public List<Destiny.Components.Craftables.DestinyCraftableSocketPlugComponent> Plugs { get; set; }

    public bool DeepEquals(DestinyCraftableSocketComponent? other)
    {
        return other is not null &&
               PlugSetHash == other.PlugSetHash &&
               Plugs.DeepEqualsList(other.Plugs);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCraftableSocketComponent? other)
    {
        if (other is null) return;
        if (PlugSetHash != other.PlugSetHash)
        {
            PlugSetHash = other.PlugSetHash;
            OnPropertyChanged(nameof(PlugSetHash));
        }
        if (!Plugs.DeepEqualsList(other.Plugs))
        {
            Plugs = other.Plugs;
            OnPropertyChanged(nameof(Plugs));
        }
    }
}