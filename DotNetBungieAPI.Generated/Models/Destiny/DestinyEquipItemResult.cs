namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     The results of an Equipping operation performed through the Destiny API.
/// </summary>
public sealed class DestinyEquipItemResult
{

    /// <summary>
    ///     The instance ID of the item in question (all items that can be equipped must, but definition, be Instanced and thus have an Instance ID that you can use to refer to them)
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    /// <summary>
    ///     A PlatformErrorCodes enum indicating whether it succeeded, and if it failed why.
    /// </summary>
    [JsonPropertyName("equipStatus")]
    public Exceptions.PlatformErrorCodes EquipStatus { get; init; }
}
