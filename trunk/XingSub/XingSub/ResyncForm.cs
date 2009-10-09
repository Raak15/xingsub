using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace XingSub
{
    public delegate void SaveToXingSubEventHandler(AdvancedSubStationAlpha sub);

    public partial class ResyncForm : Form
    {
        public event SaveToXingSubEventHandler SaveToXingSub;
        public AdvancedSubStationAlpha subtitles = new AdvancedSubStationAlpha();

        private bool fromXS = false;
        private List<int> rowsToResync = new List<int>();
        private int editingValue = 0;

        public ResyncForm()
        {
            InitializeComponent();
        }

        public void LoadFromXingSub(AdvancedSubStationAlpha sub)
        {
            subtitles = sub;
            fromXS = true;
            LoadSubtitles();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            openFileDialog1.Title = Localizable.OpenTitle;
            openFileDialog1.Filter = Localizable.OpenFileType;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Length == 0) return;

            StreamReader fileReader = new StreamReader(openFileDialog1.FileName);
            subtitles = new AdvancedSubStationAlpha();
            subtitles.LoadAss(fileReader.ReadToEnd());
            fileReader.Close();
            fromXS = false;
            LoadSubtitles();
        }

        private void LoadSubtitles()
        {
            if (subtitles.Events != null && subtitles.Styles != null)
            {
                if (subtitles.Events.Count > 0 && subtitles.Styles.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Visible = false;
                    toolStripProgressBar1.Visible = true;

                    toolStripStatusLabel1.Text = Localizable.LoadingSubtitleStyles;
                    toolStripProgressBar1.Maximum = subtitles.Styles.Count;
                    for (int i = 0; i < subtitles.Styles.Count; i++)
                    {
                        ColumnStyles.Items.Add(subtitles.Styles[i].Name);
                        if (i % Math.Round((double)(subtitles.Styles.Count / 20)) == 0) toolStripProgressBar1.Value = i + 1;
                        Application.DoEvents();
                    }

                    toolStripStatusLabel1.Text = Localizable.LoadingSubtitleEvents;
                    toolStripProgressBar1.Maximum = subtitles.Events.Count;
                    for (int i = 0; i < subtitles.Events.Count; i++)
                    {
                        dataGridView1.Rows.Add(subtitles.Events[i].Start, subtitles.Events[i].End, subtitles.Events[i].Style, subtitles.Events[i].Text);
                        if (i % Math.Round((double)(subtitles.Events.Count / 20)) == 0) toolStripProgressBar1.Value = i + 1;
                        Application.DoEvents();
                    }

                    ColumnStyles.Visible = !fromXS;

                    toolStripProgressBar1.Visible = false;
                    toolStripStatusLabel1.Text = "";
                    dataGridView1.Visible = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fromXS)
            {
                SaveToXingSub(subtitles);
            }
        }

        private void setResyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell d in dataGridView1.SelectedCells)
                {
                    if (rowsToResync.IndexOf(d.RowIndex) == -1)
                    {
                        rowsToResync.Add(d.RowIndex);
                        foreach (DataGridViewCell cell in dataGridView1.Rows[d.RowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.DarkOrange;
                        }
                    }
                    //else
                    //{
                    //    rowsToResync.Remove(d.RowIndex);
                    //    foreach (DataGridViewCell cell in dataGridView1.Rows[d.RowIndex].Cells)
                    //    {
                    //        cell.Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                    //    }
                    //}
                }
            }
        }

        private void clearSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int index in rowsToResync)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[index].Cells)
                {
                    cell.Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                }
            }

            rowsToResync.Clear();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (rowsToResync.IndexOf(e.RowIndex) == -1)
            {
                rowsToResync.Add(e.RowIndex);
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.DarkOrange;
                }
            }
            editingValue = subtitles.StampToMsecond((string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int editedValue = subtitles.StampToMsecond((string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            int delta = editedValue - editingValue;

            foreach (int index in rowsToResync)
            {
                subtitles.Events[index].Start = subtitles.MsecondToStamp(subtitles.StampToMsecond(subtitles.Events[index].Start) + delta);
                subtitles.Events[index].End = subtitles.MsecondToStamp(subtitles.StampToMsecond(subtitles.Events[index].End) + delta);

                dataGridView1.Rows[e.RowIndex].Cells[ColumnStart.Index].Value = subtitles.Events[index].Start;
                dataGridView1.Rows[e.RowIndex].Cells[ColumnEnd.Index].Value = subtitles.Events[index].End;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataGridView1.PointToClient(e.Location));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string status = "";
                foreach (DataGridViewCell d in dataGridView1.SelectedCells)
                {
                    status += d.RowIndex.ToString() + "|";
                }
                toolStripStatusLabel1.Text = status;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }
        }
    }
}
