using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class Pomocka
    {
        public string Item1, Item2, Item3, Item4, Item5, Item6, Item7;

        public Pomocka(string i1, string i2, string i3, string i4, string i5, string i6, string i7)
        {
            Item1 = i1;
            Item2 = i2;
            Item3 = i3;
            Item4 = i4;
            Item5 = i5;
            Item6 = i6;
            Item7 = i7;
        }

        public bool Validate()
        {
            if (!ValidateKod())
            {
                MessageBox.Show("Kód pomôcky nesmie byť prázdny");
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
    }
}
