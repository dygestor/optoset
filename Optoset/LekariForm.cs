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
    public partial class LekariForm : Form
    {

        private LekariController _lc;

        public LekariForm()
        {
            InitializeComponent();
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item = { _lc.Lekari[e.ItemIndex].Kod, _lc.Lekari[e.ItemIndex].Titul, _lc.Lekari[e.ItemIndex].Meno, _lc.Lekari[e.ItemIndex].Priezvisko, _lc.Lekari[e.ItemIndex].Kpzs };
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }

        private void LekariForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lc.Save();
            Hide();
            e.Cancel = true;
        }

        public void Initiate(LekariController lc)
        {
            _lc = lc;

            listView1.VirtualListSize = _lc.Lekari.Count;
        }

        private void pridatButton_Click(object sender, EventArgs e)
        {
            Lekar l = new Lekar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);

            if (_lc.PridatLekara(l))
            {
                listView1.VirtualListSize = _lc.Lekari.Count;
                listView1.Invalidate();
            }
        }

        private void zavrietButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                textBox1.Text = listView1.Items[indices[0]].SubItems[0].Text;
                textBox2.Text = listView1.Items[indices[0]].SubItems[1].Text;
                textBox3.Text = listView1.Items[indices[0]].SubItems[2].Text;
                textBox4.Text = listView1.Items[indices[0]].SubItems[3].Text;
                textBox5.Text = listView1.Items[indices[0]].SubItems[4].Text;
            }
        }

        private void upravitButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (_lc.UpravitLekara(indices[0], textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text))
                {
                    listView1.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť lekára na upravenie");
            }
        }

        private void zmazatButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (_lc.ZmazatLekara(indices[0]))
                {
                    listView1.VirtualListSize = _lc.Lekari.Count;
                    listView1.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť lekára na zmazanie");
            }
        }
    }
}
