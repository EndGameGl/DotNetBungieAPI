using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace BungieNetCoreAPI
{
    public static class Extensions
    {
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
    }
}
