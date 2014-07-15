using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optoset
{
    public class PoistovneController
    {

        private List<Poistovna> poistovne;

        public PoistovneController()
        {
            Poistovne = new List<Poistovna>();

            PridajPoistovnu("0001", "Poistovna 1");
            PridajPoistovnu("0002", "Poistovna 2");
            PridajPoistovnu("0003", "Poistovna 3");
        }

        public List<Poistovna> Poistovne
        {
            get { return poistovne; }
            set { poistovne = value; }
        }

        public void PridajPoistovnu(string cislo, string nazov)
        {
            Poistovne.Add(new Poistovna(cislo, nazov));
        }
    }
}
