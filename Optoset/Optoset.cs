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

        //controllers
        private PobockyController _pc;
        private ZmluvyController _zc;
        private LekariController _lc;

        //diagnozy
        private List<Tuple<string, string>> _diagnozy;

        //filenames
        

        public Optoset()
        {
            InitializeComponent();

            _pc = new PobockyController();
            _zc = new ZmluvyController();
            _lc = new LekariController();
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
    }
}
