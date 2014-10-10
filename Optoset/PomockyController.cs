using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class PomockyController
    {
        public List<Pomocka> Pomocky;
        public const string cennikyDirectory = "\\cenniky";

        public PomockyController()
        {
        }

        public bool NacitajCennik(string cennik)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data" + cennikyDirectory + "\\" + cennik + ".csv"))
            {
                MessageBox.Show("Daný cenník nebol nájdený");
                return false;
            }

            Pomocky = new List<Pomocka>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data" + cennikyDirectory + "\\" + cennik + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                if ((line = sr.ReadLine()) != null)
                {

                }
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    Pomocky.Add(new Pomocka(row[1], row[2], row[0], row[7], row[9], row[8], row[10], row[3] + "|" + row[4] + "|" + row[5] + "|" + row[6]));
                }
            }

            Pomocky = Pomocky.OrderBy(n => n.Kod).ToList();

            return true;
        }
    }
}
