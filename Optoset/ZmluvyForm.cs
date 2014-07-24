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
    public partial class ZmluvyForm : Form
    {

        private ZmluvyController _zc;

        public ZmluvyForm()
        {
            InitializeComponent();
        }

        private void ZmluvyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _zc.Save();
            Hide();
            e.Cancel = true;
        }

        public void Initiate(ZmluvyController zc)
        {
            _zc = zc;

            foreach (var zmluva in _zc.Zmluvy)
            {
                string[] row = { zmluva.Cislo, zmluva.Nazov, zmluva.Ico, zmluva.Dic, zmluva.Icdph, zmluva.Adresa, zmluva.Iban, zmluva.Bic };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }

            listView1.Sort();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                cisloTextBox.Text = listView1.Items[indices[0]].SubItems[0].Text;
                nazovTextBox.Text = listView1.Items[indices[0]].SubItems[1].Text;
                icoTextBox.Text = listView1.Items[indices[0]].SubItems[2].Text;
                dicTextBox.Text = listView1.Items[indices[0]].SubItems[3].Text;
                icdphTextBox.Text = listView1.Items[indices[0]].SubItems[4].Text;
                adresaRichTextBox.Text = listView1.Items[indices[0]].SubItems[5].Text;
                ibanTextBox.Text = listView1.Items[indices[0]].SubItems[6].Text;
                bicTextBox.Text = listView1.Items[indices[0]].SubItems[7].Text;
            }
        }

        private void pridatButton_Click(object sender, EventArgs e)
        {
            if (_zc.PridajZmluvu(cisloTextBox.Text, nazovTextBox.Text, icoTextBox.Text, dicTextBox.Text, icdphTextBox.Text, adresaRichTextBox.Text, ibanTextBox.Text, bicTextBox.Text))
            {
                string[] row = { cisloTextBox.Text, nazovTextBox.Text, icoTextBox.Text, dicTextBox.Text, icdphTextBox.Text, adresaRichTextBox.Text, ibanTextBox.Text, bicTextBox.Text };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                listView1.Sort();
            }
        }

        private void upravitButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (_zc.UpravitZmluvu(indices[0], cisloTextBox.Text, nazovTextBox.Text, icoTextBox.Text, dicTextBox.Text, icdphTextBox.Text, adresaRichTextBox.Text, ibanTextBox.Text, bicTextBox.Text))
                {
                    //string[] row = {cisloTextBox.Text, nazovTextBox.Text};
                    //var listViewItem = new ListViewItem(row);
                    listView1.Items[indices[0]].SubItems[0].Text = cisloTextBox.Text;
                    listView1.Items[indices[0]].SubItems[1].Text = nazovTextBox.Text;
                    listView1.Items[indices[0]].SubItems[2].Text = icoTextBox.Text;
                    listView1.Items[indices[0]].SubItems[3].Text = dicTextBox.Text;
                    listView1.Items[indices[0]].SubItems[4].Text = icdphTextBox.Text;
                    listView1.Items[indices[0]].SubItems[5].Text = adresaRichTextBox.Text;
                    listView1.Items[indices[0]].SubItems[6].Text = ibanTextBox.Text;
                    listView1.Items[indices[0]].SubItems[7].Text = bicTextBox.Text;
                    listView1.Sort();
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť zmluvu na upravenie");
            }
        }

        private void zmazatButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (_zc.ZmazatPobocku(indices[0]))
                {
                    listView1.Items.RemoveAt(indices[0]);
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť zmluvu na zmazanie");
            }
        }

        private void zavrietButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
