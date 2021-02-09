using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BungieNetCoreAPI
{
    public static class Extensions
    {
        internal static bool DeepEqualsReadOnlySimpleCollection<T>(this ReadOnlyCollection<T> compared, ReadOnlyCollection<T> comparedWith)
        {
            if (compared.Count != comparedWith.Count)
                return false;
            for (int i = 0; i < compared.Count; i++)
            {
                if (!compared[i].Equals(comparedWith[i]))
                    return false;
            }

            return true;
        }
        internal static bool DeepEqualsReadOnlyCollections<T>(this ReadOnlyCollection<T> compared, ReadOnlyCollection<T> comparedWith) where T : IDeepEquatable<T>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (int i = 0; i < compared.Count; i++)
            {
                if (!compared[i].DeepEquals(comparedWith[i]))
                    return false;
            }

            return true;
        }
        internal static bool DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue<T, P>(this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where T : IDeepEquatable<T>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (int i = 0; i < compared.Count; i++)
            {
                if (!compared.ElementAt(i).Key.DeepEquals(comparedWith.ElementAt(i).Key) || !compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value))
                    return false;
            }
            return true;
        }
        internal static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue<T, P>(this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where P: IDeepEquatable<P>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (int i = 0; i < compared.Count; i++)
            {
                if (!compared.ElementAt(i).Value.DeepEquals(comparedWith.ElementAt(i).Value) || !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                    return false;
            }
            return true;
        }
        internal static ReadOnlyCollection<T> AsReadOnlyOrEmpty<T>(this T[] source)
        {
            ReadOnlyCollection<T> readOnlyCollection;
            if (source != null)
                readOnlyCollection = new ReadOnlyCollection<T>(source);
            else
                readOnlyCollection = new ReadOnlyCollection<T>(new T[0]);
            return readOnlyCollection;
        }
        internal static ReadOnlyCollection<DefinitionHashPointer<T>> DefinitionsAsReadOnlyOrEmpty<T>(this uint[] source, DefinitionsEnum enumValue) where T : IDestinyDefinition
        {
            ReadOnlyCollection<DefinitionHashPointer<T>> readOnlyCollection;
            if (source != null)
                readOnlyCollection = new ReadOnlyCollection<DefinitionHashPointer<T>>(source.Select(x => new DefinitionHashPointer<T>(x, enumValue)).ToArray());
            else
                readOnlyCollection = new ReadOnlyCollection<DefinitionHashPointer<T>>(new DefinitionHashPointer<T>[0]);
            return readOnlyCollection;
        }
        internal static ReadOnlyDictionary<DefinitionHashPointer<T>, P> AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<T, P>(this Dictionary<uint, P> dictionary, DefinitionsEnum enumValue) where T : IDestinyDefinition
        {
            if (dictionary == null)
                return new ReadOnlyDictionary<DefinitionHashPointer<T>, P>(new Dictionary<DefinitionHashPointer<T>, P>(0));
            var convertedDict = dictionary.ToDictionary(x => new DefinitionHashPointer<T>(x.Key, enumValue), y => y.Value);
            return new ReadOnlyDictionary<DefinitionHashPointer<T>, P>(convertedDict);
        }
        internal static ReadOnlyDictionary<T, P> AsReadOnlyDictionaryOrEmpty<T, P>(this Dictionary<T,P> dictionary)
        {
            if (dictionary == null)
                return new ReadOnlyDictionary<T, P>(new Dictionary<T, P>(0));
            else
                return new ReadOnlyDictionary<T, P>(dictionary);

        }

        public static string LocaleToString(this DestinyLocales locale)
        {
            return locale switch
            {
                DestinyLocales.EN => "en",
                DestinyLocales.RU => "ru",
                DestinyLocales.DE => "de",
                DestinyLocales.ES => "es",
                DestinyLocales.ES_MX => "es-mx",
                DestinyLocales.FR => "fr",
                DestinyLocales.IT => "it",
                DestinyLocales.JA => "ja",
                DestinyLocales.KO => "ko",
                DestinyLocales.PL => "pl",
                DestinyLocales.PT_BR => "pt-br",
                DestinyLocales.ZH_CHS => "zh-chs",
                DestinyLocales.ZH_CHT => "zh-cht",
                _ => throw new Exception("Wrong locale."),
            };
        }

        #region Activity search
        public static List<DestinyActivityDefinition> GetActivitiesWithMode(this ILocalisedManifestDefinitionRepositories repository, DestinyLocales locale, uint activityModeHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale, x => (x as DestinyActivityDefinition).ActivityModes.Where(q => q.Hash.Equals(activityModeHash)).Count() > 0).ToList();
        }
        public static List<DestinyActivityDefinition> GetActivitiesWithMode(this ILocalisedManifestDefinitionRepositories repository, DestinyLocales locale, DestinyActivityModeType activityMode)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale, x => (x as DestinyActivityDefinition).ActivityModeTypes.Contains(activityMode)).ToList();
        }
        public static List<DestinyActivityDefinition> GetActivitiesWithDirectMode(this ILocalisedManifestDefinitionRepositories repository, DestinyLocales locale, uint activityModeHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale, x => (x as DestinyActivityDefinition).DirectActivityMode.Hash.Equals(activityModeHash)).ToList();
        }
        public static List<DestinyActivityDefinition> GetActivitiesWithDirectMode(this ILocalisedManifestDefinitionRepositories repository, DestinyLocales locale, DestinyActivityModeType activityMode)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale, x => (x as DestinyActivityDefinition).DirectActivityModeType.Equals(activityMode)).ToList();
        }
        public static List<DestinyActivityDefinition> GetActivitiesWithPlace(this ILocalisedManifestDefinitionRepositories repository, DestinyLocales locale, uint placeHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale, x => (x as DestinyActivityDefinition).Place.Hash.Equals(placeHash)).ToList();
        }
        public static List<DestinyActivityDefinition> GetActivitiesWithDestination(this ILocalisedManifestDefinitionRepositories repository, DestinyLocales locale, uint destinationHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale, x => (x as DestinyActivityDefinition).Destination.Hash.Equals(destinationHash)).ToList();
        }

        public static IEnumerable<DestinyActivityDefinition> WithMode(this IEnumerable<DestinyActivityDefinition> definitions, DestinyActivityModeType activityMode)
        {
            return definitions.Where(x => x.ActivityModeTypes.Contains(activityMode));
        }
        public static IEnumerable<DestinyActivityDefinition> WithDirectMode(this IEnumerable<DestinyActivityDefinition> definitions, DestinyActivityModeType activityMode)
        {
            return definitions.Where(x => x.DirectActivityModeType.Equals(activityMode));
        }
        public static IEnumerable<DestinyActivityDefinition> WithPlace(this IEnumerable<DestinyActivityDefinition> definitions, uint placeHash)
        {
            return definitions.Where(x => x.Place.Hash.Equals(placeHash));
        }
        public static IEnumerable<DestinyActivityDefinition> WithDestination(this IEnumerable<DestinyActivityDefinition> definitions, uint destinationHash)
        {
            return definitions.Where(x => x.Destination.Hash.Equals(destinationHash));
        }
        public static IEnumerable<DestinyActivityDefinition> IsPvP(this IEnumerable<DestinyActivityDefinition> definitions, bool isPvP)
        {
            return definitions.Where(x => x.IsPvP.Equals(isPvP));
        }
        public static IEnumerable<DestinyActivityDefinition> IsPlaylist(this IEnumerable<DestinyActivityDefinition> definitions, bool isPlaylist)
        {
            return definitions.Where(x => x.IsPlaylist.Equals(isPlaylist));
        }
        public static IEnumerable<DestinyActivityDefinition> InheritsFromFreeRoam(this IEnumerable<DestinyActivityDefinition> definitions, bool inheritFromFreeRoam)
        {
            return definitions.Where(x => x.InheritFromFreeRoam.Equals(inheritFromFreeRoam));
        }
        public static IEnumerable<DestinyActivityDefinition> WithName(this IEnumerable<DestinyActivityDefinition> definitions, string name)
        {
            return definitions.Where(x => x.DisplayProperties.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public static IEnumerable<DestinyActivityDefinition> WithDescription(this IEnumerable<DestinyActivityDefinition> definitions, string description)
        {
            return definitions.Where(x => x.DisplayProperties.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
        }
        #endregion
    }
}
