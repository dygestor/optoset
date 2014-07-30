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
                MessageBox.Show("Kód lekára musí pozostávať z veľkého písmena a 8 čísel (napr. A12345678)");
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
                MessageBox.Show("KPZS lekára musí pozostávať z veľkého písmena a 11 čísel (napr. A12345678900)");
                return false;
            }

            return true;
        }

        private bool ValidateKod()
        {
            int i;
            return Kod.Length == 9 && int.TryParse(Kod.Substring(1), out i) && Char.IsUpper(Convert.ToChar(Kod.Substring(0, 1)));
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
            double i;
            return (Kpzs.Length == 12) && (double.TryParse(Kpzs.Substring(1), out i)) && (Char.IsUpper(Convert.ToChar(Kpzs.Substring(0, 1))));
        }
    }
}
