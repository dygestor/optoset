using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class Lekar
    {

        public Lekar(string kod, string titul, string meno, string priezvisko, string kpzs)
        {
            Kod = kod;
            Titul = titul;
            Meno = meno;
            Priezvisko = priezvisko;
            Kpzs = kpzs;
        }

        public string Kod { get; set; }
        public string Titul { get; set; }
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string Kpzs { get; set; }

        public bool Validate()
        {
            if (!ValidateKod())
            {
                MessageBox.Show("Kód lekára nesmie byť prázdny");
                return false;
            }

            if (!ValidateTitul())
            {
                MessageBox.Show("Titul lekára nesmie byť prázdny");
                return false;
            }

            if (!ValidateMeno())
            {
                MessageBox.Show("Meno lekára nesmie byť prázdne");
                return false;
            }

            if (!ValidatePriezvisko())
            {
                MessageBox.Show("Priezvisko lekára nesmie byť prázdne");
                return false;
            }

            if (!ValidateKpzs())
            {
                MessageBox.Show("KPZS lekára nesmie byť prázdne");
                return false;
            }

            return true;
        }

        private bool ValidateKod()
        {
            return !Kod.Equals("");
        }

        private bool ValidateTitul()
        {
            return !Titul.Equals("");
        }

        private bool ValidateMeno()
        {
            return !Meno.Equals("");
        }

        private bool ValidatePriezvisko()
        {
            return !Priezvisko.Equals("");
        }

        private bool ValidateKpzs()
        {
            return !Kpzs.Equals("");
        }
    }
}
