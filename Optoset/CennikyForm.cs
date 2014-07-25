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
        private List<Tuple<string, string, string, string, string, string>> _pomocky;

        public CennikyForm()
        {
            InitializeComponent();
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
            if (n.Count > 0)
            {
                XmlNode nastavenia = n[0];
                return (!nastavenia.SelectNodes("icdph")[0].InnerText.Equals(""));
            }

            return false;
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item;
            if (JePlatca())
            {
                item = new string[]
                {
                    _pomocky[e.ItemIndex].Item1, _pomocky[e.ItemIndex].Item2, _pomocky[e.ItemIndex].Item3,
                    _pomocky[e.ItemIndex].Item4, _pomocky[e.ItemIndex].Item6
                };
            }
            else
            {
                item = new string[]
                {
                    _pomocky[e.ItemIndex].Item1, _pomocky[e.ItemIndex].Item2, _pomocky[e.ItemIndex].Item3,
                    _pomocky[e.ItemIndex].Item5, _pomocky[e.ItemIndex].Item6
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

            _pomocky = new List<Tuple<string, string, string, string, string, string>>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    _pomocky.Add(new Tuple<string, string, string, string, string, string>(row[1], row[0], row[7], row[8], row[9], row[10]));
                }
            }

            _pomocky.Sort();

            listView1.VirtualListSize = _pomocky.Count;
        }
    }
}
