namespace DotNetBungieAPI.Generated.Models.Content;

public class ContentItemPublicContract : IDeepEquatable<ContentItemPublicContract>
{
    [JsonPropertyName("contentId")]
    public long ContentId { get; set; }

    [JsonPropertyName("cType")]
    public string CType { get; set; }

    [JsonPropertyName("cmsPath")]
    public string CmsPath { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("modifyDate")]
    public DateTime ModifyDate { get; set; }

    [JsonPropertyName("allowComments")]
    public bool AllowComments { get; set; }

    [JsonPropertyName("hasAgeGate")]
    public bool HasAgeGate { get; set; }

    [JsonPropertyName("minimumAge")]
    public int MinimumAge { get; set; }

    [JsonPropertyName("ratingImagePath")]
    public string RatingImagePath { get; set; }

    [JsonPropertyName("author")]
    public User.GeneralUser Author { get; set; }

    [JsonPropertyName("autoEnglishPropertyFallback")]
    public bool AutoEnglishPropertyFallback { get; set; }

    /// <summary>
    ///     Firehose content is really a collection of metadata and "properties", which are the potentially-but-not-strictly localizable data that comprises the meat of whatever content is being shown.
    /// <para />
    ///     As Cole Porter would have crooned, "Anything Goes" with Firehose properties. They are most often strings, but they can theoretically be anything. They are JSON encoded, and could be JSON structures, simple strings, numbers etc... The Content Type of the item (cType) will describe the properties, and thus how they ought to be deserialized.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object> Properties { get; set; }

    [JsonPropertyName("representations")]
    public List<Content.ContentRepresentation> Representations { get; set; }

    /// <summary>
    ///     NOTE: Tags will always be lower case.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("commentSummary")]
    public Content.CommentSummary CommentSummary { get; set; }

    public bool DeepEquals(ContentItemPublicContract? other)
    {
        return other is not null &&
               ContentId == other.ContentId &&
               CType == other.CType &&
               CmsPath == other.CmsPath &&
               CreationDate == other.CreationDate &&
               ModifyDate == other.ModifyDate &&
               AllowComments == other.AllowComments &&
               HasAgeGate == other.HasAgeGate &&
               MinimumAge == other.MinimumAge &&
               RatingImagePath == other.RatingImagePath &&
               (Author is not null ? Author.DeepEquals(other.Author) : other.Author is null) &&
               AutoEnglishPropertyFallback == other.AutoEnglishPropertyFallback &&
               Properties.DeepEqualsDictionaryNaive(other.Properties) &&
               Representations.DeepEqualsList(other.Representations) &&
               Tags.DeepEqualsListNaive(other.Tags) &&
               (CommentSummary is not null ? CommentSummary.DeepEquals(other.CommentSummary) : other.CommentSummary is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ContentItemPublicContract? other)
    {
        if (other is null) return;
        if (ContentId != other.ContentId)
        {
            ContentId = other.ContentId;
            OnPropertyChanged(nameof(ContentId));
        }
        if (CType != other.CType)
        {
            CType = other.CType;
            OnPropertyChanged(nameof(CType));
        }
        if (CmsPath != other.CmsPath)
        {
            CmsPath = other.CmsPath;
            OnPropertyChanged(nameof(CmsPath));
        }
        if (CreationDate != other.CreationDate)
        {
            CreationDate = other.CreationDate;
            OnPropertyChanged(nameof(CreationDate));
        }
        if (ModifyDate != other.ModifyDate)
        {
            ModifyDate = other.ModifyDate;
            OnPropertyChanged(nameof(ModifyDate));
        }
        if (AllowComments != other.AllowComments)
        {
            AllowComments = other.AllowComments;
            OnPropertyChanged(nameof(AllowComments));
        }
        if (HasAgeGate != other.HasAgeGate)
        {
            HasAgeGate = other.HasAgeGate;
            OnPropertyChanged(nameof(HasAgeGate));
        }
        if (MinimumAge != other.MinimumAge)
        {
            MinimumAge = other.MinimumAge;
            OnPropertyChanged(nameof(MinimumAge));
        }
        if (RatingImagePath != other.RatingImagePath)
        {
            RatingImagePath = other.RatingImagePath;
            OnPropertyChanged(nameof(RatingImagePath));
        }
        if (!Author.DeepEquals(other.Author))
        {
            Author.Update(other.Author);
            OnPropertyChanged(nameof(Author));
        }
        if (AutoEnglishPropertyFallback != other.AutoEnglishPropertyFallback)
        {
            AutoEnglishPropertyFallback = other.AutoEnglishPropertyFallback;
            OnPropertyChanged(nameof(AutoEnglishPropertyFallback));
        }
        if (!Properties.DeepEqualsDictionary(other.Properties))
        {
            Properties = other.Properties;
            OnPropertyChanged(nameof(Properties));
        }
        if (!Representations.DeepEqualsList(other.Representations))
        {
            Representations = other.Representations;
            OnPropertyChanged(nameof(Representations));
        }
        if (!Tags.DeepEqualsListNaive(other.Tags))
        {
            Tags = other.Tags;
            OnPropertyChanged(nameof(Tags));
        }
        if (!CommentSummary.DeepEquals(other.CommentSummary))
        {
            CommentSummary.Update(other.CommentSummary);
            OnPropertyChanged(nameof(CommentSummary));
        }
    }
}