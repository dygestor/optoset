using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Optoset
{
    public class Settings
    {
        private const string nastaveniaFileName = "nastavenia.xml";
        public static string Nazov = "", Ico = "", Dic = "", Icdph = "", Adresa = "", Iban = "", Bic = "", Register = "", Ustav = "", KodPoskytovatela = "", RegistracnyKod = "", SadzbaDPHvyssia = "", SadzbaDPHnizsia = "";
        public const int MaxPocetPomocok = 4;

        public static bool JePlatca()
        {
            return !Icdph.Equals("");
        }

        public static bool Nacitaj()
        {
            var file = new XmlDocument();
            if (File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + nastaveniaFileName))
            {
                file.Load(Directory.GetCurrentDirectory() + "\\data\\" + nastaveniaFileName);

                var n = file.GetElementsByTagName("nastavenia");
                if (n.Count > 0)
                {
                    XmlNode nastavenia = n[0];
                    Nazov = nastavenia.SelectNodes("nazov")[0].InnerText;
                    Ico = nastavenia.SelectNodes("ico")[0].InnerText;
                    Dic = nastavenia.SelectNodes("dic")[0].InnerText;
                    Icdph = nastavenia.SelectNodes("icdph")[0].InnerText;
                    Adresa = nastavenia.SelectNodes("adresa")[0].InnerText;
                    Iban = nastavenia.SelectNodes("iban")[0].InnerText;
                    Bic = nastavenia.SelectNodes("bic")[0].InnerText;
                    Register = nastavenia.SelectNodes("register")[0].InnerText;
                    Ustav = nastavenia.SelectNodes("ustav")[0].InnerText;
                    KodPoskytovatela = nastavenia.SelectNodes("kodPoskytovatela")[0].InnerText;
                    RegistracnyKod = nastavenia.SelectNodes("registracnyKod")[0].InnerText;
                    SadzbaDPHvyssia = nastavenia.SelectNodes("sadzbaDPHvyssia")[0].InnerText;
                    SadzbaDPHnizsia = nastavenia.SelectNodes("sadzbaDPHnizsia")[0].InnerText;
                }

                return true;
            }

            return false;
        }
    }
}
