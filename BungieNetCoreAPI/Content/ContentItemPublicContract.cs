using NetBungieAPI.Bungie;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Content
{
    public class ContentItemPublicContract
    {
        public long ContentId { get; }
        public string ContentType { get; }
        public string CmsPath { get; }
        public DateTime CreationDate { get; }
        public DateTime ModifyDate { get; }
        public bool AllowComments { get; }
        public bool HasAgeGate { get; }
        public int MinimumAge { get; }
        public string RatingImagePath { get; }
        public BungieNetUser Author { get; }
        public bool AutoEnglishPropertyFallback { get; }
        public ReadOnlyDictionary<string, object> Properties { get; }
        public ReadOnlyCollection<ContentRepresentation> Representations { get; }
        public ReadOnlyCollection<string> Tags { get; }
        public CommentSummary CommentSummary { get; }

        [JsonConstructor]
        internal ContentItemPublicContract(long contentId, string cType, string cmsPath, DateTime creationDate, DateTime modifyDate, bool allowComments,
            bool hasAgeGate, int minimumAge, string ratingImagePath, BungieNetUser author, bool autoEnglishPropertyFallback, Dictionary<string, object> properties,
            ContentRepresentation[] representations, string[] tags, CommentSummary commentSummary)
        {
            ContentId = contentId;
            ContentType = cType;
            CmsPath = cmsPath;
            CreationDate = creationDate;
            ModifyDate = modifyDate;
            AllowComments = allowComments;
            HasAgeGate = hasAgeGate;
            MinimumAge = minimumAge;
            RatingImagePath = ratingImagePath;
            Author = author;
            AutoEnglishPropertyFallback = autoEnglishPropertyFallback;
            Properties = properties.AsReadOnlyDictionaryOrEmpty();
            Representations = representations.AsReadOnlyOrEmpty();
            Tags = tags.AsReadOnlyOrEmpty();
            CommentSummary = commentSummary;
        }
    }
}
