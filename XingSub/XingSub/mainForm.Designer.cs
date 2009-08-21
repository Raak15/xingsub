namespace XingSub
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.timerCapture = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.insertNewLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetTwoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetBySpaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureTargetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NWEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timingModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocloseTimeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.contextInsertNewline = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerAutoSave = new System.Windows.Forms.Timer(this.components);
            this.ScriptTextBox = new System.Windows.Forms.TextBox();
            this.PreferancesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCapture
            // 
            this.timerCapture.Enabled = true;
            this.timerCapture.Tick += new System.EventHandler(this.timerCapture_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.optionsMenuItem,
            this.helpMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator3,
            this.importMenuItem,
            this.exportMenuItem,
            this.toolStripSeparator1,
            this.PreferancesMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            resources.ApplyResources(this.fileMenuItem, "fileMenuItem");
            // 
            // newMenuItem
            // 
            this.newMenuItem.Image = global::XingSub.Properties.Resources._49_48_;
            this.newMenuItem.Name = "newMenuItem";
            resources.ApplyResources(this.newMenuItem, "newMenuItem");
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::XingSub.Properties.Resources._01_34_;
            this.openMenuItem.Name = "openMenuItem";
            resources.ApplyResources(this.openMenuItem, "openMenuItem");
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::XingSub.Properties.Resources._01_00_;
            this.saveMenuItem.Name = "saveMenuItem";
            resources.ApplyResources(this.saveMenuItem, "saveMenuItem");
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            resources.ApplyResources(this.saveAsMenuItem, "saveAsMenuItem");
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            resources.ApplyResources(this.importMenuItem, "importMenuItem");
            this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            resources.ApplyResources(this.exportMenuItem, "exportMenuItem");
            this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            resources.ApplyResources(this.exitMenuItem, "exitMenuItem");
            this.exitMenuItem.Click += new System.EventHandler(this.editMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem,
            this.deleteMenuItem,
            this.toolStripSeparator5,
            this.selectAllMenuItem,
            this.toolStripSeparator6,
            this.insertNewLineMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            resources.ApplyResources(this.editMenuItem, "editMenuItem");
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Image = global::XingSub.Properties.Resources._18_00_;
            this.cutMenuItem.Name = "cutMenuItem";
            resources.ApplyResources(this.cutMenuItem, "cutMenuItem");
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Image = global::XingSub.Properties.Resources._17_00_;
            this.copyMenuItem.Name = "copyMenuItem";
            resources.ApplyResources(this.copyMenuItem, "copyMenuItem");
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Image = global::XingSub.Properties.Resources._06_42_;
            this.pasteMenuItem.Name = "pasteMenuItem";
            resources.ApplyResources(this.pasteMenuItem, "pasteMenuItem");
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Image = global::XingSub.Properties.Resources._00_04_;
            this.deleteMenuItem.Name = "deleteMenuItem";
            resources.ApplyResources(this.deleteMenuItem, "deleteMenuItem");
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            resources.ApplyResources(this.selectAllMenuItem, "selectAllMenuItem");
            this.selectAllMenuItem.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // insertNewLineMenuItem
            // 
            this.insertNewLineMenuItem.Name = "insertNewLineMenuItem";
            resources.ApplyResources(this.insertNewLineMenuItem, "insertNewLineMenuItem");
            this.insertNewLineMenuItem.Click += new System.EventHandler(this.insertNewLineMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetMenuItem,
            this.captureTargetMenuItem,
            this.timingModeMenuItem,
            this.paramsToolStripMenuItem,
            this.autocloseTimeWindowToolStripMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            resources.ApplyResources(this.optionsMenuItem, "optionsMenuItem");
            // 
            // offsetMenuItem
            // 
            this.offsetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetOneMenuItem,
            this.offsetTwoMenuItem,
            this.offsetBySpaceMenuItem});
            resources.ApplyResources(this.offsetMenuItem, "offsetMenuItem");
            this.offsetMenuItem.Name = "offsetMenuItem";
            // 
            // offsetOneMenuItem
            // 
            this.offsetOneMenuItem.Name = "offsetOneMenuItem";
            resources.ApplyResources(this.offsetOneMenuItem, "offsetOneMenuItem");
            this.offsetOneMenuItem.Click += new System.EventHandler(this.offsetOneMenuItem_Click);
            // 
            // offsetTwoMenuItem
            // 
            this.offsetTwoMenuItem.Name = "offsetTwoMenuItem";
            resources.ApplyResources(this.offsetTwoMenuItem, "offsetTwoMenuItem");
            this.offsetTwoMenuItem.Click += new System.EventHandler(this.offsetTwoMenuItem_Click);
            // 
            // offsetBySpaceMenuItem
            // 
            this.offsetBySpaceMenuItem.Checked = true;
            this.offsetBySpaceMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.offsetBySpaceMenuItem.Name = "offsetBySpaceMenuItem";
            resources.ApplyResources(this.offsetBySpaceMenuItem, "offsetBySpaceMenuItem");
            this.offsetBySpaceMenuItem.Click += new System.EventHandler(this.offsetBySpaceMenuItem_Click);
            // 
            // captureTargetMenuItem
            // 
            this.captureTargetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NWEToolStripMenuItem,
            this.MPCToolStripMenuItem});
            this.captureTargetMenuItem.Name = "captureTargetMenuItem";
            resources.ApplyResources(this.captureTargetMenuItem, "captureTargetMenuItem");
            // 
            // NWEToolStripMenuItem
            // 
            this.NWEToolStripMenuItem.Checked = true;
            this.NWEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NWEToolStripMenuItem.Name = "NWEToolStripMenuItem";
            resources.ApplyResources(this.NWEToolStripMenuItem, "NWEToolStripMenuItem");
            this.NWEToolStripMenuItem.Click += new System.EventHandler(this.NWEToolStripMenuItem_Click);
            // 
            // MPCToolStripMenuItem
            // 
            this.MPCToolStripMenuItem.Name = "MPCToolStripMenuItem";
            resources.ApplyResources(this.MPCToolStripMenuItem, "MPCToolStripMenuItem");
            this.MPCToolStripMenuItem.Click += new System.EventHandler(this.MPCToolStripMenuItem_Click);
            // 
            // timingModeMenuItem
            // 
            this.timingModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalModeMenuItem,
            this.effectsModeMenuItem});
            this.timingModeMenuItem.Name = "timingModeMenuItem";
            resources.ApplyResources(this.timingModeMenuItem, "timingModeMenuItem");
            // 
            // normalModeMenuItem
            // 
            this.normalModeMenuItem.Checked = true;
            this.normalModeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalModeMenuItem.Name = "normalModeMenuItem";
            resources.ApplyResources(this.normalModeMenuItem, "normalModeMenuItem");
            this.normalModeMenuItem.Click += new System.EventHandler(this.normalModeMenuItem_Click);
            // 
            // effectsModeMenuItem
            // 
            this.effectsModeMenuItem.Name = "effectsModeMenuItem";
            resources.ApplyResources(this.effectsModeMenuItem, "effectsModeMenuItem");
            this.effectsModeMenuItem.Click += new System.EventHandler(this.effectsModeMenuItem_Click);
            // 
            // paramsToolStripMenuItem
            // 
            this.paramsToolStripMenuItem.Name = "paramsToolStripMenuItem";
            resources.ApplyResources(this.paramsToolStripMenuItem, "paramsToolStripMenuItem");
            // 
            // autocloseTimeWindowToolStripMenuItem
            // 
            this.autocloseTimeWindowToolStripMenuItem.Checked = true;
            this.autocloseTimeWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autocloseTimeWindowToolStripMenuItem.Name = "autocloseTimeWindowToolStripMenuItem";
            resources.ApplyResources(this.autocloseTimeWindowToolStripMenuItem, "autocloseTimeWindowToolStripMenuItem");
            this.autocloseTimeWindowToolStripMenuItem.Click += new System.EventHandler(this.autocloseTimeWindowToolStripMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            resources.ApplyResources(this.helpMenuItem, "helpMenuItem");
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            resources.ApplyResources(this.aboutMenuItem, "aboutMenuItem");
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextCut,
            this.contextCopy,
            this.contextPaste,
            this.contextDelete,
            this.toolStripSeparator7,
            this.contextSelectAll,
            this.toolStripSeparator9,
            this.contextInsertNewline});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // contextCut
            // 
            this.contextCut.Image = global::XingSub.Properties.Resources._18_00_;
            this.contextCut.Name = "contextCut";
            resources.ApplyResources(this.contextCut, "contextCut");
            this.contextCut.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.Image = global::XingSub.Properties.Resources._17_00_;
            this.contextCopy.Name = "contextCopy";
            resources.ApplyResources(this.contextCopy, "contextCopy");
            this.contextCopy.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // contextPaste
            // 
            this.contextPaste.Image = global::XingSub.Properties.Resources._06_42_;
            this.contextPaste.Name = "contextPaste";
            resources.ApplyResources(this.contextPaste, "contextPaste");
            this.contextPaste.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.Image = global::XingSub.Properties.Resources._00_04_;
            this.contextDelete.Name = "contextDelete";
            resources.ApplyResources(this.contextDelete, "contextDelete");
            this.contextDelete.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // contextSelectAll
            // 
            this.contextSelectAll.Name = "contextSelectAll";
            resources.ApplyResources(this.contextSelectAll, "contextSelectAll");
            this.contextSelectAll.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // contextInsertNewline
            // 
            this.contextInsertNewline.Name = "contextInsertNewline";
            resources.ApplyResources(this.contextInsertNewline, "contextInsertNewline");
            this.contextInsertNewline.Click += new System.EventHandler(this.insertNewLineMenuItem_Click);
            // 
            // timerAutoSave
            // 
            this.timerAutoSave.Enabled = true;
            this.timerAutoSave.Interval = 120000;
            this.timerAutoSave.Tick += new System.EventHandler(this.timerAutoSave_Tick);
            // 
            // ScriptTextBox
            // 
            this.ScriptTextBox.AcceptsReturn = true;
            this.ScriptTextBox.AcceptsTab = true;
            this.ScriptTextBox.AllowDrop = true;
            this.ScriptTextBox.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.ScriptTextBox, "ScriptTextBox");
            this.ScriptTextBox.HideSelection = false;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.TextChanged += new System.EventHandler(this.ScriptTextBox_TextChanged);
            // 
            // PreferancesMenuItem
            // 
            this.PreferancesMenuItem.Name = "PreferancesMenuItem";
            resources.ApplyResources(this.PreferancesMenuItem, "PreferancesMenuItem");
            this.PreferancesMenuItem.Click += new System.EventHandler(this.PreferancesMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScriptTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerCapture;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetOneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetTwoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetBySpaceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextCut;
        private System.Windows.Forms.ToolStripMenuItem contextCopy;
        private System.Windows.Forms.ToolStripMenuItem contextPaste;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem contextSelectAll;
        private System.Windows.Forms.Timer timerAutoSave;
        private System.Windows.Forms.ToolStripMenuItem insertNewLineMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem contextInsertNewline;
        private System.Windows.Forms.ToolStripMenuItem captureTargetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NWEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timingModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocloseTimeWindowToolStripMenuItem;
        private System.Windows.Forms.TextBox ScriptTextBox;
        private System.Windows.Forms.ToolStripMenuItem PreferancesMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

