namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyItemCraftingBlockBonusPlugDefinition : IDeepEquatable<DestinyItemCraftingBlockBonusPlugDefinition>
{
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; set; }

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    public bool DeepEquals(DestinyItemCraftingBlockBonusPlugDefinition? other)
    {
        return other is not null &&
               SocketTypeHash == other.SocketTypeHash &&
               PlugItemHash == other.PlugItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemCraftingBlockBonusPlugDefinition? other)
    {
        if (other is null) return;
        if (SocketTypeHash != other.SocketTypeHash)
        {
            SocketTypeHash = other.SocketTypeHash;
            OnPropertyChanged(nameof(SocketTypeHash));
        }
        if (PlugItemHash != other.PlugItemHash)
        {
            PlugItemHash = other.PlugItemHash;
            OnPropertyChanged(nameof(PlugItemHash));
        }
    }
}