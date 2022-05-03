namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftablesComponent : IDeepEquatable<DestinyCraftablesComponent>
{
    /// <summary>
    ///     A map of craftable item hashes to craftable item state components.
    /// </summary>
    [JsonPropertyName("craftables")]
    public Dictionary<uint, Destiny.Components.Craftables.DestinyCraftableComponent> Craftables { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of craftable item categories.
    /// </summary>
    [JsonPropertyName("craftingRootNodeHash")]
    public uint CraftingRootNodeHash { get; set; }

    public bool DeepEquals(DestinyCraftablesComponent? other)
    {
        return other is not null &&
               Craftables.DeepEqualsDictionary(other.Craftables) &&
               CraftingRootNodeHash == other.CraftingRootNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCraftablesComponent? other)
    {
        if (other is null) return;
        if (!Craftables.DeepEqualsDictionary(other.Craftables))
        {
            Craftables = other.Craftables;
            OnPropertyChanged(nameof(Craftables));
        }
        if (CraftingRootNodeHash != other.CraftingRootNodeHash)
        {
            CraftingRootNodeHash = other.CraftingRootNodeHash;
            OnPropertyChanged(nameof(CraftingRootNodeHash));
        }
    }
}