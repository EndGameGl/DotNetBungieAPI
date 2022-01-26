namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypeProperty : IDeepEquatable<ContentTypeProperty>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rootPropertyName")]
    public string RootPropertyName { get; set; }

    [JsonPropertyName("readableName")]
    public string ReadableName { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("propertyDescription")]
    public string PropertyDescription { get; set; }

    [JsonPropertyName("localizable")]
    public bool Localizable { get; set; }

    [JsonPropertyName("fallback")]
    public bool Fallback { get; set; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    [JsonPropertyName("isTitle")]
    public bool IsTitle { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("maxLength")]
    public int MaxLength { get; set; }

    [JsonPropertyName("maxByteLength")]
    public int MaxByteLength { get; set; }

    [JsonPropertyName("maxFileSize")]
    public int MaxFileSize { get; set; }

    [JsonPropertyName("regexp")]
    public string Regexp { get; set; }

    [JsonPropertyName("validateAs")]
    public string ValidateAs { get; set; }

    [JsonPropertyName("rssAttribute")]
    public string RssAttribute { get; set; }

    [JsonPropertyName("visibleDependency")]
    public string VisibleDependency { get; set; }

    [JsonPropertyName("visibleOn")]
    public string VisibleOn { get; set; }

    [JsonPropertyName("datatype")]
    public Content.Models.ContentPropertyDataTypeEnum Datatype { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, string> Attributes { get; set; }

    [JsonPropertyName("childProperties")]
    public List<Content.Models.ContentTypeProperty> ChildProperties { get; set; }

    [JsonPropertyName("contentTypeAllowed")]
    public string ContentTypeAllowed { get; set; }

    [JsonPropertyName("bindToProperty")]
    public string BindToProperty { get; set; }

    [JsonPropertyName("boundRegex")]
    public string BoundRegex { get; set; }

    [JsonPropertyName("representationSelection")]
    public Dictionary<string, string> RepresentationSelection { get; set; }

    [JsonPropertyName("defaultValues")]
    public List<Content.Models.ContentTypeDefaultValue> DefaultValues { get; set; }

    [JsonPropertyName("isExternalAllowed")]
    public bool IsExternalAllowed { get; set; }

    [JsonPropertyName("propertySection")]
    public string PropertySection { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("entitytype")]
    public string Entitytype { get; set; }

    [JsonPropertyName("isCombo")]
    public bool IsCombo { get; set; }

    [JsonPropertyName("suppressProperty")]
    public bool SuppressProperty { get; set; }

    [JsonPropertyName("legalContentTypes")]
    public List<string> LegalContentTypes { get; set; }

    [JsonPropertyName("representationValidationString")]
    public string RepresentationValidationString { get; set; }

    [JsonPropertyName("minWidth")]
    public int MinWidth { get; set; }

    [JsonPropertyName("maxWidth")]
    public int MaxWidth { get; set; }

    [JsonPropertyName("minHeight")]
    public int MinHeight { get; set; }

    [JsonPropertyName("maxHeight")]
    public int MaxHeight { get; set; }

    [JsonPropertyName("isVideo")]
    public bool IsVideo { get; set; }

    [JsonPropertyName("isImage")]
    public bool IsImage { get; set; }

    public bool DeepEquals(ContentTypeProperty? other)
    {
        return other is not null &&
               Name == other.Name &&
               RootPropertyName == other.RootPropertyName &&
               ReadableName == other.ReadableName &&
               Value == other.Value &&
               PropertyDescription == other.PropertyDescription &&
               Localizable == other.Localizable &&
               Fallback == other.Fallback &&
               Enabled == other.Enabled &&
               Order == other.Order &&
               Visible == other.Visible &&
               IsTitle == other.IsTitle &&
               Required == other.Required &&
               MaxLength == other.MaxLength &&
               MaxByteLength == other.MaxByteLength &&
               MaxFileSize == other.MaxFileSize &&
               Regexp == other.Regexp &&
               ValidateAs == other.ValidateAs &&
               RssAttribute == other.RssAttribute &&
               VisibleDependency == other.VisibleDependency &&
               VisibleOn == other.VisibleOn &&
               Datatype == other.Datatype &&
               Attributes.DeepEqualsDictionaryNaive(other.Attributes) &&
               ChildProperties.DeepEqualsList(other.ChildProperties) &&
               ContentTypeAllowed == other.ContentTypeAllowed &&
               BindToProperty == other.BindToProperty &&
               BoundRegex == other.BoundRegex &&
               RepresentationSelection.DeepEqualsDictionaryNaive(other.RepresentationSelection) &&
               DefaultValues.DeepEqualsList(other.DefaultValues) &&
               IsExternalAllowed == other.IsExternalAllowed &&
               PropertySection == other.PropertySection &&
               Weight == other.Weight &&
               Entitytype == other.Entitytype &&
               IsCombo == other.IsCombo &&
               SuppressProperty == other.SuppressProperty &&
               LegalContentTypes.DeepEqualsListNaive(other.LegalContentTypes) &&
               RepresentationValidationString == other.RepresentationValidationString &&
               MinWidth == other.MinWidth &&
               MaxWidth == other.MaxWidth &&
               MinHeight == other.MinHeight &&
               MaxHeight == other.MaxHeight &&
               IsVideo == other.IsVideo &&
               IsImage == other.IsImage;
    }
}