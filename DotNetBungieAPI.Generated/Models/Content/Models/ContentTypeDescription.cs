namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypeDescription : IDeepEquatable<ContentTypeDescription>
{
    [JsonPropertyName("cType")]
    public string CType { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("contentDescription")]
    public string ContentDescription { get; set; }

    [JsonPropertyName("previewImage")]
    public string PreviewImage { get; set; }

    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    [JsonPropertyName("reminder")]
    public string Reminder { get; set; }

    [JsonPropertyName("properties")]
    public List<Content.Models.ContentTypeProperty> Properties { get; set; }

    [JsonPropertyName("tagMetadata")]
    public List<Content.Models.TagMetadataDefinition> TagMetadata { get; set; }

    [JsonPropertyName("tagMetadataItems")]
    public Dictionary<string, Content.Models.TagMetadataItem> TagMetadataItems { get; set; }

    [JsonPropertyName("usageExamples")]
    public List<string> UsageExamples { get; set; }

    [JsonPropertyName("showInContentEditor")]
    public bool ShowInContentEditor { get; set; }

    [JsonPropertyName("typeOf")]
    public string TypeOf { get; set; }

    [JsonPropertyName("bindIdentifierToProperty")]
    public string BindIdentifierToProperty { get; set; }

    [JsonPropertyName("boundRegex")]
    public string BoundRegex { get; set; }

    [JsonPropertyName("forceIdentifierBinding")]
    public bool ForceIdentifierBinding { get; set; }

    [JsonPropertyName("allowComments")]
    public bool AllowComments { get; set; }

    [JsonPropertyName("autoEnglishPropertyFallback")]
    public bool AutoEnglishPropertyFallback { get; set; }

    [JsonPropertyName("bulkUploadable")]
    public bool BulkUploadable { get; set; }

    [JsonPropertyName("previews")]
    public List<Content.Models.ContentPreview> Previews { get; set; }

    [JsonPropertyName("suppressCmsPath")]
    public bool SuppressCmsPath { get; set; }

    [JsonPropertyName("propertySections")]
    public List<Content.Models.ContentTypePropertySection> PropertySections { get; set; }

    public bool DeepEquals(ContentTypeDescription? other)
    {
        return other is not null &&
               CType == other.CType &&
               Name == other.Name &&
               ContentDescription == other.ContentDescription &&
               PreviewImage == other.PreviewImage &&
               Priority == other.Priority &&
               Reminder == other.Reminder &&
               Properties.DeepEqualsList(other.Properties) &&
               TagMetadata.DeepEqualsList(other.TagMetadata) &&
               TagMetadataItems.DeepEqualsDictionary(other.TagMetadataItems) &&
               UsageExamples.DeepEqualsListNaive(other.UsageExamples) &&
               ShowInContentEditor == other.ShowInContentEditor &&
               TypeOf == other.TypeOf &&
               BindIdentifierToProperty == other.BindIdentifierToProperty &&
               BoundRegex == other.BoundRegex &&
               ForceIdentifierBinding == other.ForceIdentifierBinding &&
               AllowComments == other.AllowComments &&
               AutoEnglishPropertyFallback == other.AutoEnglishPropertyFallback &&
               BulkUploadable == other.BulkUploadable &&
               Previews.DeepEqualsList(other.Previews) &&
               SuppressCmsPath == other.SuppressCmsPath &&
               PropertySections.DeepEqualsList(other.PropertySections);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ContentTypeDescription? other)
    {
        if (other is null) return;
        if (CType != other.CType)
        {
            CType = other.CType;
            OnPropertyChanged(nameof(CType));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (ContentDescription != other.ContentDescription)
        {
            ContentDescription = other.ContentDescription;
            OnPropertyChanged(nameof(ContentDescription));
        }
        if (PreviewImage != other.PreviewImage)
        {
            PreviewImage = other.PreviewImage;
            OnPropertyChanged(nameof(PreviewImage));
        }
        if (Priority != other.Priority)
        {
            Priority = other.Priority;
            OnPropertyChanged(nameof(Priority));
        }
        if (Reminder != other.Reminder)
        {
            Reminder = other.Reminder;
            OnPropertyChanged(nameof(Reminder));
        }
        if (!Properties.DeepEqualsList(other.Properties))
        {
            Properties = other.Properties;
            OnPropertyChanged(nameof(Properties));
        }
        if (!TagMetadata.DeepEqualsList(other.TagMetadata))
        {
            TagMetadata = other.TagMetadata;
            OnPropertyChanged(nameof(TagMetadata));
        }
        if (!TagMetadataItems.DeepEqualsDictionary(other.TagMetadataItems))
        {
            TagMetadataItems = other.TagMetadataItems;
            OnPropertyChanged(nameof(TagMetadataItems));
        }
        if (!UsageExamples.DeepEqualsListNaive(other.UsageExamples))
        {
            UsageExamples = other.UsageExamples;
            OnPropertyChanged(nameof(UsageExamples));
        }
        if (ShowInContentEditor != other.ShowInContentEditor)
        {
            ShowInContentEditor = other.ShowInContentEditor;
            OnPropertyChanged(nameof(ShowInContentEditor));
        }
        if (TypeOf != other.TypeOf)
        {
            TypeOf = other.TypeOf;
            OnPropertyChanged(nameof(TypeOf));
        }
        if (BindIdentifierToProperty != other.BindIdentifierToProperty)
        {
            BindIdentifierToProperty = other.BindIdentifierToProperty;
            OnPropertyChanged(nameof(BindIdentifierToProperty));
        }
        if (BoundRegex != other.BoundRegex)
        {
            BoundRegex = other.BoundRegex;
            OnPropertyChanged(nameof(BoundRegex));
        }
        if (ForceIdentifierBinding != other.ForceIdentifierBinding)
        {
            ForceIdentifierBinding = other.ForceIdentifierBinding;
            OnPropertyChanged(nameof(ForceIdentifierBinding));
        }
        if (AllowComments != other.AllowComments)
        {
            AllowComments = other.AllowComments;
            OnPropertyChanged(nameof(AllowComments));
        }
        if (AutoEnglishPropertyFallback != other.AutoEnglishPropertyFallback)
        {
            AutoEnglishPropertyFallback = other.AutoEnglishPropertyFallback;
            OnPropertyChanged(nameof(AutoEnglishPropertyFallback));
        }
        if (BulkUploadable != other.BulkUploadable)
        {
            BulkUploadable = other.BulkUploadable;
            OnPropertyChanged(nameof(BulkUploadable));
        }
        if (!Previews.DeepEqualsList(other.Previews))
        {
            Previews = other.Previews;
            OnPropertyChanged(nameof(Previews));
        }
        if (SuppressCmsPath != other.SuppressCmsPath)
        {
            SuppressCmsPath = other.SuppressCmsPath;
            OnPropertyChanged(nameof(SuppressCmsPath));
        }
        if (!PropertySections.DeepEqualsList(other.PropertySections))
        {
            PropertySections = other.PropertySections;
            OnPropertyChanged(nameof(PropertySections));
        }
    }
}