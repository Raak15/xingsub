namespace XingSub
{
    partial class SubInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubInfoForm));
            this.CancButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stylesText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resHeight = new System.Windows.Forms.TextBox();
            this.resWidth = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancButton
            // 
            this.CancButton.AccessibleDescription = null;
            this.CancButton.AccessibleName = null;
            resources.ApplyResources(this.CancButton, "CancButton");
            this.CancButton.BackgroundImage = null;
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Font = null;
            this.CancButton.Name = "CancButton";
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.AccessibleDescription = null;
            this.OKButton.AccessibleName = null;
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.BackgroundImage = null;
            this.OKButton.Font = null;
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.stylesText);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // stylesText
            // 
            this.stylesText.AccessibleDescription = null;
            this.stylesText.AccessibleName = null;
            resources.ApplyResources(this.stylesText, "stylesText");
            this.stylesText.BackgroundImage = null;
            this.stylesText.Font = null;
            this.stylesText.Name = "stylesText";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.resHeight);
            this.groupBox1.Controls.Add(this.resWidth);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // resHeight
            // 
            this.resHeight.AccessibleDescription = null;
            this.resHeight.AccessibleName = null;
            resources.ApplyResources(this.resHeight, "resHeight");
            this.resHeight.BackgroundImage = null;
            this.resHeight.Font = null;
            this.resHeight.Name = "resHeight";
            // 
            // resWidth
            // 
            this.resWidth.AccessibleDescription = null;
            this.resWidth.AccessibleName = null;
            resources.ApplyResources(this.resWidth, "resWidth");
            this.resWidth.BackgroundImage = null;
            this.resWidth.Font = null;
            this.resWidth.Name = "resWidth";
            // 
            // SubInfoForm
            // 
            this.AcceptButton = this.OKButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.CancButton;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancButton);
            this.Font = null;
            this.Icon = null;
            this.Name = "SubInfoForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancButton;
        public System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox stylesText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox resHeight;
        public System.Windows.Forms.TextBox resWidth;

    }
}