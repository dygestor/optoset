using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Optoset
{
    public class Pomocka
    {
        public string Nazov, Popis, Kod, CenaMFplatca, CenaMFneplatca, CenaPoistovna, Dph, NepotrebneVeci;

        public Pomocka(string i1, string i2, string i3, string i4, string i5, string i6, string i7, string i8 = "|||")
        {
            Nazov = i1; //nazov
            Popis = i2; //popis
            Kod = i3; //kod
            CenaMFplatca = i4.Equals("") ? "0" : i4; //cena MF pre platcu
            CenaMFneplatca = i5.Equals("") ? "0" : i5; //cena MF pre neplatcu
            CenaPoistovna = i6; //hradi poistovna
            Dph = i7; //DPH
            NepotrebneVeci = i8;
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
            return double.TryParse(Dph, out d);
        }

        private bool ValidateCenaPoistovne()
        {
            double d;
            return double.TryParse(CenaPoistovna, NumberStyles.Number, CultureInfo.InvariantCulture, out d);
        }

        private bool ValidateCenaMF()
        {
            double d;
            var item = Settings.JePlatca() ? CenaMFplatca : CenaMFneplatca;
            return double.TryParse(item, NumberStyles.Number, CultureInfo.InvariantCulture, out d);
        }

        private bool ValidateNazov()
        {
            return !Nazov.Equals("");
        }

        private bool ValidateKod()
        {
            int i;
            return Kod.Length == 5 && int.TryParse(Kod, out i);
        }
    }
}
