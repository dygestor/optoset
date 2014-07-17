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
    public partial class PoistovneForm : Form
    {

        private PobockyController _pc;
        private DataTable _data;

        public PoistovneForm()
        {
            InitializeComponent();
        }

        private void PoistovneForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        public void Initiate(PobockyController pc)
        {
            _pc = pc;

            //dataGridView1.DataSource = GetTable();
            string[] row = { _pc.Pobocky[0].Cislo, _pc.Pobocky[0].Nazov };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                cisloTextBox.Text = listView1.Items[indices[0]].SubItems[0].Text;
                nazovTextBox.Text = listView1.Items[indices[0]].SubItems[1].Text;
            }
        }

        private void pridatButton_Click(object sender, EventArgs e)
        {
            if (_pc.PridajPobocku(cisloTextBox.Text, nazovTextBox.Text))
            {
                string[] row = { cisloTextBox.Text, nazovTextBox.Text };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
        }

        private void upravitButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (_pc.UpravitPobocku(indices[0], cisloTextBox.Text, nazovTextBox.Text))
                {
                    //string[] row = {cisloTextBox.Text, nazovTextBox.Text};
                    //var listViewItem = new ListViewItem(row);
                    listView1.Items[indices[0]].SubItems[0].Text = cisloTextBox.Text;
                    listView1.Items[indices[0]].SubItems[1].Text = nazovTextBox.Text;
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť pobočku na upravenie");
            }
        }

        private void zmazatButton_Click(object sender, EventArgs e)
        {
            var indices = listView1.SelectedIndices;
            if (indices.Count > 0)
            {
                if (_pc.ZmazatPobocku(indices[0]))
                {
                    listView1.Items.RemoveAt(indices[0]);
                }
            }
            else
            {
                MessageBox.Show("Musíte zvoliť pobočku na zmazanie");
            }
        }

        private void zavrietButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
