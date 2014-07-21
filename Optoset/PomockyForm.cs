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

namespace Optoset
{
    public partial class PomockyForm : Form
    {

        private const string cennikyDirectory = "cenniky";
        private List<Tuple<string, string, string>> _pomocky;

        public PomockyForm()
        {
            InitializeComponent();
        }

        private void PomockyForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cisloCennika = comboBox1.SelectedItem;
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv"))
            {
                MessageBox.Show("Daný cenník nebol nájdený");
                return;
            }

            _pomocky = new List<Tuple<string, string, string>>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory + "\\" + cisloCennika + ".csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    _pomocky.Add(new Tuple<string, string, string>(row[0], row[1], row[2]));
                }
            }

            _pomocky.Sort();

            listView1.VirtualListSize = _pomocky.Count;
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item = { _pomocky[e.ItemIndex].Item1, _pomocky[e.ItemIndex].Item2, _pomocky[e.ItemIndex].Item3 };
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }

    }
}
