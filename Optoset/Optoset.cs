using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public partial class Optoset : Form
    {

        //forms
        private PobockyForm pobockyForm;
        private ZmluvyForm zmluvyForm;

        //controllers
        private PobockyController _pc;
        private ZmluvyController _zc;

        public Optoset()
        {
            InitializeComponent();

            _pc = new PobockyController();
            _zc = new ZmluvyController();
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
    }
}
