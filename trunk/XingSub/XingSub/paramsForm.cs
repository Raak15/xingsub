﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace XingSub
{
    public partial class paramsForm : Form
    {
        public paramsForm()
        {
            InitializeComponent();
        }

        public string paramsFile = "";

        private XmlDocument xml = new XmlDocument();
        private XmlNode ps;

        private void paramsForm_Load(object sender, EventArgs e)
        {
            if (paramsFile.Length == 0 || !File.Exists(paramsFile))
            {
                this.Close();
            }

            xml.Load(paramsFile);

            ps = xml.DocumentElement["params"];
            if (ps.HasChildNodes)
            {
                foreach (XmlNode x in ps.ChildNodes)
                {
                    ListViewItem item = listView1.Items.Add(x.Attributes["description"].FirstChild.Value);
                    item.Name = x.Name;
                    item.SubItems.Add(x.FirstChild.Value);
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                textBox1.Text = e.Item.SubItems[1].Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                listView1.SelectedItems[0].SubItems[1].Text = textBox1.Text;
                ps[listView1.SelectedItems[0].Name].FirstChild.Value = textBox1.Text;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            xml.Save(paramsFile);
            this.Close();
        }

        private void canButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
