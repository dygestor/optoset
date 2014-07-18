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

        private const string fileName = "diagnozy.csv";

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
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + fileName))
            {
                MessageBox.Show("Súbor s diagnózami nebol nájdený");
                return;
            }

            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "\\data\\" + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    string[] item = { row[0], row[2] };
                    var listViewItem = new ListViewItem(item);
                    listView1.Items.Add(listViewItem);
                }
            }
        }
    }
}
