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

namespace Optoset
{
    public partial class FakturaForm : Form
    {

        private FakturyController _fc;
        private ZmluvyController _zc;
        private const string cennikyDirectory = "cenniky";
        private Optoset _opt;
        private int _fIndex;

        public FakturaForm()
        {
            InitializeComponent();
        }

        private void FakturaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void Initiate(FakturyController fc, ZmluvyController zc, Optoset opt, int index = -1)
        {
            _fc = fc;
            _zc = zc;
            _opt = opt;
            _fIndex = index;

            foreach (var z in _zc.Zmluvy)
            {
                comboBox1.Items.Add(z.Cislo);
            }

            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory))
            {
                foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\data\\" + cennikyDirectory))
                {
                    var name = Path.GetFileNameWithoutExtension(file);
                    comboBox2.Items.Add(name);
                }
            }

            if (_fIndex > -1)
            {
                var f = _fc.Faktury[_fIndex];
                textBox1.Text = f.Cislo;

                var z = _zc.Zmluvy.Find(x => x.Cislo == f.Poistovna);
                comboBox1.Text = z.Cislo;

                dateTimePicker1.Text = f.Obdobie;
                comboBox2.Text = f.Cennik;

                button1.Text = "Uložiť a zavrieť";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_fIndex > -1)
            {
                if (_fc.UpravFakturu(_fIndex, textBox1.Text, comboBox1.Text, dateTimePicker1.Text, comboBox2.Text))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Prosím vyplňte všetky údaje.");
                }
            }
            else
            {
                if (_fc.PridajFakturu(textBox1.Text, comboBox1.Text, dateTimePicker1.Text, comboBox2.Text))
                {
                    _opt.PridajTab();
                    Close();
                }
            }
        }
    }
}
