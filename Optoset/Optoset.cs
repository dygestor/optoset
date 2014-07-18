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
using System.Diagnostics;

namespace Optoset
{
    public partial class Optoset : Form
    {

        //forms
        private PobockyForm pobockyForm;
        private ZmluvyForm zmluvyForm;
        private DiagnozyForm diagnozyForm;

        //controllers
        private PobockyController _pc;
        private ZmluvyController _zc;

        //diagnozy
        private List<Tuple<string, string>> _diagnozy;

        //filenames
        private const string diagnozyFileName = "diagnozy.csv";

        public Optoset()
        {
            InitializeComponent();

            _pc = new PobockyController();
            _zc = new ZmluvyController();

            LoadDiagnozyAsync();
        }

        private void zobrazToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pobockyPoistovniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pobockyForm = new PobockyForm();
            pobockyForm.Initiate(_pc);
            pobockyForm.Show();
        }

        private void zmluvyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmluvyForm = new ZmluvyForm();
            zmluvyForm.Initiate(_zc);
            zmluvyForm.Show();
        }

        private void diagnozyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diagnozyForm = new DiagnozyForm();
            diagnozyForm.Initiate(_diagnozy);
            diagnozyForm.Show();
        }

        private async Task LoadDiagnozyAsync()
        {
            Task<bool> t = LoadDiagnozy();
            bool result = await t;
        }

        public async Task<bool> LoadDiagnozy() // assume we return an int from this long running operation 
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\data\\" + diagnozyFileName))
            {
                MessageBox.Show("Súbor s diagnózami nebol nájdený");
                return false;
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
            return true;
        } 
    }
}
