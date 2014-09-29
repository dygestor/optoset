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

namespace Optoset
{
    public partial class PoukazForm : Form
    {
        private PobockyController _pc;
        private LekariController _lc;
        private FakturyController _fc;
        private Optoset _opt;
        private int _fIndex, _pIndex;

        private List<Tuple<string, string>> _diagnozy;

        

        public PoukazForm()
        {
            InitializeComponent();

        }

        private void PoukazForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void Initiate(FakturyController fc, LekariController lc, PobockyController pc, Optoset opt, int fIndex, List<Tuple<string, string>> diagnozy, int pIndex = -1)
        {
            _fc = fc;
            _lc = lc;
            _pc = pc;
            _opt = opt;
            _fIndex = fIndex;
            _pIndex = pIndex;

            comboBox1.Items.Clear();
            comboBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (var p in _pc.Pobocky)
            {
                if (p.Cislo.StartsWith(_fc.Faktury[_fIndex].Poistovna))
                {
                    comboBox1.Items.Add(p.Cislo + " " + p.Nazov);
                    comboBox1.AutoCompleteCustomSource.Add(p.Cislo + " " + p.Nazov);
                }
            }

            comboBox2.Items.Clear();
            comboBox2.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (var l in _lc.Lekari)
            {
                comboBox2.Items.Add(l.Priezvisko + " " + l.Meno + " " + l.Titul);
                comboBox2.AutoCompleteCustomSource.Add(l.Priezvisko + " " + l.Meno + " " + l.Titul);
            }
            
            comboBox3.Items.Clear();
            comboBox3.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            comboBox3.BeginUpdate();
            foreach (var d in diagnozy)
            {
                comboBox3.Items.Add(d.Item1 + " " + d.Item2);
                comboBox3.AutoCompleteCustomSource.Add(d.Item1 + " " + d.Item2);
            }
            comboBox3.EndUpdate();

            if (pIndex > -1)
            {
                Poukaz p = _fc.Faktury[_fIndex].Poukazy[pIndex];
                comboBox1.Text = p.Pobocka.ToString();
                textBox1.Text = p.RodneCislo;
                comboBox2.Text = p.Lekar.ToString();
                textBox2.Text = p.Lekar.Kod;
                textBox3.Text = p.Lekar.Kpzs;
                comboBox3.Text = p.Diagnoza;
                dateTimePicker1.Text = p.DatumPredpisania;
                dateTimePicker2.Text = p.DatumVydaja;
                button1.Text = "Upraviť poukaz";
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboBox2.SelectedIndex;
            textBox2.Text = _lc.Lekari[index].Kod;
            textBox3.Text = _lc.Lekari[index].Kpzs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pobocka p = _pc.Pobocky.Find(x => x.Cislo.Equals(comboBox1.Text.Split(' ')[0]));
            Lekar l = (comboBox2.SelectedIndex > -1) ? _lc.Lekari[comboBox2.SelectedIndex] : null;
            var poukaz = new Poukaz(p, textBox1.Text, l, comboBox3.Text, dateTimePicker1.Text, dateTimePicker2.Text);

            if (poukaz.Validate())
            {
                if (_pIndex > -1)
                {
                    poukaz.Pomocky = _fc.Faktury[_fIndex].Poukazy[_pIndex].Pomocky;
                    _fc.Faktury[_fIndex].Poukazy[_pIndex] = poukaz;
                    _fc.Faktury[_fIndex].TabControl.LV1.Items[_pIndex].Selected = true;
                }
                else
                {
                    _fc.Faktury[_fIndex].Poukazy.Add(poukaz);
                    _fc.Faktury[_fIndex].TabControl.LV1.VirtualListSize = _fc.Faktury[_fIndex].Poukazy.Count;
                    _fc.Faktury[_fIndex].TabControl.LV1.Items[_fc.Faktury[_fIndex].TabControl.LV1.Items.Count - 1].Selected = true;
                }
                _fc.Faktury[_fIndex].TabControl.LV1.Invalidate();
                Close();
            }
        }

        public void Clear()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        public void NacitajPoukaz(int index)
        {
            _pIndex = index;
            Poukaz p = _fc.Faktury[_fIndex].Poukazy[index];
            comboBox1.Text = p.Pobocka.ToString();
            textBox1.Text = p.RodneCislo;
            comboBox2.Text = p.Lekar.ToString();
            textBox2.Text = p.Lekar.Kod;
            textBox3.Text = p.Lekar.Kpzs;
            comboBox3.Text = p.Diagnoza;
            dateTimePicker1.Text = p.DatumPredpisania;
            dateTimePicker2.Text = p.DatumVydaja;
            button1.Text = "Upraviť poukaz";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) return;
            if (textBox1.Text.Length == 6)
            {
                textBox1.Text += "/";
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }
    }
}
