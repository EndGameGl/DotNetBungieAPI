namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent : IDeepEquatable<DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemTalentGridComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent? other)
    {
        if (other is null) return;
        if (!Data.DeepEqualsDictionary(other.Data))
        {
            Data = other.Data;
            OnPropertyChanged(nameof(Data));
        }
        if (Privacy != other.Privacy)
        {
            Privacy = other.Privacy;
            OnPropertyChanged(nameof(Privacy));
        }
        if (Disabled != other.Disabled)
        {
            Disabled = other.Disabled;
            OnPropertyChanged(nameof(Disabled));
        }
    }
}