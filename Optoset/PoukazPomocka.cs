using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Optoset
{
    public class PoukazPomocka
    {
        public Pomocka Pomocka;
        public int Mnozstvo;
        public double HradiPoistovna, HradiPacient;
        public bool Error = false;
        public string ErrorString = "";

        public PoukazPomocka()
        {
        }

        public PoukazPomocka(Pomocka pomocka, int mnozstvo, double hradiPoistovna, double hradiPacient)
        {
            Pomocka = pomocka;
            Mnozstvo = mnozstvo;
            HradiPacient = hradiPacient;
            HradiPoistovna = hradiPoistovna;
        }

        public void PrepocitajCeny() 
        {
            double cenaPoistovna = double.Parse(Pomocka.CenaPoistovna, CultureInfo.InvariantCulture);
            double cenaMF = double.Parse(Settings.JePlatca() ? Pomocka.CenaMFplatca : Pomocka.CenaMFneplatca, CultureInfo.InvariantCulture);

            HradiPoistovna = Mnozstvo * cenaPoistovna;
            HradiPacient = ((cenaMF - cenaPoistovna > 0) ? (Mnozstvo * (cenaMF - cenaPoistovna)) : 0);
        }
    }
}
