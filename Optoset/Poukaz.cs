using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public class Poukaz
    {
        public Pobocka Pobocka;
        public string RodneCislo;
        public Lekar Lekar;
        public string Diagnoza;
        public string DatumPredpisania;
        public string DatumVydaja;
        public double HradiPoistovna = 0;
        public double HradiPacient = 0;
        public bool Error = false;

        public List<PoukazPomocka> Pomocky = new List<PoukazPomocka>();

        public Poukaz()
        {

        }

        public Poukaz(Pobocka pobocka, string rodneCislo, Lekar lekar, string diagnoza, string datumPredpisania, string datumVydaja)
        {
            Pobocka = pobocka;
            RodneCislo = rodneCislo;
            Lekar = lekar;
            Diagnoza = diagnoza;
            DatumPredpisania = datumPredpisania;
            DatumVydaja = datumVydaja;
        }

        public bool Validate()
        {

            if (!ValidatePobocka())
            {
                MessageBox.Show("Musíte zvoliť IČ poisťovne.");
                return false;
            }

            if (!ValidateRodneCislo())
            {
                MessageBox.Show("Rodné číslo je v nesprávnom formáte.");
                return false;
            }

            if (!ValidateLekar())
            {
                MessageBox.Show("Musíte zvoliť lekára.");
                return false;
            }

            if (!ValidateDiagnoza())
            {
                MessageBox.Show("Musíte zvoliť diagnózu.");
                return false;
            }

            if (!ValidateDatumPredpisania())
            {
                MessageBox.Show("Musíte zvoliť dátum predpísania.");
                return false;
            }

            if (!ValidateDatumVydania())
            {
                MessageBox.Show("Musíte zvoliť dátum vydania.");
                return false;
            }

            return true;
        }

        private bool ValidateDatumVydania()
        {
            return !DatumVydaja.Equals("");
        }

        private bool ValidateDatumPredpisania()
        {
            return !DatumPredpisania.Equals("");
        }


        private bool ValidateDiagnoza()
        {
            return !Diagnoza.Equals("");
        }

        private bool ValidateLekar()
        {
            return Lekar != null;
        }

        private bool ValidateRodneCislo()
        {
            int i, j;
            return RodneCislo.Length == 11 && int.TryParse(RodneCislo.Substring(0, 6), out i) &&
                   int.TryParse(RodneCislo.Substring(7, 4), out j) && RodneCislo.Substring(6, 1).Equals("/");
        }

        private bool ValidatePobocka()
        {
            return Pobocka != null;
        }
    }
}
