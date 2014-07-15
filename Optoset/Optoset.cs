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
        private PoistovneForm poistovneForm;

        //controllers
        private PoistovneController _pc;

        public Optoset()
        {
            InitializeComponent();

            _pc = new PoistovneController();
        }

        private void zobrazToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pobockyPoistovniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            poistovneForm = new PoistovneForm();
            poistovneForm.Initiate(_pc);
            poistovneForm.Show();
        }
    }
}
