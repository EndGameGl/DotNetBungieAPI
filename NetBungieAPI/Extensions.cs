using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NetBungieAPI.Clients.Settings;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Repositories;

namespace NetBungieAPI
{
    public static class Extensions
    {
        public static IServiceCollection UseBungieApiClient(this IServiceCollection services,
            Action<BungieClientSettings> configure)
        {
            var client = BungieApiBuilder.GetApiClient(configure);
            return services.AddSingleton(client);
        }

        internal static bool DeepEqualsReadOnlySimpleCollection<T>(this ReadOnlyCollection<T> compared,
            ReadOnlyCollection<T> comparedWith)
        {
            if (compared.Count != comparedWith.Count)
                return false;
            for (var i = 0; i < compared.Count; i++)
                if (!compared[i].Equals(comparedWith[i]))
                    return false;

            return true;
        }

        internal static bool DeepEqualsReadOnlyCollections<T>(this ReadOnlyCollection<T> compared,
            ReadOnlyCollection<T> comparedWith) where T : IDeepEquatable<T>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared[i].DeepEquals(comparedWith[i]))
                    return false;

            return true;
        }

        internal static bool DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue<T, P>(
            this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where T : IDeepEquatable<T>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared.ElementAt(i).Key.DeepEquals(comparedWith.ElementAt(i).Key) ||
                    !compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value))
                    return false;
            return true;
        }

        internal static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue<T, P>(
            this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where P : IDeepEquatable<P>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared.ElementAt(i).Value.DeepEquals(comparedWith.ElementAt(i).Value) ||
                    !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                    return false;
            return true;
        }

        internal static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue<T, P>(
            this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith)
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value) ||
                    !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                    return false;
            return true;
        }

        internal static ReadOnlyCollection<T> AsReadOnlyOrEmpty<T>(this T[] source)
        {
            return source is null ? new ReadOnlyCollection<T>(Array.Empty<T>()) : new ReadOnlyCollection<T>(source);
        }

        internal static ReadOnlyCollection<DefinitionHashPointer<T>> DefinitionsAsReadOnlyOrEmpty<T>(this uint[] source,
            DefinitionsEnum enumValue) where T : IDestinyDefinition
        {
            if (source is null)
                return new ReadOnlyCollection<DefinitionHashPointer<T>>(Array.Empty<DefinitionHashPointer<T>>());
            IList<DefinitionHashPointer<T>> convertedList = new List<DefinitionHashPointer<T>>(source.Length);
            for (var i = 0; i < source.Length; i++) convertedList.Add(new DefinitionHashPointer<T>(source[i]));
            return new ReadOnlyCollection<DefinitionHashPointer<T>>(convertedList);
        }

        internal static ReadOnlyDictionary<DefinitionHashPointer<T>, P>
            AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<T, P>(this Dictionary<uint, P> dictionary,
                DefinitionsEnum enumValue) where T : IDestinyDefinition
        {
            if (dictionary is null)
                return new ReadOnlyDictionary<DefinitionHashPointer<T>, P>(
                    new Dictionary<DefinitionHashPointer<T>, P>(0));
            var convertedDict = dictionary.ToDictionary(x => new DefinitionHashPointer<T>(x.Key), y => y.Value);
            return new ReadOnlyDictionary<DefinitionHashPointer<T>, P>(convertedDict);
        }

        internal static ReadOnlyDictionary<T, P> AsReadOnlyDictionaryOrEmpty<T, P>(this Dictionary<T, P> dictionary)
        {
            if (dictionary is null)
                return new ReadOnlyDictionary<T, P>(new Dictionary<T, P>(0));
            return new ReadOnlyDictionary<T, P>(dictionary);
        }

        internal static string ComponentsToWordString(this DestinyComponentType[] componentTypes)
        {
            return string.Join(',', componentTypes);
        }

        internal static string ComponentsToIntString(this DestinyComponentType[] componentTypes)
        {
            return string.Join(',', componentTypes.Select(x => (int) x));
        }

        public static string LocaleToString(this BungieLocales locale)
        {
            return locale switch
            {
                BungieLocales.EN => "en",
                BungieLocales.RU => "ru",
                BungieLocales.DE => "de",
                BungieLocales.ES => "es",
                BungieLocales.ES_MX => "es-mx",
                BungieLocales.FR => "fr",
                BungieLocales.IT => "it",
                BungieLocales.JA => "ja",
                BungieLocales.KO => "ko",
                BungieLocales.PL => "pl",
                BungieLocales.PT_BR => "pt-br",
                BungieLocales.ZH_CHS => "zh-chs",
                BungieLocales.ZH_CHT => "zh-cht",
                _ => throw new Exception("Wrong locale.")
            };
        }

        public static int ToInt32(this uint hash)
        {
            return unchecked((int) hash);
        }

        public static uint ToUInt32(this int hash)
        {
            return unchecked((uint) hash);
        }

        #region Activity search

        public static List<DestinyActivityDefinition> GetActivitiesWithMode(
            this ILocalisedDestinyDefinitionRepositories repository, BungieLocales locale, uint activityModeHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale,
                x => ((DestinyActivityDefinition) x).ActivityModes.Any(q => q.Hash.Equals(activityModeHash))).ToList();
        }

        public static List<DestinyActivityDefinition> GetActivitiesWithMode(
            this ILocalisedDestinyDefinitionRepositories repository, BungieLocales locale,
            DestinyActivityModeType activityMode)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale,
                x => (x as DestinyActivityDefinition).ActivityModeTypes.Contains(activityMode)).ToList();
        }

        public static List<DestinyActivityDefinition> GetActivitiesWithDirectMode(
            this ILocalisedDestinyDefinitionRepositories repository, BungieLocales locale, uint activityModeHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale,
                x => (x as DestinyActivityDefinition).DirectActivityMode.Hash.Equals(activityModeHash)).ToList();
        }

        public static List<DestinyActivityDefinition> GetActivitiesWithDirectMode(
            this ILocalisedDestinyDefinitionRepositories repository, BungieLocales locale,
            DestinyActivityModeType activityMode)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale,
                x => (x as DestinyActivityDefinition).DirectActivityModeType.Equals(activityMode)).ToList();
        }

        public static List<DestinyActivityDefinition> GetActivitiesWithPlace(
            this ILocalisedDestinyDefinitionRepositories repository, BungieLocales locale, uint placeHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale,
                x => (x as DestinyActivityDefinition).Place.Hash.Equals(placeHash)).ToList();
        }

        public static List<DestinyActivityDefinition> GetActivitiesWithDestination(
            this ILocalisedDestinyDefinitionRepositories repository, BungieLocales locale, uint destinationHash)
        {
            return repository.Search<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition, locale,
                x => (x as DestinyActivityDefinition).Destination.Hash.Equals(destinationHash)).ToList();
        }

        public static IEnumerable<DestinyActivityDefinition> WithMode(
            this IEnumerable<DestinyActivityDefinition> definitions, DestinyActivityModeType activityMode)
        {
            return definitions.Where(x => x.ActivityModeTypes.Contains(activityMode));
        }

        public static IEnumerable<DestinyActivityDefinition> WithDirectMode(
            this IEnumerable<DestinyActivityDefinition> definitions, DestinyActivityModeType activityMode)
        {
            return definitions.Where(x => x.DirectActivityModeType.Equals(activityMode));
        }

        public static IEnumerable<DestinyActivityDefinition> WithPlace(
            this IEnumerable<DestinyActivityDefinition> definitions, uint placeHash)
        {
            return definitions.Where(x => x.Place.Hash.Equals(placeHash));
        }

        public static IEnumerable<DestinyActivityDefinition> WithDestination(
            this IEnumerable<DestinyActivityDefinition> definitions, uint destinationHash)
        {
            return definitions.Where(x => x.Destination.Hash.Equals(destinationHash));
        }

        public static IEnumerable<DestinyActivityDefinition> IsPvP(
            this IEnumerable<DestinyActivityDefinition> definitions, bool isPvP)
        {
            return definitions.Where(x => x.IsPvP.Equals(isPvP));
        }

        public static IEnumerable<DestinyActivityDefinition> IsPlaylist(
            this IEnumerable<DestinyActivityDefinition> definitions, bool isPlaylist)
        {
            return definitions.Where(x => x.IsPlaylist.Equals(isPlaylist));
        }

        public static IEnumerable<DestinyActivityDefinition> InheritsFromFreeRoam(
            this IEnumerable<DestinyActivityDefinition> definitions, bool inheritFromFreeRoam)
        {
            return definitions.Where(x => x.InheritFromFreeRoam.Equals(inheritFromFreeRoam));
        }

        public static IEnumerable<DestinyActivityDefinition> WithName(
            this IEnumerable<DestinyActivityDefinition> definitions, string name)
        {
            return definitions.Where(x => x.DisplayProperties.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<DestinyActivityDefinition> WithDescription(
            this IEnumerable<DestinyActivityDefinition> definitions, string description)
        {
            return definitions.Where(x =>
                x.DisplayProperties.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
        }

        #endregion
    }
}