using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace XingSub
{
    public partial class SubInfoForm : Form
    {
        public SubInfoForm()
        {
            InitializeComponent();
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            FontnameTextBox.Text = fontDialog1.Font.Name;
            FontnameTextBox.Font = new Font(FontnameTextBox.Font, fontDialog1.Font.Style);
        }

        private void PColorTextBox_TextChanged(object sender, EventArgs e)
        {
            setColor(PColorTextBox);
        }

        private void SColorTextBox_TextChanged(object sender, EventArgs e)
        {
            setColor(SColorTextBox);
        }

        private void OColorTextBox_TextChanged(object sender, EventArgs e)
        {
            setColor(OColorTextBox);
        }

        private void BColorTextBox_TextChanged(object sender, EventArgs e)
        {
            setColor(BColorTextBox);
        }

        private void setColor(TextBox textBox)
        {
            Regex reg = new Regex(@"#H[a-f0-9]{8}", RegexOptions.IgnoreCase);
            if (reg.IsMatch(textBox.Text))
            {
                int red = Convert.ToInt32(textBox.Text.Substring(8, 2), 16);
                int green = Convert.ToInt32(textBox.Text.Substring(6, 2), 16);
                int blue = Convert.ToInt32(textBox.Text.Substring(4, 2), 16);

                textBox.BackColor = Color.FromArgb(red, green, blue);
                textBox.ForeColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }
    }
}
