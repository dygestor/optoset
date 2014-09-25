using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public partial class TabControl : UserControl
    {
        private FakturyController _fc;
        private ZmluvyController _zc;
        private Optoset _opt;
        private int _fIndex;
        public TabControl()
        {
            InitializeComponent();
        }

        public ListView LV1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        private void nastaveniaFaktúryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FakturaForm();
            ff.Initiate(_fc, _zc, _opt, _fIndex);
            ff.Show();
        }

        public void Initiate(FakturyController fc, ZmluvyController zc, Optoset opt, int index)
        {
            _fc = fc;
            _zc = zc;
            _opt = opt;
            _fIndex = index;
        }
    }
}
