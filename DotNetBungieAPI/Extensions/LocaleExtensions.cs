using DotNetBungieAPI.Models;

namespace DotNetBungieAPI.Extensions;

public static class LocaleExtensions
{
    /// <summary>
    ///     Converts <see cref="BungieLocales" /> to string equivalent
    /// </summary>
    /// <param name="locale"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static string AsString(this BungieLocales locale)
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

    public static BungieLocales ParseLocale(this string localeString)
    {
        return localeString switch
        {
            "en" => BungieLocales.EN,
            "ru" => BungieLocales.RU,
            "de" => BungieLocales.DE,
            "es" => BungieLocales.ES,
            "es-mx" => BungieLocales.ES_MX,
            "fr" => BungieLocales.FR,
            "it" => BungieLocales.IT,
            "ja" => BungieLocales.JA,
            "ko" => BungieLocales.KO,
            "pl" => BungieLocales.PL,
            "pt-br" => BungieLocales.PT_BR,
            "zh-chs" => BungieLocales.ZH_CHS,
            "zh-cht" => BungieLocales.ZH_CHT,
            _ => throw new Exception("Wrong locale.")
        };
    }
}