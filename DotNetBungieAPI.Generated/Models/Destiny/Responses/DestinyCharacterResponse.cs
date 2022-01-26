namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     The response contract for GetDestinyCharacter, with components that can be returned for character and item-level data.
/// </summary>
public class DestinyCharacterResponse : IDeepEquatable<DestinyCharacterResponse>
{
    /// <summary>
    ///     The character-level non-equipped inventory items.
    /// <para />
    ///     COMPONENT TYPE: CharacterInventories
    /// </summary>
    [JsonPropertyName("inventory")]
    public SingleComponentResponseOfDestinyInventoryComponent Inventory { get; set; }

    /// <summary>
    ///     Base information about the character in question.
    /// <para />
    ///     COMPONENT TYPE: Characters
    /// </summary>
    [JsonPropertyName("character")]
    public SingleComponentResponseOfDestinyCharacterComponent Character { get; set; }

    /// <summary>
    ///     Character progression data, including Milestones.
    /// <para />
    ///     COMPONENT TYPE: CharacterProgressions
    /// </summary>
    [JsonPropertyName("progressions")]
    public SingleComponentResponseOfDestinyCharacterProgressionComponent Progressions { get; set; }

    /// <summary>
    ///     Character rendering data - a minimal set of information about equipment and dyes used for rendering.
    /// <para />
    ///     COMPONENT TYPE: CharacterRenderData
    /// </summary>
    [JsonPropertyName("renderData")]
    public SingleComponentResponseOfDestinyCharacterRenderComponent RenderData { get; set; }

    /// <summary>
    ///     Activity data - info about current activities available to the player.
    /// <para />
    ///     COMPONENT TYPE: CharacterActivities
    /// </summary>
    [JsonPropertyName("activities")]
    public SingleComponentResponseOfDestinyCharacterActivitiesComponent Activities { get; set; }

    /// <summary>
    ///     Equipped items on the character.
    /// <para />
    ///     COMPONENT TYPE: CharacterEquipment
    /// </summary>
    [JsonPropertyName("equipment")]
    public SingleComponentResponseOfDestinyInventoryComponent Equipment { get; set; }

    /// <summary>
    ///     Items available from Kiosks that are available to this specific character. 
    /// <para />
    ///     COMPONENT TYPE: Kiosks
    /// </summary>
    [JsonPropertyName("kiosks")]
    public SingleComponentResponseOfDestinyKiosksComponent Kiosks { get; set; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states that are scoped to this character.
    /// <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("plugSets")]
    public SingleComponentResponseOfDestinyPlugSetsComponent PlugSets { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: PresentationNodes
    /// </summary>
    [JsonPropertyName("presentationNodes")]
    public SingleComponentResponseOfDestinyPresentationNodesComponent PresentationNodes { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Records
    /// </summary>
    [JsonPropertyName("records")]
    public SingleComponentResponseOfDestinyCharacterRecordsComponent Records { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("collectibles")]
    public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; set; }

    /// <summary>
    ///     The set of components belonging to the player's instanced items.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint64 ItemComponents { get; set; }

    /// <summary>
    ///     The set of components belonging to the player's UNinstanced items. Because apparently now those too can have information relevant to the character's state.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("uninstancedItemComponents")]
    public DestinyBaseItemComponentSetOfuint32 UninstancedItemComponents { get; set; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; set; }

    public bool DeepEquals(DestinyCharacterResponse? other)
    {
        return other is not null &&
               (Inventory is not null ? Inventory.DeepEquals(other.Inventory) : other.Inventory is null) &&
               (Character is not null ? Character.DeepEquals(other.Character) : other.Character is null) &&
               (Progressions is not null ? Progressions.DeepEquals(other.Progressions) : other.Progressions is null) &&
               (RenderData is not null ? RenderData.DeepEquals(other.RenderData) : other.RenderData is null) &&
               (Activities is not null ? Activities.DeepEquals(other.Activities) : other.Activities is null) &&
               (Equipment is not null ? Equipment.DeepEquals(other.Equipment) : other.Equipment is null) &&
               (Kiosks is not null ? Kiosks.DeepEquals(other.Kiosks) : other.Kiosks is null) &&
               (PlugSets is not null ? PlugSets.DeepEquals(other.PlugSets) : other.PlugSets is null) &&
               (PresentationNodes is not null ? PresentationNodes.DeepEquals(other.PresentationNodes) : other.PresentationNodes is null) &&
               (Records is not null ? Records.DeepEquals(other.Records) : other.Records is null) &&
               (Collectibles is not null ? Collectibles.DeepEquals(other.Collectibles) : other.Collectibles is null) &&
               (ItemComponents is not null ? ItemComponents.DeepEquals(other.ItemComponents) : other.ItemComponents is null) &&
               (UninstancedItemComponents is not null ? UninstancedItemComponents.DeepEquals(other.UninstancedItemComponents) : other.UninstancedItemComponents is null) &&
               (CurrencyLookups is not null ? CurrencyLookups.DeepEquals(other.CurrencyLookups) : other.CurrencyLookups is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCharacterResponse? other)
    {
        if (other is null) return;
        if (!Inventory.DeepEquals(other.Inventory))
        {
            Inventory.Update(other.Inventory);
            OnPropertyChanged(nameof(Inventory));
        }
        if (!Character.DeepEquals(other.Character))
        {
            Character.Update(other.Character);
            OnPropertyChanged(nameof(Character));
        }
        if (!Progressions.DeepEquals(other.Progressions))
        {
            Progressions.Update(other.Progressions);
            OnPropertyChanged(nameof(Progressions));
        }
        if (!RenderData.DeepEquals(other.RenderData))
        {
            RenderData.Update(other.RenderData);
            OnPropertyChanged(nameof(RenderData));
        }
        if (!Activities.DeepEquals(other.Activities))
        {
            Activities.Update(other.Activities);
            OnPropertyChanged(nameof(Activities));
        }
        if (!Equipment.DeepEquals(other.Equipment))
        {
            Equipment.Update(other.Equipment);
            OnPropertyChanged(nameof(Equipment));
        }
        if (!Kiosks.DeepEquals(other.Kiosks))
        {
            Kiosks.Update(other.Kiosks);
            OnPropertyChanged(nameof(Kiosks));
        }
        if (!PlugSets.DeepEquals(other.PlugSets))
        {
            PlugSets.Update(other.PlugSets);
            OnPropertyChanged(nameof(PlugSets));
        }
        if (!PresentationNodes.DeepEquals(other.PresentationNodes))
        {
            PresentationNodes.Update(other.PresentationNodes);
            OnPropertyChanged(nameof(PresentationNodes));
        }
        if (!Records.DeepEquals(other.Records))
        {
            Records.Update(other.Records);
            OnPropertyChanged(nameof(Records));
        }
        if (!Collectibles.DeepEquals(other.Collectibles))
        {
            Collectibles.Update(other.Collectibles);
            OnPropertyChanged(nameof(Collectibles));
        }
        if (!ItemComponents.DeepEquals(other.ItemComponents))
        {
            ItemComponents.Update(other.ItemComponents);
            OnPropertyChanged(nameof(ItemComponents));
        }
        if (!UninstancedItemComponents.DeepEquals(other.UninstancedItemComponents))
        {
            UninstancedItemComponents.Update(other.UninstancedItemComponents);
            OnPropertyChanged(nameof(UninstancedItemComponents));
        }
        if (!CurrencyLookups.DeepEquals(other.CurrencyLookups))
        {
            CurrencyLookups.Update(other.CurrencyLookups);
            OnPropertyChanged(nameof(CurrencyLookups));
        }
    }
}