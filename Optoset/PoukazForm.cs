﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        private int _fIndex;

        private List<Tuple<string, string>> _diagnozy;

        private const string diagnozyFileName = "diagnozy.csv";

        public PoukazForm()
        {
            InitializeComponent();
        }

        private void PoukazForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void Initiate(FakturyController fc, LekariController lc, PobockyController pc, Optoset opt, int fIndex)
        {
            _fc = fc;
            _lc = lc;
            _pc = pc;
            _opt = opt;
            _fIndex = fIndex;

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

            //comboBox3.Items.Clear();
            comboBox3.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (var d in _diagnozy)
            {
                //comboBox3.Items.Add(d.Item1 + " " + d.Item2);
                comboBox3.AutoCompleteCustomSource.Add(d.Item1 + " " + d.Item2);
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
                _fc.Faktury[_fIndex].Poukazy.Add(poukaz);
                _fc.Faktury[_fIndex].TabControl.LV1.VirtualListSize = _fc.Faktury[_fIndex].Poukazy.Count;
                _fc.Faktury[_fIndex].TabControl.LV1.Invalidate();
                Close();
            }
        }
    }
}
