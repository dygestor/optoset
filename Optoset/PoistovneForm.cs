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

            for(int i = 0; i < _pc.Poistovne.Count; i++)
            {
                _data.Rows.Add();

                _data.Rows[i][0] = _pc.Poistovne[i].Cislo;
                _data.Rows[i][1] = _pc.Poistovne[i].Nazov;
            }

            _data.ColumnChanging += ColumnChange;

            return _data;
        }

        private void ColumnChange(object sender, DataColumnChangeEventArgs e)
        {
            string value = e.ProposedValue.ToString();
            int rowIndex = _data.Rows.IndexOf(e.Row);
            int columnIndex = _data.Columns.IndexOf(e.Column);

            if (rowIndex < _pc.Poistovne.Count && rowIndex != -1)
            {
                switch (columnIndex)
                {
                    case 0:
                        if (!_pc.UpravCislo(rowIndex, e.ProposedValue.ToString()))
                        {
                            e.ProposedValue = _pc.Poistovne[rowIndex].Cislo;
                        }
                        break;
                    case 1:
                        if (!_pc.UpravNazov(rowIndex, e.ProposedValue.ToString()))
                        {
                            e.ProposedValue = _pc.Poistovne[rowIndex].Nazov;
                        }
                        break;
                }
            }
            else
            {
                if (!e.Row[0].ToString().Equals("") && !e.Row[1].ToString().Equals(""))
                {
                    if (!_pc.PridajPoistovnu(e.Row[0].ToString(), e.Row[1].ToString()))
                    {
                        e.ProposedValue = "";
                    }
                }
            }

            //Console.Out.Write(_pc.Poistovne);
        }
    }
}
