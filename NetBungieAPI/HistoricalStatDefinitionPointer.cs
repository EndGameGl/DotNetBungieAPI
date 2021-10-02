using System;
using NetBungieAPI.Clients;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using Unity;

namespace NetBungieAPI
{
    public sealed class HistoricalStatDefinitionPointer
    {
#if DEBUG
        private DestinyHistoricalStatsDefinition debug_value
        {
            get
            {
                if (_client.Value.TryGetHistoricalStatDefinition(StatId, Locale, out var def))
                    return def;
                else
                    throw new Exception("Definition is missing from repo.");
            }
        }
#endif

        private static readonly Lazy<IBungieClient> _client =
            new(() => StaticUnityContainer.GetService<IBungieClient>());

        private static readonly Lazy<IDestiny2MethodsAccess> _destiny2MethodsAccess =
            new(() => StaticUnityContainer.GetService<IDestiny2MethodsAccess>());

        private static readonly Lazy<HistoricalStatDefinitionPointer> _lazyEmptyPointer =
            new(() => new HistoricalStatDefinitionPointer(null));

        public static HistoricalStatDefinitionPointer Empty => _lazyEmptyPointer.Value;

        private bool _isMapped;
        private DestinyHistoricalStatsDefinition _value;

        public BungieLocales Locale { get; } = BungieLocales.EN;
        public string StatId { get; }

        public HistoricalStatDefinitionPointer(string statId)
        {
            _value = default;
            _isMapped = false;
            StatId = statId;
        }

        public bool TryGetDefinition(out DestinyHistoricalStatsDefinition definition)
        {
            definition = default;

            if (_isMapped)
            {
                definition = _value;
                return true;
            }

            if (_client.Value.TryGetHistoricalStatDefinition(StatId, Locale, out definition))
            {
                _value = definition;
                _isMapped = true;
                return true;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{StatId}";
        }

        public void TryMapValue()
        {
            if (_value != null && _isMapped)
                return;
            if (string.IsNullOrWhiteSpace(StatId))
                return;

            if (_client.Value.TryGetHistoricalStatDefinition(StatId, Locale, out var definition))
            {
                _value = definition;
                _isMapped = true;
            }
        }
    }
}