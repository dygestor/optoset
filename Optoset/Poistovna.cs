using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optoset
{
    public class Poistovna
    {

        public Poistovna(string cislo, string nazov)
        {
            Cislo = cislo;
            Nazov = nazov;
        }

        public string Cislo { get; set; }

        public string Nazov { get; set; }
    }
}
