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
                    dataGridView1.Visible = false;
                    toolStripProgressBar1.Visible = true;

                    toolStripStatusLabel1.Text = Localizable.LoadingSubtitleStyles;
                    toolStripProgressBar1.Maximum = subtitles.Styles.Count;
                    for (int i = 0; i < subtitles.Styles.Count; i++)
                    {
                        ColumnStyles.Items.Add(subtitles.Styles[i].Name);
                        toolStripProgressBar1.Value = i + 1;
                        Application.DoEvents();
                    }

                    toolStripStatusLabel1.Text = Localizable.LoadingSubtitleEvents;
                    toolStripProgressBar1.Maximum = subtitles.Events.Count;
                    for (int i = 0; i < subtitles.Events.Count; i++)
                    {
                        dataGridView1.Rows.Add(subtitles.Events[i].Start, subtitles.Events[i].End, subtitles.Events[i].Style, subtitles.Events[i].Text);
                        toolStripProgressBar1.Value = i + 1;
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
    }
}
