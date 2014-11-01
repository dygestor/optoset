using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Globalization;

namespace Optoset
{
    public partial class TabControl : UserControl
    {
        private FakturyController _fc;
        private ZmluvyController _zc;
        private LekariController _lc;
        private PobockyController _pc;
        private Optoset _opt;
        private int _fIndex;
        private List<Tuple<string, string>> _diagnozy;
        private PoukazForm poukazForm;
        private PomockaForm pomockaForm;
        private StreamReader stream;

        public TabControl()
        {
            InitializeComponent();
        }

        public ListView LV1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        public ListView LV2
        {
            get { return listView2; }
            set { listView2 = value; }
        }

        public void Initiate(FakturyController fc, ZmluvyController zc, LekariController lc, PobockyController pc, Optoset opt, int index, List<Tuple<string, string>> diagnozy)
        {
            _fc = fc;
            _zc = zc;
            _lc = lc;
            _pc = pc;
            _opt = opt;
            _fIndex = index;
            _diagnozy = diagnozy;
        }

        private void upraviťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FakturaForm();
            ff.Initiate(_fc, _zc, _opt, _fIndex);
            ff.ShowDialog(this);
        }

        private void pridaťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (poukazForm != null)
            //{
            //    poukazForm.Clear();
            //    poukazForm.ShowDialog(this);
            //}
            //else
            //{
                poukazForm = new PoukazForm();
                poukazForm.Initiate(_fc, _lc, _pc, _opt, _fIndex, _diagnozy);
                poukazForm.ShowDialog(this);
            //}
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            Poukaz p = _fc.Faktury[_fIndex].Poukazy[e.ItemIndex];
            string[] item = { (e.ItemIndex + 1).ToString(), p.RodneCislo, p.Pobocka.ToString(), p.Lekar.Kod, p.Lekar.Kpzs, p.Diagnoza, p.DatumPredpisania, p.DatumVydaja, p.HradiPoistovna.ToString(), p.HradiPacient.ToString() };
            ListViewItem lvi = new ListViewItem(item);
            if (p.Error) lvi.ForeColor = Color.Red;
            e.Item = lvi;
        }

        private void upraviťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }

            if (poukazForm != null)
            {
                poukazForm.NacitajPoukaz(listView1.SelectedIndices[0]);
                poukazForm.ShowDialog(this);
            }
            else
            {
                poukazForm = new PoukazForm();
                poukazForm.Initiate(_fc, _lc, _pc, _opt, _fIndex, _diagnozy, listView1.SelectedIndices[0]);
                poukazForm.ShowDialog(this);
            }
        }

        private void zmazaťPoukazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }

            DialogResult dr = MessageBox.Show("Naozaj chcete zmazať vybraný poukaz?", "Potvrdenie voľby", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _fc.Faktury[_fIndex].Poukazy.RemoveAt(listView1.SelectedIndices[0]);
                var index = (listView1.SelectedIndices[0] == _fc.Faktury[_fIndex].Poukazy.Count)
                                ? _fc.Faktury[_fIndex].Poukazy.Count - 1
                                : listView1.SelectedIndices[0];
                listView1.VirtualListSize = _fc.Faktury[_fIndex].Poukazy.Count;
                if (index < _fc.Faktury[_fIndex].Poukazy.Count && index > -1)
                {
                    listView1.Items[index].Selected = true;
                }
                listView1.Invalidate();
            }
        }

        private void pridaťPomôckuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz, ku ktorému chcete pridať poôcku.");
                return;
            }

            if (_fc.Faktury[_fIndex].Poukazy[listView1.SelectedIndices[0]].Pomocky.Count == Settings.MaxPocetPomocok)
            {
                MessageBox.Show("Maximálny počet pomôcok pre poukaz je " + Settings.MaxPocetPomocok + ".");
                return;
            }
            pomockaForm = new PomockaForm();
            pomockaForm.Initiate(_fc.Faktury[_fIndex], listView1.SelectedIndices[0]);
            pomockaForm.ShowDialog(this);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if (listView1.SelectedIndices.Count > 0)
            {
                foreach (var p in _fc.Faktury[_fIndex].Poukazy[listView1.SelectedIndices[0]].Pomocky)
                {
                    string[] item =
                    {
                        p.Pomocka.Kod + " " + p.Pomocka.Nazov + " (" + p.Pomocka.Popis + ")", p.Mnozstvo.ToString(),
                        p.HradiPoistovna.ToString(), p.HradiPacient.ToString(), p.ErrorString
                    };
                    ListViewItem lvi = new ListViewItem(item);
                    if (p.Error) lvi.ForeColor = Color.Red;
                    _fc.Faktury[_fIndex].TabControl.LV2.Items.Add(lvi);
                }
            }
        }

        private void upraviťPomôckuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz, ku ktorému chcete pridať pomôcku.");
                return;
            }

            if (listView2.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť pomôcku, ktorú chcete upraviť.");
                return;
            }
            pomockaForm = new PomockaForm();
            pomockaForm.Initiate(_fc.Faktury[_fIndex], listView1.SelectedIndices[0], listView2.SelectedIndices[0]);
            pomockaForm.ShowDialog(this);
        }

        private void zmazaťPomôckuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť poukaz.");
                return;
            }

            if (listView2.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Musíte zvoliť pomôcku, ktorú chcete zmazať.");
                return;
            }

            DialogResult dr = MessageBox.Show("Naozaj chcete zmazať vybranú pomôcku?", "Potvrdenie voľby", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _fc.Faktury[_fIndex].Poukazy[listView1.SelectedIndices[0]].Pomocky.RemoveAt(listView2.SelectedIndices[0]);
                listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
                _fc.Faktury[_fIndex].PrepocitajCeny(listView1.SelectedIndices[0]);
                listView1.Invalidate();
            }
        }

        private void tlacitFakturuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    stream = new StreamReader(Directory.GetCurrentDirectory() + "\\data\\diagnozy.csv");
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        var pd = new PrintDocument();
                        pd.PrinterSettings = printDialog.PrinterSettings;
                        pd.PrintPage += pd_PrintPage;
                        pd.Print();
                    }
                }
                finally {
                    stream.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            var printFont = new Font("Arial", 10);

            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height /
               printFont.GetHeight(e.Graphics);

            // Print each line of the file. 
            while (count < linesPerPage && ((line = stream.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page. 
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void exportovaťDávkuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                var pocetPomocok = 0;
                foreach (var poukaz in _fc.Faktury[_fIndex].Poukazy)
                {
                    pocetPomocok += poukaz.Pomocky.Count;
                }

                var csv = new StringBuilder();
                csv.Append(string.Format("N|738|{0}|{1}|000001|{2}|001|001|{3}|{4}", Settings.Ico, DateTime.Now.ToString("yyyyMMdd"), pocetPomocok.ToString("D6"), _fc.Faktury[_fIndex].Poistovna, Environment.NewLine));
                csv.Append(string.Format("{0}|{1}|{2}|{3}|EUR|{4}", _fc.Faktury[_fIndex].Cislo, _fc.Faktury[_fIndex].Obdobie, Settings.KodPoskytovatela.Substring(0, 6), Settings.KodPoskytovatela, Environment.NewLine));

                int i = 1;
                foreach (var p in _fc.Faktury[_fIndex].Poukazy)
                {
                    DateTime predpisanie = DateTime.ParseExact(p.DatumPredpisania, "d.M.yyyy", CultureInfo.InvariantCulture);
                    DateTime vydanie = DateTime.ParseExact(p.DatumVydaja, "d.M.yyyy", CultureInfo.InvariantCulture);
                    string diagnoza = p.Diagnoza.Split(' ')[0].Replace(".", "");

                    foreach (var pomocka in p.Pomocky)
                    {
                        string mnozstvo = pomocka.Mnozstvo.ToString("D2") + ".000";
                        string hradiPoistovna = pomocka.HradiPoistovna.ToString("000000.00", CultureInfo.InvariantCulture);
                        string hradiPacient = pomocka.HradiPacient.ToString("000000.00", CultureInfo.InvariantCulture);
                        csv.Append(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}||||{11}", i.ToString("D5"), p.RodneCislo.Replace("/", ""), predpisanie.ToString("yyyyMMdd"), vydanie.ToString("yyyyMMdd"), p.Lekar.Kpzs, p.Lekar.Kod, pomocka.Pomocka.Kod, diagnoza, mnozstvo, hradiPoistovna, hradiPacient, Environment.NewLine));
                    }

                    i++;
                }

                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\data\\exporty\\" + _fc.Faktury[_fIndex].Obdobie);
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\data\\exporty\\" + _fc.Faktury[_fIndex].Obdobie + "\\davka.001", csv.ToString());

                MessageBox.Show("Dávka bola úspešne uložená.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pri ukladaní dávky došlo k chybe.");
            }
        }
    }
}
