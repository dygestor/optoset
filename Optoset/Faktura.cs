using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optoset
{
    public class Faktura
    {
        public string Cislo;
        public string Poistovna;
        public string Obdobie;
        public string Cennik;
        public List<Poukaz> Poukazy;
        public TabControl TabControl;

        public Faktura(string cislo, string poistovna, string obdobie, string cennik)
        {
            Cislo = cislo;
            Poistovna = poistovna;
            Obdobie = obdobie;
            Cennik = cennik;

            Poukazy = new List<Poukaz>();
        }

        public bool Validates()
        {
            return !Cislo.Equals("") && !Poistovna.Equals("") && !Obdobie.Equals("") && !Cennik.Equals("");
        }

        public void PrepocitajCeny(int poukazIndex)
        {
            double hradiPoistovna = 0, hradiPacient = 0;

            foreach (var pomocka in Poukazy[poukazIndex].Pomocky)
            {
                hradiPoistovna += pomocka.HradiPoistovna;
                hradiPacient += pomocka.HradiPacient;
            }

            Poukazy[poukazIndex].HradiPoistovna = hradiPoistovna;
            Poukazy[poukazIndex].HradiPacient = hradiPacient;
            TabControl.LV1.Invalidate();
        }
    }
}
