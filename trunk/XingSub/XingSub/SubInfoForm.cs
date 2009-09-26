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

        private void CancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
