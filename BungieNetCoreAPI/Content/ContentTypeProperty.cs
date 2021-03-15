using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Content
{
    public class ContentTypeProperty
    {
        public string Name { get; }
        public string RootPropertyName { get; }
        public string ReadableName { get; }
        public string Value { get; }
        public string PropertyDescription { get; }
        public bool Localizable { get; }
        public bool Fallback { get; }
        public bool Enabled { get; }
        public int Order { get; }
        public bool Visible { get; }
        public bool IsTitle { get; }
        public bool Required { get; }
        public int MaxLength { get; }
        public int MaxByteLength { get; }
        public int MaxFileSize { get; }
        public string Regexp { get; }
        public string ValidateAs { get; }
        public string RssAttribute { get; }
        public string VisibleDependency { get; }
        public string VisibleOn { get; }
        public ContentPropertyDataTypeEnum Datatype { get; }
        public ReadOnlyDictionary<string, string> Attributes { get; }
        public ReadOnlyCollection<ContentTypeProperty> ChildProperties { get; }
        public string ContentTypeAllowed { get; }
        public string BindToProperty { get; }
        public string BoundRegex { get; }
        public ReadOnlyDictionary<string, string> RepresentationSelection { get; }
        public ReadOnlyCollection<ContentTypeDefaultValue> DefaultValues { get; }
        public bool IsExternalAllowed { get; }
        public string PropertySection { get; }
        public int Weight { get; }
        public string EntityType { get; }
        public bool IsCombo { get; }
        public bool SuppressProperty { get; }
        public ReadOnlyCollection<string> LegalContentTypes { get; }
        public string RepresentationValidationString { get; }
        public int MinWidth { get; }
        public int MaxWidth { get; }
        public int MinHeight { get; }
        public int MaxHeight { get; }
        public bool IsVideo { get; }
        public bool IsImage { get; }

        [JsonConstructor]
        internal ContentTypeProperty(string name, string rootPropertyName, string readableName, string value, string propertyDescription,bool localizable,
            bool fallback, bool enabled, int order, bool visible, bool isTitle, bool required, int maxLength, int maxByteLength, int maxFileSize,
            string regexp, string validateAs, string rssAttribute, string visibleDependency, string visibleOn, ContentPropertyDataTypeEnum datatype,
            Dictionary<string, string> attributes, ContentTypeProperty[] childProperties, string contentTypeAllowed, string bindToProperty,
            string boundRegex, Dictionary<string, string> representationSelection, ContentTypeDefaultValue[] defaultValues, bool isExternalAllowed,
            string propertySection, int weight, string entitytype, bool isCombo, bool suppressProperty, string[] legalContentTypes,
            string representationValidationString, int minWidth, int maxWidth, int minHeight, int maxHeight, bool isVideo, bool isImage)
        {
            Name = name;
            RootPropertyName = rootPropertyName;
            ReadableName = readableName;
            Value = value;
            PropertyDescription = propertyDescription;
            Localizable = localizable;
            Fallback = fallback;
            Enabled = enabled;
            Order = order;
            Visible = visible;
            IsTitle = isTitle;
            Required = required;
            MaxLength = maxLength;
            MaxByteLength = maxByteLength;
            MaxFileSize = maxFileSize;
            Regexp = regexp;
            ValidateAs = validateAs;
            RssAttribute = rssAttribute;
            VisibleDependency = visibleDependency;
            VisibleOn = visibleOn;
            Datatype = datatype;
            Attributes = attributes.AsReadOnlyDictionaryOrEmpty();
            ChildProperties = childProperties.AsReadOnlyOrEmpty();
            ContentTypeAllowed = contentTypeAllowed;
            BindToProperty = bindToProperty;
            BoundRegex = boundRegex;
            RepresentationSelection = representationSelection.AsReadOnlyDictionaryOrEmpty();
            DefaultValues = defaultValues.AsReadOnlyOrEmpty();
            IsExternalAllowed = isExternalAllowed;
            PropertySection = propertySection;
            Weight = weight;
            EntityType = entitytype;
            IsCombo = isCombo;
            SuppressProperty = suppressProperty;
            LegalContentTypes = legalContentTypes.AsReadOnlyOrEmpty();
            RepresentationValidationString = representationValidationString;
            MinWidth = minWidth;
            MaxWidth = maxWidth;
            MinHeight = minHeight;
            MaxHeight = maxHeight;
            IsVideo = isVideo;
            IsImage = isImage;
        }
    }
}
