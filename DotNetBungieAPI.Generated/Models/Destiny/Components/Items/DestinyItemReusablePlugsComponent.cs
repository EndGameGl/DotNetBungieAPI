namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Items;

public class DestinyItemReusablePlugsComponent
{
    /// <summary>
    ///     If the item supports reusable plugs, this is the list of plugs that are allowed to be used for the socket, and any relevant information about whether they are "enabled", whether they are allowed to be inserted, and any other information such as objectives.
    /// <para />
    ///      A Reusable Plug is a plug that you can always insert into this socket as long as its insertion rules are passed, regardless of whether or not you have the plug in your inventory. An example of it failing an insertion rule would be if it has an Objective that needs to be completed before it can be inserted, and that objective hasn't been completed yet.
    /// <para />
    ///      In practice, a socket will *either* have reusable plugs *or* it will allow for plugs in your inventory to be inserted. See DestinyInventoryItemDefinition.socket for more info.
    /// <para />
    ///      KEY = The INDEX into the item's list of sockets. VALUE = The set of plugs for that socket.
    /// <para />
    ///      If a socket doesn't have any reusable plugs defined at the item scope, there will be no entry for that socket.
    /// </summary>
    [JsonPropertyName("plugs")]
    public Dictionary<int, Destiny.Sockets.DestinyItemPlugBase[]>? Plugs { get; set; }
}
