namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     Instanced items can have sockets, which are slots on the item where plugs can be inserted.
/// <para />
///     Sockets are a bit complex: be sure to examine the documentation on the DestinyInventoryItemDefinition's "socket" block and elsewhere on these objects for more details.
/// </summary>
public class DestinyItemSocketsComponent
{
    /// <summary>
    ///     The list of all sockets on the item, and their status information.
    /// </summary>
    [JsonPropertyName("sockets")]
    public List<Destiny.Entities.Items.DestinyItemSocketState> Sockets { get; set; }
}
