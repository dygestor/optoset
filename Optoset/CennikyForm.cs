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
        private const string nastaveniaFileName = "nastavenia.xml";
        private List<Pomocka> _pomocky;
        private HashSet<string> _kluce;

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

        private bool JePlatca()
        {
            var file = new XmlDocument();
            file.Load(Directory.GetCurrentDirectory() + "\\data\\" + nastaveniaFileName);

            var n = file.GetElementsByTagName("nastavenia");
            XmlNode nastavenia;
            if (n.Count > 0)
            {
                nastavenia = n[0];
                return (!nastavenia.SelectNodes("icdph")[0].InnerText.Equals(""));
            }

            return false;
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item;
            if (JePlatca())
            {
                item = new[]
                {
                    _pomocky[e.ItemIndex].Item1, _pomocky[e.ItemIndex].Item2, _pomocky[e.ItemIndex].Item3,
                    _pomocky[e.ItemIndex].Item4, _pomocky[e.ItemIndex].Item6, _pomocky[e.ItemIndex].Item7
                };
            }
            else
            {
                item = new[]
                {
                    _pomocky[e.ItemIndex].Item1, _pomocky[e.ItemIndex].Item2, _pomocky[e.ItemIndex].Item3,
                    _pomocky[e.ItemIndex].Item5, _pomocky[e.ItemIndex].Item6, _pomocky[e.ItemIndex].Item7
                };
            }
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cisloCennika = comboBox1.SelectedItem;
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv"))
            {
                MessageBox.Show("Daný cenník nebol nájdený");
                return;
            }

            _pomocky = new List<Pomocka>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    _pomocky.Add(new Pomocka(row[1], row[2], row[0], row[7], row[8], row[9], row[10]));
                }
            }

            _pomocky = _pomocky.OrderBy(n => n.Item2).ToList();

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
            if (JePlatca())
            {
                p = new Pomocka(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, "", 
                    textBox6.Text);
            }
            else
            {
                p = new Pomocka(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, "", textBox5.Text, textBox6.Text);
            }

            if (PridatPomocku(p))
            {
                listView1.VirtualListSize = _pomocky.Count;
                listView1.Invalidate();
            }
        }

        private bool PridatPomocku(Pomocka pomocka)
        {
            if (pomocka.Validate())
            {
                if (Kluce.Contains(pomocka.Item3))
                {
                    MessageBox.Show("Pomôcka s daným kódom už existuje");
                    return false;
                }
                _pomocky.Add(pomocka);
                Kluce.Add(pomocka.Item3);
                _pomocky = _pomocky.OrderBy(x => x.Item3).ToList();
                return true;
            }
            return false;
        }
    }
}
