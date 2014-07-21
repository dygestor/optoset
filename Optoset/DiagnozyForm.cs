using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optoset
{
    public partial class DiagnozyForm : Form
    {

        private List<Tuple<string, string>> _diagnozy;

        public DiagnozyForm()
        {
            InitializeComponent();
        }

        private void DiagnozyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        public void Initiate(List<Tuple<string, string>> diagnozy)
        {
            _diagnozy = diagnozy;
            listView1.VirtualListSize = _diagnozy.Count;
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string[] item = { _diagnozy[e.ItemIndex].Item1, _diagnozy[e.ItemIndex].Item2 };
            ListViewItem lvi = new ListViewItem(item);
            e.Item = lvi;
        }
    }
}
