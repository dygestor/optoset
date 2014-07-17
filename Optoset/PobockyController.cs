using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class PobockyController
    {

        private List<Pobocka> _pobocky;
        private HashSet<string> _kluce;  

        public PobockyController()
        {
            Pobocky = new List<Pobocka>();
            Kluce = new HashSet<string>();

            PridajPobocku("0001", "Zmluva 1");
            /*PridajPoistovnu("0002", "Zmluva 2");
            PridajPoistovnu("0003", "Zmluva 3");*/
        }

        public List<Pobocka> Pobocky
        {
            get { return _pobocky; }
            set { _pobocky = value; }
        }

        public HashSet<string> Kluce
        {
            get { return _kluce; }
            set { _kluce = value; }
        }

        public bool PridajPobocku(string cislo, string nazov)
        {
            Pobocka p = new Pobocka(cislo, nazov);
            if (p.Validate())
            {
                if (Kluce.Contains(cislo))
                {
                    MessageBox.Show("Pobočka s daným číslom už existuje");
                    return false;
                }
                Pobocky.Add(new Pobocka(cislo, nazov));
                Kluce.Add(cislo);
                return true;
            }
            return false;
        }

        public bool UpravitPobocku(int index, string cislo, string nazov)
        {
            Pobocka p = Pobocky[index];
            string oldCislo = p.Cislo;
            string oldNazov = p.Nazov;
            p.Cislo = cislo;
            p.Nazov = nazov;
            if (p.Validate())
            {
                if (Kluce.Contains(cislo) && !oldCislo.Equals(cislo))
                {
                    MessageBox.Show("Pobočka s daným číslom už existuje");
                    p.Cislo = oldCislo;
                    p.Nazov = oldNazov;
                    return false;
                }
                Kluce.Remove(oldCislo);
                Kluce.Add(cislo);
                return true;
            }
            p.Cislo = oldCislo;
            p.Nazov = oldNazov;
            return false;
        }

        public bool ZmazatPobocku(int index)
        {
            DialogResult dr = MessageBox.Show("Naozaj chcete zmazať danú pobočku?", "Zmazanie pobočky", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Pobocka p = Pobocky[index];
                Pobocky.RemoveAt(index);

                Kluce.Remove(p.Cislo);
                return true;
            }
            return false;
        }
    }
}
