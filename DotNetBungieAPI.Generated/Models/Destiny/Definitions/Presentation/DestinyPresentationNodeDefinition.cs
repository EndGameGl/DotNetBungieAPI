using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("originalIcon")]
    public string OriginalIcon { get; init; }

    [JsonPropertyName("rootViewIcon")]
    public string RootViewIcon { get; init; }

    [JsonPropertyName("nodeType")]
    public Destiny.DestinyPresentationNodeType NodeType { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }

    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; init; }

    [JsonPropertyName("completionRecordHash")]
    public uint? CompletionRecordHash { get; init; }

    [JsonPropertyName("children")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeChildrenBlock Children { get; init; }

    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; init; }

    [JsonPropertyName("screenStyle")]
    public Destiny.DestinyPresentationScreenStyle ScreenStyle { get; init; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; init; }

    [JsonPropertyName("disableChildSubscreenNavigation")]
    public bool DisableChildSubscreenNavigation { get; init; }

    [JsonPropertyName("maxCategoryRecordScore")]
    public int MaxCategoryRecordScore { get; init; }

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
