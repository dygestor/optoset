using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public partial class DiagnozyForm : Form
    {

        private List<Tuple<string, string>> _diagnozy;

        private const string diagnozyFileName = "diagnozy.csv";

        public DiagnozyForm()
        {
            InitializeComponent();
        }

        private void DiagnozyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        public void Initiate()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + diagnozyFileName))
            {
                MessageBox.Show("Súbor s diagnózami nebol nájdený");
                return;
            }

            _diagnozy = new List<Tuple<string, string>>();
            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + diagnozyFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    _diagnozy.Add(new Tuple<string, string>(row[0], row[2]));
                }
            }

            listView1.VirtualListSize = _diagnozy.Count;
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item = { _diagnozy[e.ItemIndex].Item1, _diagnozy[e.ItemIndex].Item2 };
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }
    }
}
