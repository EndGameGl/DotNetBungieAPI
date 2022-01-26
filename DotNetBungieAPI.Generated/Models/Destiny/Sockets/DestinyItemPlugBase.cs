namespace DotNetBungieAPI.Generated.Models.Destiny.Sockets;

public class DestinyItemPlugBase : IDeepEquatable<DestinyItemPlugBase>
{
    /// <summary>
    ///     The hash identifier of the DestinyInventoryItemDefinition that represents this plug.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    /// <summary>
    ///     If true, this plug has met all of its insertion requirements. Big if true.
    /// </summary>
    [JsonPropertyName("canInsert")]
    public bool CanInsert { get; set; }

    /// <summary>
    ///     If true, this plug will provide its benefits while inserted.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    ///     If the plug cannot be inserted for some reason, this will have the indexes into the plug item definition's plug.insertionRules property, so you can show the reasons why it can't be inserted.
    /// <para />
    ///     This list will be empty if the plug can be inserted.
    /// </summary>
    [JsonPropertyName("insertFailIndexes")]
    public List<int> InsertFailIndexes { get; set; }

    /// <summary>
    ///     If a plug is not enabled, this will be populated with indexes into the plug item definition's plug.enabledRules property, so that you can show the reasons why it is not enabled.
    /// <para />
    ///     This list will be empty if the plug is enabled.
    /// </summary>
    [JsonPropertyName("enableFailIndexes")]
    public List<int> EnableFailIndexes { get; set; }

    public bool DeepEquals(DestinyItemPlugBase? other)
    {
        return other is not null &&
               PlugItemHash == other.PlugItemHash &&
               CanInsert == other.CanInsert &&
               Enabled == other.Enabled &&
               InsertFailIndexes.DeepEqualsListNaive(other.InsertFailIndexes) &&
               EnableFailIndexes.DeepEqualsListNaive(other.EnableFailIndexes);
    }
}