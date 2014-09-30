using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optoset
{
    public class PoukazPomocka
    {
        public Pomocka Pomocka;
        public int Mnozstvo;
        public double HradiPoistovna, HradiPacient;

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
    }
}
