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

        public static bool JePlatca()
        {
            var file = new XmlDocument();
            file.Load(Directory.GetCurrentDirectory() + "\\data\\" + nastaveniaFileName);

            var n = file.GetElementsByTagName("nastavenia");
            XmlNode nastavenia;
            if (n.Count > 0)
            {
                nastavenia = n[0];
                return (!nastavenia.SelectNodes("icdph")[0].InnerText.Equals(""));
            }

            return false;
        }
    }
}
