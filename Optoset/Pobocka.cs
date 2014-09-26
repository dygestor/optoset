using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class Pobocka
    {

        public Pobocka(string cislo, string nazov)
        {
            Cislo = cislo;
            Nazov = nazov;
        }

        public string Cislo { get; set; }

        public string Nazov { get; set; }

        public bool Validate()
        {
            if (!ValidateCislo())
            {
                MessageBox.Show("Číslo pobočky musí pozostávať z čísel a musí byť dĺžky 4");
                return false;
            }

            if (!ValidateNazov())
            {
                MessageBox.Show("Názov pobočky nesmie byť prázdny");
                return false;
            }

            return true;
        }

        public bool ValidateCislo()
        {
            if (Cislo.Length != 4) return false;

            int i;
            return int.TryParse(Cislo, out i);
        }

        public bool ValidateNazov()
        {
            return !Nazov.Equals("");
        }

        public string ToString()
        {
            return Cislo + " " + Nazov;
        }
    }
}
