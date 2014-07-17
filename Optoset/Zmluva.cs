using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class Zmluva
    {

        public Zmluva(string cislo, string nazov, string ico, string dic, string icdph, string adresa, string iban, string bic)
        {
            Cislo = cislo;
            Nazov = nazov;
            Ico = ico;
            Dic = dic;
            Icdph = icdph;
            Adresa = adresa;
            Iban = iban;
            Bic = bic;
        }

        public string Cislo { get; set; }
        public string Nazov { get; set; }
        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public string Adresa { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }

        public bool Validate()
        {
            if (!ValidateCislo())
            {
                MessageBox.Show("Číslo poisťovne musí pozostávať z čísel a musí byť dĺžky 2");
                return false;
            }

            if (!ValidateNazov())
            {
                MessageBox.Show("Číslo zmluvy nesmie byť prázdne");
                return false;
            }

            if (!ValidateIco())
            {
                MessageBox.Show("IČO musí pozostávať z čísel a musí byť dĺžky 8");
                return false;
            }

            if (!ValidateDic())
            {
                MessageBox.Show("DIČ musí pozostávať z čísel a musí byť dĺžky 10");
                return false;
            }

            if (!ValidateIcdph())
            {
                MessageBox.Show("Nesprávny formát IČ-DPH (má byť SK00000000)");
                return false;
            }

            if (!ValidateAdresa())
            {
                MessageBox.Show("Nesprávna adresa");
                return false;
            }

            if (!ValidateIban())
            {
                MessageBox.Show("Nesprávny formát IBAN (má byť 2 znaky a maximálne 32 čísel)");
                return false;
            }

            if (!ValidateBic())
            {
                MessageBox.Show("Nesprávny formát BIČ");
                return false;
            }

            return true;
        }

        public bool ValidateCislo()
        {
            if (Cislo.Length != 2) return false;

            int i;
            return int.TryParse(Cislo, out i);
        }

        public bool ValidateNazov()
        {
            return !Nazov.Equals("");
        }

        public bool ValidateIco()
        {
            int i;
            return (!Ico.Equals("") && Ico.Length == 8 && int.TryParse(Ico, out i));
        }

        public bool ValidateDic()
        {
            int i;
            return (!Dic.Equals("") && Dic.Length == 10 && int.TryParse(Dic, out i));
        }

        public bool ValidateIcdph()
        {
            int i;
            return (!Icdph.Equals("") && Icdph.Length == 10 && Icdph.Substring(0, 2).Equals("SK") &&
                    int.TryParse(Icdph.Substring(2), out i) && Icdph.Substring(2).Equals(Ico));
        }

        public bool ValidateAdresa()
        {
            return true;
        }

        public bool ValidateIban()
        {
            int i;
            return (!Iban.Equals("") && Iban.Length <= 34 && Iban.Substring(0, 2).Any(x => !char.IsLetter(x)) && int.TryParse(Icdph.Substring(2), out i));
        }

        public bool ValidateBic()
        {
            return true;
        }
    }
}
