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
            foreach (var diagnoza in diagnozy)
            {
                string[] item = {diagnoza.Item1, diagnoza.Item2};
                var listViewItem = new ListViewItem(item);
                listView1.Items.Add(listViewItem);
            }
        }
    }
}
