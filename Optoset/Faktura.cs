using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Optoset
{
    public class Faktura
    {
        public string Cislo;
        public string Poistovna;
        public string Obdobie;
        public string Cennik;
        public List<Poukaz> Poukazy = new List<Poukaz>();
        public TabControl TabControl;

        private const string cennikyDirectory = "\\cenniky";

        public Faktura()
        {
        }

        public Faktura(string cislo, string poistovna, string obdobie, string cennik)
        {
            Cislo = cislo;
            Poistovna = poistovna;
            Obdobie = obdobie;
            Cennik = cennik;
        }

        public bool Validates()
        {
            return !Cislo.Equals("") && !Poistovna.Equals("") && !Obdobie.Equals("") && !Cennik.Equals("");
        }

        public void PrepocitajCeny(int poukazIndex, bool invalidate = true)
        {
            double hradiPoistovna = 0, hradiPacient = 0;

            foreach (var pomocka in Poukazy[poukazIndex].Pomocky)
            {
                hradiPoistovna += pomocka.HradiPoistovna;
                hradiPacient += pomocka.HradiPacient;
            }

            Poukazy[poukazIndex].HradiPoistovna = hradiPoistovna;
            Poukazy[poukazIndex].HradiPacient = hradiPacient;
            if (invalidate) TabControl.LV1.Invalidate();
        }

        public void PrepocitajFakturu()
        {
            var pomocky = new List<Pomocka>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data" + cennikyDirectory + "\\" + Cennik + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
                    pomocky.Add(new Pomocka(row[1], row[2], row[0], row[7], row[9], row[8], row[10], row[3] + "|" + row[4] + "|" + row[5] + "|" + row[6]));
                }
            }

            pomocky = pomocky.OrderBy(n => n.Kod).ToList();

            foreach (var poukaz in Poukazy) 
            {
                poukaz.Error = false;
                for (int i = 0; i < poukaz.Pomocky.Count; i++) 
                {
                    var p = poukaz.Pomocky[i];

                    var pomocka = pomocky.Find(x => x.Kod.Equals(p.Pomocka.Kod));

                    if (pomocka != null)
                    {
                        p.Error = false;
                        p.ErrorString = "";
                        p.Pomocka = pomocka;
                        p.PrepocitajCeny();
                    }
                    else 
                    {
                        p.Error = true;
                        p.ErrorString = string.Format("Pomôcka neexistuje v cenníku {0}.", Cennik);
                        poukaz.Error = true;
                    }
                }   
            }

            var selected = TabControl.LV1.SelectedIndices[0];
            TabControl.LV1.Invalidate();

            if (selected > -1)
            {
                TabControl.LV1.Items[selected].Selected = false;
                TabControl.LV1.Items[selected].Selected = true;
            }
        }
    }
}
