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
        private PoukazForm poukazForm;
        private PomockaForm pomockaForm;

        public TabControl()
        {
            InitializeComponent();
        }

        public ListView LV1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        public ListView LV2
        {
            get { return listView2; }
            set { listView2 = value; }
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
            ff.ShowDialog(this);
        }

        private void pridaťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (poukazForm != null)
            //{
            //    poukazForm.Clear();
            //    poukazForm.ShowDialog(this);
            //}
            //else
            //{
                poukazForm = new PoukazForm();
                poukazForm.Initiate(_fc, _lc, _pc, _opt, _fIndex, _diagnozy);
                poukazForm.ShowDialog(this);
            //}
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            Poukaz p = _fc.Faktury[_fIndex].Poukazy[e.ItemIndex];
            string[] item = { (e.ItemIndex + 1).ToString(), p.RodneCislo, p.Pobocka.ToString(), p.Lekar.Kod, p.Lekar.Kpzs, p.Diagnoza, p.DatumPredpisania, p.DatumVydaja, p.HradiPoistovna.ToString(), p.HradiPacient.ToString() };
            ListViewItem lvi = new ListViewItem(item);
            if (p.Error) lvi.ForeColor = Color.Red;
            e.Item = lvi;
        }

        private void upraviťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }

            if (poukazForm != null)
            {
                poukazForm.NacitajPoukaz(listView1.SelectedIndices[0]);
                poukazForm.ShowDialog(this);
            }
            else
            {
                poukazForm = new PoukazForm();
                poukazForm.Initiate(_fc, _lc, _pc, _opt, _fIndex, _diagnozy, listView1.SelectedIndices[0]);
                poukazForm.ShowDialog(this);
            }
        }

        private void zmazaťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }

            DialogResult dr = MessageBox.Show("Naozaj chcete zmazať vybraný poukaz?", "Potvrdenie voľby", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _fc.Faktury[_fIndex].Poukazy.RemoveAt(listView1.SelectedIndices[0]);
                var index = (listView1.SelectedIndices[0] == _fc.Faktury[_fIndex].Poukazy.Count)
                                ? _fc.Faktury[_fIndex].Poukazy.Count - 1
                                : listView1.SelectedIndices[0];
                listView1.VirtualListSize = _fc.Faktury[_fIndex].Poukazy.Count;
                if (index < _fc.Faktury[_fIndex].Poukazy.Count && index > -1)
                {
                    listView1.Items[index].Selected = true;
                }
                listView1.Invalidate();
            }
        }

        private void pridaťPomôckuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz, ku ktorému chcete pridať poôcku.");
                return;
            }

            if (_fc.Faktury[_fIndex].Poukazy[listView1.SelectedIndices[0]].Pomocky.Count == Settings.MaxPocetPomocok)
            {
                MessageBox.Show("Maximálny počet pomôcok pre poukaz je " + Settings.MaxPocetPomocok + ".");
                return;
            }
            pomockaForm = new PomockaForm();
            pomockaForm.Initiate(_fc.Faktury[_fIndex], listView1.SelectedIndices[0]);
            pomockaForm.ShowDialog(this);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if (listView1.SelectedIndices.Count > 0)
            {
                foreach (var p in _fc.Faktury[_fIndex].Poukazy[listView1.SelectedIndices[0]].Pomocky)
                {
                    string[] item =
                    {
                        p.Pomocka.Kod + " " + p.Pomocka.Nazov + " (" + p.Pomocka.Popis + ")", p.Mnozstvo.ToString(),
                        p.HradiPoistovna.ToString(), p.HradiPacient.ToString(), p.ErrorString
                    };
                    ListViewItem lvi = new ListViewItem(item);
                    if (p.Error) lvi.ForeColor = Color.Red;
                    _fc.Faktury[_fIndex].TabControl.LV2.Items.Add(lvi);
                }
            }
        }

        private void upraviťPomôckuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz, ku ktorému chcete pridať pomôcku.");
                return;
            }

            if (listView2.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť pomôcku, ktorú chcete upraviť.");
                return;
            }
            pomockaForm = new PomockaForm();
            pomockaForm.Initiate(_fc.Faktury[_fIndex], listView1.SelectedIndices[0], listView2.SelectedIndices[0]);
            pomockaForm.ShowDialog(this);
        }

        private void zmazaťPomôckuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }

            if (listView2.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť pomôcku, ktorú chcete zmazať.");
                return;
            }

            DialogResult dr = MessageBox.Show("Naozaj chcete zmazať vybranú pomôcku?", "Potvrdenie voľby", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _fc.Faktury[_fIndex].Poukazy[listView1.SelectedIndices[0]].Pomocky.RemoveAt(listView2.SelectedIndices[0]);
                listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
                _fc.Faktury[_fIndex].PrepocitajCeny(listView1.SelectedIndices[0]);
                listView1.Invalidate();
            }
        }
    }
}
