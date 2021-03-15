using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Content
{
    public class ContentTypeDescription
    {
        public string ContentType { get; }
        public string Name { get; }
        public string ContentDescription { get; }
        public string PreviewImage { get; }
        public int Priority { get; }
        public string Reminder { get; }
        public ReadOnlyCollection<ContentTypeProperty> Properties { get; }
        public ReadOnlyCollection<TagMetadataDefinition> TagMetadata { get; }
        public ReadOnlyDictionary<string, TagMetadataItem> TagMetadataItems { get; }
        public ReadOnlyCollection<string> UsageExamples { get; }
        public bool ShowInContentEditor { get; }
        public string TypeOf { get; }
        public string BindIdentifierToProperty { get; }
        public string BoundRegex { get; }
        public bool ForceIdentifierBinding { get; }
        public bool AllowComments { get; }
        public bool AutoEnglishPropertyFallback { get; }
        public bool BulkUploadable { get; }
        public ReadOnlyCollection<ContentPreview> Previews { get; }
        public bool SuppressCmsPath { get; }
        public ReadOnlyCollection<ContentTypePropertySection> PropertySections { get; }

        [JsonConstructor]
        internal ContentTypeDescription(string cType, string name, string contentDescription, string previewImage, int priority, string reminder,
            ContentTypeProperty[] properties, TagMetadataDefinition[] tagMetadata, Dictionary<string, TagMetadataItem> tagMetadataItems, string[] usageExamples,
            bool showInContentEditor, string typeOf, string bindIdentifierToProperty, string boundRegex, bool forceIdentifierBinding, bool allowComments,
            bool autoEnglishPropertyFallback, bool bulkUploadable, ContentPreview[] previews, bool suppressCmsPath, ContentTypePropertySection[] propertySections)
        {
            ContentType = cType;
            Name = name;
            ContentDescription = contentDescription;
            PreviewImage = previewImage;
            Priority = priority;
            Reminder = reminder;
            Properties = properties.AsReadOnlyOrEmpty();
            TagMetadata = tagMetadata.AsReadOnlyOrEmpty();
            TagMetadataItems = tagMetadataItems.AsReadOnlyDictionaryOrEmpty();
            UsageExamples = usageExamples.AsReadOnlyOrEmpty();
            ShowInContentEditor = showInContentEditor;
            TypeOf = typeOf;
            BindIdentifierToProperty = bindIdentifierToProperty;
            BoundRegex = boundRegex;
            ForceIdentifierBinding = forceIdentifierBinding;
            AllowComments = allowComments;
            AutoEnglishPropertyFallback = autoEnglishPropertyFallback;
            BulkUploadable = bulkUploadable;
            Previews = previews.AsReadOnlyOrEmpty();
            SuppressCmsPath = suppressCmsPath;
            PropertySections = propertySections.AsReadOnlyOrEmpty();
        }
    }
}
