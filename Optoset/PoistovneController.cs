using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class PoistovneController
    {

        private List<Zmluva> _poistovne;
        private HashSet<string> _kluce;  

        public PoistovneController()
        {
            Poistovne = new List<Zmluva>();
            Kluce = new HashSet<string>();

            /*PridajPoistovnu("0001", "Zmluva 1");
            PridajPoistovnu("0002", "Zmluva 2");
            PridajPoistovnu("0003", "Zmluva 3");*/
        }

        public List<Zmluva> Poistovne
        {
            get { return _poistovne; }
            set { _poistovne = value; }
        }

        public HashSet<string> Kluce
        {
            get { return _kluce; }
            set { _kluce = value; }
        }

        public bool PridajPoistovnu(string cislo, string nazov)
        {
            if (Kluce.Contains(cislo))
            {
                MessageBox.Show("Poisťovňa s daným číslom už existuje");
                return false;
            }
            Poistovne.Add(new Zmluva(cislo, nazov));
            Kluce.Add(cislo);

            return true;
        }

        public bool UpravCislo(int index, string cislo)
        {
            if (Kluce.Contains(cislo))
            {
                MessageBox.Show("Poisťovňa s daným číslom už existuje");
                return false;
            }
            Kluce.Remove(Poistovne[index].Cislo);
            Poistovne[index].Cislo = cislo;
            Kluce.Add(cislo);

            return true;
        }

        public bool UpravNazov(int index, string nazov)
        {
            Poistovne[index].Nazov = nazov;

            return true;
        }
    }
}
