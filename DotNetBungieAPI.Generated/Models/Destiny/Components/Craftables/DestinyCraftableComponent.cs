namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftableComponent : IDeepEquatable<DestinyCraftableComponent>
{
    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    /// <summary>
    ///     If the requirements are not met for crafting this item, these will index into the list of failure strings.
    /// </summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public List<int> FailedRequirementIndexes { get; set; }

    /// <summary>
    ///     Plug item state for the crafting sockets.
    /// </summary>
    [JsonPropertyName("sockets")]
    public List<Destiny.Components.Craftables.DestinyCraftableSocketComponent> Sockets { get; set; }

    public bool DeepEquals(DestinyCraftableComponent? other)
    {
        return other is not null &&
               Visible == other.Visible &&
               FailedRequirementIndexes.DeepEqualsListNaive(other.FailedRequirementIndexes) &&
               Sockets.DeepEqualsList(other.Sockets);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCraftableComponent? other)
    {
        if (other is null) return;
        if (Visible != other.Visible)
        {
            Visible = other.Visible;
            OnPropertyChanged(nameof(Visible));
        }
        if (!FailedRequirementIndexes.DeepEqualsListNaive(other.FailedRequirementIndexes))
        {
            FailedRequirementIndexes = other.FailedRequirementIndexes;
            OnPropertyChanged(nameof(FailedRequirementIndexes));
        }
        if (!Sockets.DeepEqualsList(other.Sockets))
        {
            Sockets = other.Sockets;
            OnPropertyChanged(nameof(Sockets));
        }
    }
}