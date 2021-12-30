using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; init; }

    [JsonPropertyName("loreHash")]
    public uint? LoreHash { get; init; }

    [JsonPropertyName("objectiveHashes")]
    public List<uint> ObjectiveHashes { get; init; }

    [JsonPropertyName("recordValueStyle")]
    public Destiny.DestinyRecordValueStyle RecordValueStyle { get; init; }

    [JsonPropertyName("forTitleGilding")]
    public bool ForTitleGilding { get; init; }

    [JsonPropertyName("titleInfo")]
    public Destiny.Definitions.Records.DestinyRecordTitleBlock TitleInfo { get; init; }

    [JsonPropertyName("completionInfo")]
    public Destiny.Definitions.Records.DestinyRecordCompletionBlock CompletionInfo { get; init; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Records.SchemaRecordStateBlock StateInfo { get; init; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; init; }

    [JsonPropertyName("expirationInfo")]
    public Destiny.Definitions.Records.DestinyRecordExpirationBlock ExpirationInfo { get; init; }

    [JsonPropertyName("intervalInfo")]
    public Destiny.Definitions.Records.DestinyRecordIntervalBlock IntervalInfo { get; init; }

    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; init; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; init; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; init; }

    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
