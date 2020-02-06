using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace JournalProject.Models
{
    public class Languages
    {
        public static List<Language> LanguagesList = new List<Language>
        {
            new Language{ Name = "Azerbaijani", Code = "az", Link = "/" },
            new Language{ Name = "English", Code = "en", Link = "/en/" }
        };

        public static bool IsLangAvailable(string lang)
        {
            return LanguagesList.Where(l => l.Code.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLang()
        {
            return LanguagesList[0].Code;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (IsLangAvailable(lang))
                {
                    var cultureInfo = new CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                }
            }
            catch (Exception)
            {

            }
        }
    }

    public class Language
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }
    }
}