using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

            if (!ValidateNazov())
            {
                MessageBox.Show("Názov pomôcky nesmie byť prázdny");
                return false;
            }

            if (!ValidateCenaMF())
            {
                MessageBox.Show("Cena MF musí pozostávať z čísel");
                return false;
            }

            if (!ValidateCenaPoistovne())
            {
                MessageBox.Show("Cena poisťovne musí pozostávať z čísel");
                return false;
            }

            if (!ValidateDPH())
            {
                MessageBox.Show("DPH musí pozostávať z čísel");
                return false;
            }

            return true;
        }

        private bool ValidateDPH()
        {
            double d;
            return double.TryParse(Item7, out d);
        }

        private bool ValidateCenaPoistovne()
        {
            if (!Item5.Equals(""))
            {
                double d;
                return double.TryParse(Item5, out d);
            }

            if (!Item6.Equals(""))
            {
                double d;
                return double.TryParse(Item6, out d);
            }

            return false;
        }

        private bool ValidateCenaMF()
        {
            double d;
            return double.TryParse(Item4, out d);
        }

        private bool ValidateNazov()
        {
            return !Item1.Equals("");
        }

        private bool ValidateKod()
        {
            int i;
            return Item3.Length == 5 && int.TryParse(Item3, out i);
        }
    }
}
