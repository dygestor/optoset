using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private CennikyForm cennikyForm;
        private NastaveniaForm nastaveniaForm;
        private LekariForm lekariForm;
        private FakturaForm fakturaForm;

        //controllers
        private PobockyController _pc;
        private ZmluvyController _zc;
        private LekariController _lc;
        private FakturyController _fc;

        //diagnozy
        private List<Tuple<string, string>> _diagnozy;

        private const string diagnozyFileName = "diagnozy.csv";
        private const string mesiaceDirectory = "\\data\\mesiace";

        public System.Windows.Forms.TabControl TabControl
        {
            get { return tabControl1; }
            set { tabControl1 = value; }
        }

        public Optoset()
        {
            InitializeComponent();

            _pc = new PobockyController();
            _zc = new ZmluvyController();
            _lc = new LekariController();
            _fc = new FakturyController();

            new Thread(new ThreadStart(Run)).Start();

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + mesiaceDirectory);
        }

        private void Run()
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
        }

        private void zobrazToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pobockyPoistovniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pobockyForm = new PobockyForm();
            pobockyForm.Initiate(_pc);
            pobockyForm.ShowDialog(this);
        }

        private void zmluvyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmluvyForm = new ZmluvyForm();
            zmluvyForm.Initiate(_zc);
            zmluvyForm.ShowDialog(this);
        }

        private void diagnozyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diagnozyForm = new DiagnozyForm();
            diagnozyForm.Initiate();
            diagnozyForm.ShowDialog(this);
        }

        private void cennikyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cennikyForm = new CennikyForm();
            cennikyForm.Initiate();
            cennikyForm.ShowDialog(this);
        }

        private void nastaveniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nastaveniaForm = new NastaveniaForm();
            nastaveniaForm.Initiate();
            nastaveniaForm.ShowDialog(this);
        }

        private void lekariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lekariForm = new LekariForm();
            lekariForm.Initiate(_lc);
            lekariForm.ShowDialog(this);
        }

        private void Optoset_Shown(object sender, EventArgs e)
        {
            if (!Settings.Nacitaj())
            {
                MessageBox.Show("Prosím vyplňte nastavenia aplikácie.");
                nastaveniaForm = new NastaveniaForm();
                nastaveniaForm.Initiate();
                nastaveniaForm.ShowDialog(this);
            }
        }

        private void novyMesiacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fakturaForm = new FakturaForm();
            fakturaForm.Initiate(_fc, _zc, this);
            fakturaForm.ShowDialog(this);
        }

        public void PridajTab()
        {
            TabPage nTab = new TabPage();
            tabControl1.TabPages.Add(nTab);
            var i = tabControl1.TabPages.Count;
            nTab.Name = "Tab" + i;
            nTab.Text = "Faktúra " + _fc.Faktury.Last().Cislo;
            TabControl cnt = new TabControl();
            cnt.Initiate(_fc, _zc, _lc, _pc, this, i-1, _diagnozy);
            cnt.Name = "Cnt" + i;
            cnt.Dock = DockStyle.Fill;
            nTab.Controls.Add(cnt);
            _fc.Faktury.Last().TabControl = cnt;
            ulozitFakturuToolStripMenuItem.Enabled = true;
        }

        private void ulozitFakturuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _fc.UlozFakturu(tabControl1.SelectedIndex);
        }

        private void otvoritMesiacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + mesiaceDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!_fc.NacitajFakturu(openFileDialog1.FileName, _pc, _lc))
                {
                    MessageBox.Show("Pri otváraní faktúry došlo k chybe");
                }
                else
                {
                    PridajTab();
                    var faktura = _fc.Faktury.Last();
                    faktura.TabControl.LV1.VirtualListSize = faktura.Poukazy.Count;

                    for (int i = 0; i < faktura.Poukazy.Count; i++)
                    {
                        faktura.PrepocitajCeny(i, false);   
                    }
                    faktura.TabControl.LV1.Invalidate();
                }
            }
        }
    }
}
