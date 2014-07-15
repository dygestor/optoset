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

        private PoistovneController _pc;
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

        public void Initiate(PoistovneController pc)
        {
            _pc = pc;

            dataGridView1.DataSource = GetTable();
        }

        private DataTable GetTable()
        {
            _data = new DataTable("poistovne");

            _data.Columns.Add("Číslo poisťovne");
            _data.Columns.Add("Názov poisťovne");

            for (int i = 0; i < _pc.Poistovne.Count; i++)
            {
                _data.Rows.Add();

                _data.Rows[i][0] = _pc.Poistovne[i].Cislo;
                _data.Rows[i][1] = _pc.Poistovne[i].Nazov;
            }

            _data.RowChanged += RowChange;

            return _data;
        }

        private void RowChange(object sender, DataRowChangeEventArgs e)
        {
            int index = _data.Rows.IndexOf(e.Row);
        }
    }
}
