using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XingSub
{
    public partial class headerForm : Form
    {
        public headerForm()
        {
            InitializeComponent();
        }

        private void canButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
