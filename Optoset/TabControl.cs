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
        private LekariController _lc;
        private PobockyController _pc;
        private Optoset _opt;
        private int _fIndex;
        private List<Tuple<string, string>> _diagnozy;

        public TabControl()
        {
            InitializeComponent();
        }

        public ListView LV1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        public void Initiate(FakturyController fc, ZmluvyController zc, LekariController lc, PobockyController pc, Optoset opt, int index, List<Tuple<string, string>> diagnozy)
        {
            _fc = fc;
            _zc = zc;
            _lc = lc;
            _pc = pc;
            _opt = opt;
            _fIndex = index;
            _diagnozy = diagnozy;
        }

        private void upraviťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FakturaForm();
            ff.Initiate(_fc, _zc, _opt, _fIndex);
            ff.Show();
        }

        private void pridaťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var pf = new PoukazForm();
            pf.Initiate(_fc, _lc, _pc, _opt, _fIndex, _diagnozy);
            pf.Show();
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            Poukaz p = _fc.Faktury[_fIndex].Poukazy[e.ItemIndex];
            string[] item = { (e.ItemIndex + 1).ToString(), p.RodneCislo, p.Pobocka.ToString(), p.Lekar.Kod, p.Lekar.Kpzs, p.Diagnoza, p.DatumPredpisania, p.DatumVydaja, "0", "0" };
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }

        private void upraviťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }
            var pf = new PoukazForm();
            pf.Initiate(_fc, _lc, _pc, _opt, _fIndex, _diagnozy, listView1.SelectedIndices[0]);
            pf.Show();
        }
    }
}
