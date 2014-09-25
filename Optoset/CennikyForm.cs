using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Optoset
{
    public partial class CennikyForm : Form
    {

        private const string cennikyDirectory = "cenniky";
        private List<Pomocka> _pomocky;
        private HashSet<string> _kluce;
        private string ZvolenyCennik = "";
        private bool Zmena = false;

        public CennikyForm()
        {
            InitializeComponent();
            Kluce = new HashSet<string>();
        }

        public HashSet<string> Kluce
        {
            get { return _kluce; }
            set { _kluce = value; }
        }

        private void CennikyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Zmena)
            {
                DialogResult dr = MessageBox.Show("Chcete uložiť zmeny v aktuálnom cenníku?", "Uloženie zmien", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Uloz();
                }
            }
            Hide();
            e.Cancel = true;
        }

        public void Initiate()
        {
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory))
            {
                foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory))
                {
                    var name = Path.GetFileNameWithoutExtension(file);
                    comboBox1.Items.Add(name);
                }
            }
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item;
            if (Settings.JePlatca())
            {
                item = new[]
                {
                    _pomocky[e.ItemIndex].Nazov, _pomocky[e.ItemIndex].Popis, _pomocky[e.ItemIndex].Kod,
                    _pomocky[e.ItemIndex].CenaMFplatca, _pomocky[e.ItemIndex].CenaPoistovna, _pomocky[e.ItemIndex].Dph
                };
            }
            else
            {
                item = new[]
                {
                    _pomocky[e.ItemIndex].Nazov, _pomocky[e.ItemIndex].Popis, _pomocky[e.ItemIndex].Kod,
                    _pomocky[e.ItemIndex].CenaMFneplatca, _pomocky[e.ItemIndex].CenaPoistovna, _pomocky[e.ItemIndex].Dph
                };
            }
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }

        private void Uloz()
        {
            var csv = new StringBuilder();

            foreach (var p in _pomocky)
            {
                csv.Append(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}{8}", p.Kod, p.Nazov, p.Popis, p.NepotrebneVeci, p.CenaMFplatca, p.CenaPoistovna, p.CenaMFneplatca, p.Dph, Environment.NewLine));
            }

            File.WriteAllText(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + ZvolenyCennik + ".csv", csv.ToString());

            Zmena = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cisloCennika = comboBox1.SelectedItem;
            if (!ZvolenyCennik.Equals("") && Zmena)
            {
                DialogResult dr = MessageBox.Show("Chcete uložiť zmeny v aktuálnom cenníku?", "Uloženie zmien", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Uloz();
                }
            }
            ZvolenyCennik = cisloCennika.ToString();

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv"))
            {
                MessageBox.Show("Daný cenník nebol nájdený");
                return;
            }

            _pomocky = new List<Pomocka>();
            Kluce = new HashSet<string>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    _pomocky.Add(new Pomocka(row[1], row[2], row[0], row[7], row[9], row[8], row[10], row[3] + "|" + row[4] + "|" + row[5] + "|" + row[6]));
                    Kluce.Add(_pomocky.Last().Kod);
                }
            }

            _pomocky = _pomocky.OrderBy(n => n.Kod).ToList();

            listView1.VirtualListSize = _pomocky.Count;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                textBox1.Text = listView1.Items[indices[0]].SubItems[0].Text;
                textBox2.Text = listView1.Items[indices[0]].SubItems[1].Text;
                textBox3.Text = listView1.Items[indices[0]].SubItems[2].Text;
                textBox4.Text = listView1.Items[indices[0]].SubItems[3].Text;
                textBox5.Text = listView1.Items[indices[0]].SubItems[4].Text;
                textBox6.Text = listView1.Items[indices[0]].SubItems[5].Text;
            }
        }

        private void pridatButton_Click(object sender, EventArgs e)
        {
            Pomocka p;
            if (Settings.JePlatca())
            {
                p = new Pomocka(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, "", textBox5.Text, 
                    textBox6.Text);
            }
            else
            {
                p = new Pomocka(textBox1.Text, textBox2.Text, textBox3.Text, "", textBox4.Text, textBox5.Text, textBox6.Text);
            }

            if (PridatPomocku(p))
            {
                Zmena = true;
                listView1.VirtualListSize = _pomocky.Count;
                listView1.Invalidate();
            }
        }

        private bool PridatPomocku(Pomocka pomocka)
        {
            if (pomocka.Validate())
            {
                if (Kluce.Contains(pomocka.Kod))
                {
                    MessageBox.Show("Pomôcka s daným kódom už existuje");
                    return false;
                }
                _pomocky.Add(pomocka);
                Kluce.Add(pomocka.Kod);
                _pomocky = _pomocky.OrderBy(x => x.Kod).ToList();
                return true;
            }
            return false;
        }

        private bool UpravitPomocku(int index)
        {
            Pomocka p = _pomocky[index];
            Pomocka u;
            if (Settings.JePlatca())
            {
                u = new Pomocka(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, "", textBox5.Text,
                    textBox6.Text, p.NepotrebneVeci);
            }
            else
            {
                u = new Pomocka(textBox1.Text, textBox2.Text, textBox3.Text, "", textBox4.Text, textBox5.Text, textBox6.Text, p.NepotrebneVeci);
            }

            if (u.Validate())
            {
                if (Kluce.Contains(u.Kod) && !p.Kod.Equals(u.Kod))
                {
                    MessageBox.Show("Zmluva s daným číslom už existuje");
                    return false;
                }
                Kluce.Remove(p.Kod);
                Kluce.Add(u.Kod);
                _pomocky[index] = u;
                _pomocky = _pomocky.OrderBy(x => x.Kod).ToList();
                return true;
            }
            return false;
        }

        private void upravitButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {

                if (UpravitPomocku(indices[0]))
                {
                    Zmena = true;
                    listView1.VirtualListSize = _pomocky.Count;
                    listView1.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť pomôcku na upravenie");
            }
        }

        private bool ZmazatPomocku(int index)
        {
            DialogResult dr = MessageBox.Show("Naozaj chcete zmazať danú pomôcku?", "Zmazanie pomôcky", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Pomocka p = _pomocky[index];
                Kluce.Remove(p.Kod);
                _pomocky.Remove(p);

                return true;
            }
            return false;
        }

        private void zmazatButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (ZmazatPomocku(indices[0]))
                {
                    Zmena = true;
                    listView1.VirtualListSize = _pomocky.Count;
                    listView1.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť pomôcku na zmazanie");
            }
        }

        private void zavrietButton_Click(object sender, EventArgs e)
        {
            if (Zmena)
            {
                Uloz();
            }
            Close();
        }
    }
}
