using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Providers;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI
{
    /// <summary>
    ///     Class that points to a certain definition in database
    /// </summary>
    /// <typeparam name="T">Destiny definition type</typeparam>
    public sealed class DefinitionHashPointer<T> : IDeepEquatable<DefinitionHashPointer<T>> where T : IDestinyDefinition
    {
#if DEBUG
        private T debug_value_getter
        {
            get
            {
                if (TryGetDefinition(out var def))
                {
                    return def;
                }
                else
                {
                    throw new Exception("Failed to get definition");
                }
            }
        }
#endif

        private static readonly IConfigurationService _configuration = StaticUnityContainer.GetConfiguration();

        private static readonly ILocalisedDestinyDefinitionRepositories _repository =
            StaticUnityContainer.GetDestinyDefinitionRepositories();

        private static readonly IDestiny2MethodsAccess _destiny2MethodsAccess =
            StaticUnityContainer.GetService<IDestiny2MethodsAccess>();

        /// <summary>
        ///     Definition enum value
        /// </summary>
        public static DefinitionsEnum EnumValue { get; } = Enum.Parse<DefinitionsEnum>(typeof(T).Name);

        /// <summary>
        ///     Empty pointer
        /// </summary>
        public static DefinitionHashPointer<T> Empty { get; } = new DefinitionHashPointer<T>(null);

        private bool _isMapped;
        private T _value;

        /// <summary>
        ///     Definition hash, guaranteed to be unique across it's type.
        /// </summary>
        public uint? Hash { get; }

        /// <summary>
        ///     Definition type enum value
        /// </summary>
        public DefinitionsEnum DefinitionEnumType => EnumValue;

        /// <summary>
        ///     Definition locale
        /// </summary>
        public BungieLocales Locale { get; internal set; } = BungieLocales.EN;

        /// <summary>
        ///     Whether this hash isn't empty.
        /// </summary>
        [JsonIgnore]
        public bool HasValidHash => Hash is > 0;

        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="hash">Definition hash</param>
        internal DefinitionHashPointer(uint? hash)
        {
            _value = default;
            _isMapped = false;
            Hash = hash;
        }

        public DefinitionHashPointer(uint hash, BungieLocales locale)
        {
            _value = default;
            _isMapped = false;
            Hash = hash;
            Locale = locale;
        }

        /// <summary>
        ///     Tries to get definition from local cache/given provider
        /// </summary>
        /// <param name="definition">Found definition</param>
        /// <returns>True, if found, False otherwise</returns>
        public bool TryGetDefinition(out T definition)
        {
            return TryGetDefinitionFromOtherLocale(Locale, out definition);
        }

        /// <summary>
        /// Tries to get definition from local cache/given provider with specified locale
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool TryGetDefinitionFromOtherLocale(BungieLocales locale, out T definition)
        {
            definition = default;
            if (_isMapped)
            {
                definition = _value;
                return true;
            }

            if (HasValidHash && _repository.TryGetDestinyDefinition(Hash.Value, locale, out definition))
            {
                _value = definition;
                _isMapped = true;
                return true;
            }

            try
            {
                var loadTask = _repository.Provider.LoadDefinition<T>(Hash.Value, locale);
                definition = loadTask.ConfigureAwait(false).GetAwaiter().GetResult();

                if (definition is not null)
                {
                    _value = definition;
                    _isMapped = true;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            return false;
        }

        /// <summary>
        ///     Attempts to get definition from bungie.net
        /// </summary>
        /// <returns></returns>
        public async ValueTask<DefinitionHashPointerDownloadResult<T>> TryDownloadDefinition()
        {
            if (!HasValidHash)
                return new DefinitionHashPointerDownloadResult<T>(default, false, "Missing valid hash.");

            var response =
                await _destiny2MethodsAccess
                    .GetDestinyEntityDefinition<T>(DefinitionEnumType, Hash!.Value);

            if (response.IsSuccessfulResponseCode && response.Response is not null)
                return new DefinitionHashPointerDownloadResult<T>(response.Response, true);

            return new DefinitionHashPointerDownloadResult<T>(default, false, response.ErrorStatus);
        }

        /// <summary>
        /// <inheritdoc cref="object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{(_isMapped ? _value.ToString() : $"{DefinitionEnumType} - {Hash} - {Locale}")}";
        }

        /// <summary>
        /// Tries to map value from repository
        /// </summary>
        public void TryMapValue()
        {
            if (_value is not null && _isMapped)
                return;
            if (!HasValidHash)
                return;
            if (!_repository.TryGetDestinyDefinition<T>(Hash!.Value, Locale,
                out var definition))
                return;

            _value = definition;
            _isMapped = true;
        }

        /// <summary>
        /// <inheritdoc cref="IDeepEquatable{T}.DeepEquals"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool DeepEquals(DefinitionHashPointer<T> other)
        {
            return other != null &&
                   Hash == other.Hash &&
                   DefinitionEnumType == other.DefinitionEnumType &&
                   Locale == other.Locale;
        }

        internal void SetLocale(BungieLocales locale)
        {
            Locale = locale;
        }
    }
}