namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     The response object for retrieving an individual instanced item. None of these components are relevant for an item that doesn't have an "itemInstanceId": for those, get your information from the DestinyInventoryDefinition.
/// </summary>
public class DestinyItemResponse : IDeepEquatable<DestinyItemResponse>
{
    /// <summary>
    ///     If the item is on a character, this will return the ID of the character that is holding the item.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long? CharacterId { get; set; }

    /// <summary>
    ///     Common data for the item relevant to its non-instanced properties.
    /// <para />
    ///     COMPONENT TYPE: ItemCommonData
    /// </summary>
    [JsonPropertyName("item")]
    public SingleComponentResponseOfDestinyItemComponent Item { get; set; }

    /// <summary>
    ///     Basic instance data for the item.
    /// <para />
    ///     COMPONENT TYPE: ItemInstances
    /// </summary>
    [JsonPropertyName("instance")]
    public SingleComponentResponseOfDestinyItemInstanceComponent Instance { get; set; }

    /// <summary>
    ///     Information specifically about the item's objectives.
    /// <para />
    ///     COMPONENT TYPE: ItemObjectives
    /// </summary>
    [JsonPropertyName("objectives")]
    public SingleComponentResponseOfDestinyItemObjectivesComponent Objectives { get; set; }

    /// <summary>
    ///     Information specifically about the perks currently active on the item.
    /// <para />
    ///     COMPONENT TYPE: ItemPerks
    /// </summary>
    [JsonPropertyName("perks")]
    public SingleComponentResponseOfDestinyItemPerksComponent Perks { get; set; }

    /// <summary>
    ///     Information about how to render the item in 3D.
    /// <para />
    ///     COMPONENT TYPE: ItemRenderData
    /// </summary>
    [JsonPropertyName("renderData")]
    public SingleComponentResponseOfDestinyItemRenderComponent RenderData { get; set; }

    /// <summary>
    ///     Information about the computed stats of the item: power, defense, etc...
    /// <para />
    ///     COMPONENT TYPE: ItemStats
    /// </summary>
    [JsonPropertyName("stats")]
    public SingleComponentResponseOfDestinyItemStatsComponent Stats { get; set; }

    /// <summary>
    ///     Information about the talent grid attached to the item. Talent nodes can provide a variety of benefits and abilities, and in Destiny 2 are used almost exclusively for the character's "Builds".
    /// <para />
    ///     COMPONENT TYPE: ItemTalentGrids
    /// </summary>
    [JsonPropertyName("talentGrid")]
    public SingleComponentResponseOfDestinyItemTalentGridComponent TalentGrid { get; set; }

    /// <summary>
    ///     Information about the sockets of the item: which are currently active, what potential sockets you could have and the stats/abilities/perks you can gain from them.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("sockets")]
    public SingleComponentResponseOfDestinyItemSocketsComponent Sockets { get; set; }

    /// <summary>
    ///     Information about the Reusable Plugs for sockets on an item. These are plugs that you can insert into the given socket regardless of if you actually own an instance of that plug: they are logic-driven plugs rather than inventory-driven.
    /// <para />
    ///      These may need to be combined with Plug Set component data to get a full picture of available plugs on a given socket.
    /// <para />
    ///      COMPONENT TYPE: ItemReusablePlugs
    /// </summary>
    [JsonPropertyName("reusablePlugs")]
    public SingleComponentResponseOfDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

    /// <summary>
    ///     Information about objectives on Plugs for a given item. See the component's documentation for more info.
    /// <para />
    ///     COMPONENT TYPE: ItemPlugObjectives
    /// </summary>
    [JsonPropertyName("plugObjectives")]
    public SingleComponentResponseOfDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }

    public bool DeepEquals(DestinyItemResponse? other)
    {
        return other is not null &&
               CharacterId == other.CharacterId &&
               (Item is not null ? Item.DeepEquals(other.Item) : other.Item is null) &&
               (Instance is not null ? Instance.DeepEquals(other.Instance) : other.Instance is null) &&
               (Objectives is not null ? Objectives.DeepEquals(other.Objectives) : other.Objectives is null) &&
               (Perks is not null ? Perks.DeepEquals(other.Perks) : other.Perks is null) &&
               (RenderData is not null ? RenderData.DeepEquals(other.RenderData) : other.RenderData is null) &&
               (Stats is not null ? Stats.DeepEquals(other.Stats) : other.Stats is null) &&
               (TalentGrid is not null ? TalentGrid.DeepEquals(other.TalentGrid) : other.TalentGrid is null) &&
               (Sockets is not null ? Sockets.DeepEquals(other.Sockets) : other.Sockets is null) &&
               (ReusablePlugs is not null ? ReusablePlugs.DeepEquals(other.ReusablePlugs) : other.ReusablePlugs is null) &&
               (PlugObjectives is not null ? PlugObjectives.DeepEquals(other.PlugObjectives) : other.PlugObjectives is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemResponse? other)
    {
        if (other is null) return;
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (!Item.DeepEquals(other.Item))
        {
            Item.Update(other.Item);
            OnPropertyChanged(nameof(Item));
        }
        if (!Instance.DeepEquals(other.Instance))
        {
            Instance.Update(other.Instance);
            OnPropertyChanged(nameof(Instance));
        }
        if (!Objectives.DeepEquals(other.Objectives))
        {
            Objectives.Update(other.Objectives);
            OnPropertyChanged(nameof(Objectives));
        }
        if (!Perks.DeepEquals(other.Perks))
        {
            Perks.Update(other.Perks);
            OnPropertyChanged(nameof(Perks));
        }
        if (!RenderData.DeepEquals(other.RenderData))
        {
            RenderData.Update(other.RenderData);
            OnPropertyChanged(nameof(RenderData));
        }
        if (!Stats.DeepEquals(other.Stats))
        {
            Stats.Update(other.Stats);
            OnPropertyChanged(nameof(Stats));
        }
        if (!TalentGrid.DeepEquals(other.TalentGrid))
        {
            TalentGrid.Update(other.TalentGrid);
            OnPropertyChanged(nameof(TalentGrid));
        }
        if (!Sockets.DeepEquals(other.Sockets))
        {
            Sockets.Update(other.Sockets);
            OnPropertyChanged(nameof(Sockets));
        }
        if (!ReusablePlugs.DeepEquals(other.ReusablePlugs))
        {
            ReusablePlugs.Update(other.ReusablePlugs);
            OnPropertyChanged(nameof(ReusablePlugs));
        }
        if (!PlugObjectives.DeepEquals(other.PlugObjectives))
        {
            PlugObjectives.Update(other.PlugObjectives);
            OnPropertyChanged(nameof(PlugObjectives));
        }
    }
}