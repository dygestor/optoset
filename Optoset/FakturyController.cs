using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class FakturyController
    {

        public List<Faktura> _faktury;
        public HashSet<string> Kluce; 

        public FakturyController()
        {
            Faktury = new List<Faktura>();
            Kluce = new HashSet<string>();
        }

        public List<Faktura> Faktury
        {
            get { return _faktury; }
            set { _faktury = value; }
        }

        public bool PridajFakturu(string cislo, string poistovna, string obdobie, string cennik)
        {
            Faktura f = new Faktura(cislo, poistovna, obdobie, cennik);
            if (f.Validates())
            {
                if (!Kluce.Contains(cislo))
                {
                    Faktury.Add(f);
                    Kluce.Add(cislo);
                    return true;
                }
                MessageBox.Show("Faktúra s daným číslom už existuje.");
                return false;
            }
            MessageBox.Show("Prosím vyplňte všetky údaje.");
            return false;
        }

        public bool UpravFakturu(int index, string cislo, string poistovna, string obdobie, string cennik)
        {
            Faktura f = new Faktura(cislo, poistovna, obdobie, cennik);
            if (f.Validates())
            {
                if (!Kluce.Contains(cislo) || Faktury[index].Cislo == cislo)
                {
                    Kluce.Remove(Faktury[index].Cislo);
                    Faktury[index].Cislo = cislo;
                    Faktury[index].Poistovna = poistovna;
                    Faktury[index].Obdobie = obdobie;
                    Faktury[index].Cennik = cennik;
                    Kluce.Add(cislo);
                    return true;
                }
                MessageBox.Show("Faktúra s daným číslom už existuje.");
                return false;
            }
            MessageBox.Show("Prosím vyplňte všetky údaje.");
            return false;
        }
    }
}
