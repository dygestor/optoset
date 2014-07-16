using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class Zmluva : Pobocka
    {

        public Zmluva(string cislo, string nazov, string ico, string dic, string icdph, string adresa, string iban, string bic) : base(cislo, nazov)
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

        public string Ico { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public string Adresa { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }

        public override bool Validate()
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

            return true;
        }

        public override bool ValidateCislo()
        {
            if (Cislo.Length != 2) return false;

            int i;
            return int.TryParse(Cislo, out i);
        }

        public override bool ValidateNazov()
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
    }
}
