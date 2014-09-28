using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public partial class PomockaForm : Form
    {

        private const string cennikyDirectory = "cenniky";
        private List<Pomocka> _pomocky;
        private Faktura _faktura;
        private int _poukazIndex, _pomockaIndex;

        public PomockaForm()
        {
            InitializeComponent();
        }

        public void Initiate(Faktura f, int poukazIndex, int pomockaIndex = -1)
        {
            NacitajCennik(f.Cennik);
            _faktura = f;
            _poukazIndex = poukazIndex;
            _pomockaIndex = pomockaIndex;

            if (_pomockaIndex > -1)
            {
                var index = _pomocky.FindIndex(x => x.Kod == _faktura.Poukazy[_poukazIndex].Pomocky[_pomockaIndex].Pomocka.Kod);
                comboBox1.SelectedIndex = index;
                textBox1.Text = _faktura.Poukazy[_poukazIndex].Pomocky[_pomockaIndex].Mnozstvo.ToString();
                textBox2.Text = _faktura.Poukazy[_poukazIndex].Pomocky[_pomockaIndex].HradiPoistovna.ToString();
                textBox3.Text = _faktura.Poukazy[_poukazIndex].Pomocky[_pomockaIndex].HradiPacient.ToString();
                button1.Text = "Upraviť pomôcku";
            }
        }

        public void NacitajCennik(string cennik)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cennik + ".csv"))
            {
                MessageBox.Show("Daný cenník nebol nájdený");
                return;
            }

            _pomocky = new List<Pomocka>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cennik + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    _pomocky.Add(new Pomocka(row[1], row[2], row[0], row[7], row[9], row[8], row[10], row[3] + "|" + row[4] + "|" + row[5] + "|" + row[6]));
                }
            }

            _pomocky = _pomocky.OrderBy(n => n.Kod).ToList();

            comboBox1.Items.Clear();
            comboBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (var p in _pomocky)
            {
                comboBox1.Items.Add(p.Kod + " " + p.Nazov + " (" + p.Popis + ")");
                comboBox1.AutoCompleteCustomSource.Add(p.Kod + " " + p.Nazov + " (" + p.Popis + ")");
            }
        }

        private void VypocitajCeny()
        {
            var index = comboBox1.SelectedIndex;

            int mnozstvo;
            if (!int.TryParse(textBox1.Text, out mnozstvo))
            {
                MessageBox.Show("Množstvo musí byť celé číslo");
                return;
            }


            double cenaMF = double.Parse(Settings.JePlatca() ? _pomocky[index].CenaMFplatca : _pomocky[index].CenaMFneplatca, CultureInfo.InvariantCulture);
            double cenaPoistovna = double.Parse(_pomocky[index].CenaPoistovna, CultureInfo.InvariantCulture);

            textBox2.Text = (mnozstvo * cenaPoistovna).ToString();
            textBox3.Text = ((cenaMF - cenaPoistovna > 0) ? (mnozstvo * (cenaMF - cenaPoistovna)).ToString() : "0");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VypocitajCeny();    
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            VypocitajCeny();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mnozstvo;
            if (!int.TryParse(textBox1.Text, out mnozstvo))
            {
                MessageBox.Show("Množstvo musí byť celé číslo");
                return;
            }

            double hradiPoistovna;
            if (!double.TryParse(textBox2.Text, out hradiPoistovna))
            {
                MessageBox.Show("Suma, ktorú hradí poisťovňa musí byť číslo.");
                return;
            }

            double hradiPacient;
            if (!double.TryParse(textBox3.Text, out hradiPacient))
            {
                MessageBox.Show("Suma, ktorú hradí pacient musí byť číslo.");
                return;
            }

            PoukazPomocka p = new PoukazPomocka(_pomocky[comboBox1.SelectedIndex], mnozstvo, hradiPoistovna, hradiPacient);
            string[] item =
                {
                    p.Pomocka.Kod + " " + p.Pomocka.Nazov + " (" + p.Pomocka.Popis + ")", p.Mnozstvo.ToString(), p.HradiPoistovna.ToString(), p.HradiPacient.ToString()
                };
            ListViewItem lvi = new ListViewItem(item);

            if (_pomockaIndex > -1)
            {
                _faktura.Poukazy[_poukazIndex].Pomocky[_pomockaIndex] = p;
                _faktura.TabControl.LV2.Items[_pomockaIndex] = lvi;
                _faktura.TabControl.LV2.Items[_pomockaIndex].Selected = true;
            }
            else
            {
                _faktura.Poukazy[_poukazIndex].Pomocky.Add(p);
                _faktura.TabControl.LV2.Items.Add(lvi);
                _faktura.TabControl.LV2.Items[_faktura.TabControl.LV2.Items.Count - 1].Selected = true;
            }
            Close();
        }
    }
}
