namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Items;

public class DestinyItemPlugObjectivesComponent : IDeepEquatable<DestinyItemPlugObjectivesComponent>
{
    /// <summary>
    ///     This set of data is keyed by the Item Hash (DestinyInventoryItemDefinition) of the plug whose objectives are being returned, with the value being the list of those objectives.
    /// <para />
    ///      What if two plugs with the same hash are returned for an item, you ask?
    /// <para />
    ///      Good question! They share the same item-scoped state, and as such would have identical objective state as a result. How's that for convenient.
    /// <para />
    ///      Sometimes, Plugs may have objectives: generally, these are used for flavor and display purposes. For instance, a Plug might be tracking the number of PVP kills you have made. It will use the parent item's data about that tracking status to determine what to show, and will generally show it using the DestinyObjectiveDefinition's progressDescription property. Refer to the plug's itemHash and objective property for more information if you would like to display even more data.
    /// </summary>
    [JsonPropertyName("objectivesPerPlug")]
    public Dictionary<uint, List<Destiny.Quests.DestinyObjectiveProgress>> ObjectivesPerPlug { get; set; }

    public bool DeepEquals(DestinyItemPlugObjectivesComponent? other)
    {
        return other is not null &&
               ObjectivesPerPlug.DeepEqualsDictionaryNaive(other.ObjectivesPerPlug);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemPlugObjectivesComponent? other)
    {
        if (other is null) return;
        if (!ObjectivesPerPlug.DeepEqualsDictionary(other.ObjectivesPerPlug))
        {
            ObjectivesPerPlug = other.ObjectivesPerPlug;
            OnPropertyChanged(nameof(ObjectivesPerPlug));
        }
    }
}