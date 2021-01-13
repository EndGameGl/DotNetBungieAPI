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
        public static void SaveToDisk(this Bitmap bitmap, string folderPath, string filename, ImageFormat format)
        {
            var targetDirectory = $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\";
            var targetFileName = $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\{filename}.{format.ToString().ToLower()}";
            if (Directory.Exists(targetDirectory))
            {
                if (!File.Exists(targetFileName))
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(targetFileName, FileMode.Create, FileAccess.ReadWrite))
                        {
                            bitmap.Save(memory, ImageFormat.Png);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
            }
        }
    }
}
