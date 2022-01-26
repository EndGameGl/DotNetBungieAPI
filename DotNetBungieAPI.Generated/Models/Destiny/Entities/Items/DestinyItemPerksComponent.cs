namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     Instanced items can have perks: benefits that the item bestows.
/// <para />
///     These are related to DestinySandboxPerkDefinition, and sometimes - but not always - have human readable info. When they do, they are the icons and text that you see in an item's tooltip.
/// <para />
///     Talent Grids, Sockets, and the item itself can apply Perks, which are then summarized here for your convenience.
/// </summary>
public class DestinyItemPerksComponent : IDeepEquatable<DestinyItemPerksComponent>
{
    /// <summary>
    ///     The list of perks to display in an item tooltip - and whether or not they have been activated.
    /// </summary>
    [JsonPropertyName("perks")]
    public List<Destiny.Perks.DestinyPerkReference> Perks { get; set; }

    public bool DeepEquals(DestinyItemPerksComponent? other)
    {
        return other is not null &&
               Perks.DeepEqualsList(other.Perks);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemPerksComponent? other)
    {
        if (other is null) return;
        if (!Perks.DeepEqualsList(other.Perks))
        {
            Perks = other.Perks;
            OnPropertyChanged(nameof(Perks));
        }
    }
}