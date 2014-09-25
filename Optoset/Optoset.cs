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

        //filenames
        

        public Optoset()
        {
            InitializeComponent();

            _pc = new PobockyController();
            _zc = new ZmluvyController();
            _lc = new LekariController();
            _fc = new FakturyController();
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
            diagnozyForm.Initiate();
            diagnozyForm.Show();
        }

        private void cennikyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cennikyForm = new CennikyForm();
            cennikyForm.Initiate();
            cennikyForm.Show();
        }

        private void nastaveniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nastaveniaForm = new NastaveniaForm();
            nastaveniaForm.Initiate();
            nastaveniaForm.Show();
        }

        private void lekariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lekariForm = new LekariForm();
            lekariForm.Initiate(_lc);
            lekariForm.Show();
        }

        private void Optoset_Shown(object sender, EventArgs e)
        {
            if (!Settings.Nacitaj())
            {
                MessageBox.Show("Prosím vyplňte nastavenia aplikácie.");
                nastaveniaForm = new NastaveniaForm();
                nastaveniaForm.Initiate();
                nastaveniaForm.Show();
            }
        }

        private void novyMesiacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fakturaForm = new FakturaForm();
            fakturaForm.Initiate(_fc, _zc, this);
            fakturaForm.Show();
        }

        public void PridajTab()
        {
            TabPage nTab = new TabPage();
            tabControl1.TabPages.Add(nTab);
            var i = tabControl1.TabPages.Count;
            nTab.Name = "Tab" + i;
            nTab.Text = "Faktúra " + _fc.Faktury.Last().Cislo;
            TabControl cnt = new TabControl();
            cnt.Initiate(_fc, _zc, this, i-1);
            cnt.Name = "Cnt" + i;
            cnt.Dock = DockStyle.Fill;
            nTab.Controls.Add(cnt);
        }
    }
}
