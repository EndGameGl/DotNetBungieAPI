namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

/// <summary>
///     A minimal view of a character's equipped items, for the purpose of rendering a summary screen or showing the character in 3D.
/// </summary>
public class DestinyCharacterPeerView : IDeepEquatable<DestinyCharacterPeerView>
{
    [JsonPropertyName("equipment")]
    public List<Destiny.Character.DestinyItemPeerView> Equipment { get; set; }

    public bool DeepEquals(DestinyCharacterPeerView? other)
    {
        return other is not null &&
               Equipment.DeepEqualsList(other.Equipment);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCharacterPeerView? other)
    {
        if (other is null) return;
        if (!Equipment.DeepEqualsList(other.Equipment))
        {
            Equipment = other.Equipment;
            OnPropertyChanged(nameof(Equipment));
        }
    }
}