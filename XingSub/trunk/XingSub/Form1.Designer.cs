namespace XingSub
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.pluginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.timingModMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fileMenuItem.Text = "文件(&F)";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Image = global::XingSub.Properties.Resources._49_48_;
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(207, 22);
            this.newMenuItem.Text = "新建(&N)";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::XingSub.Properties.Resources._01_34_;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(207, 22);
            this.openMenuItem.Text = "打开(&O)";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::XingSub.Properties.Resources._01_00_;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveMenuItem.Text = "保存(&S)";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.S)));
            this.saveAsMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveAsMenuItem.Text = "另存为(&A)...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.Size = new System.Drawing.Size(207, 22);
            this.importMenuItem.Text = "导入(&I)";
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginMenuItem});
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exportMenuItem.Text = "导出(&E)";
            this.exportMenuItem.MouseEnter += new System.EventHandler(this.exportMenuItem_MouseEnter);
            // 
            // pluginMenuItem
            // 
            this.pluginMenuItem.Enabled = false;
            this.pluginMenuItem.Name = "pluginMenuItem";
            this.pluginMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pluginMenuItem.Text = "(正在扫描插件...)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exitMenuItem.Text = "退出(&X)";
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
            this.editMenuItem.Size = new System.Drawing.Size(59, 20);
            this.editMenuItem.Text = "编辑(&E)";
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Image = global::XingSub.Properties.Resources._18_00_;
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cutMenuItem.Text = "剪切(&T)";
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Image = global::XingSub.Properties.Resources._17_00_;
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyMenuItem.Text = "复制(&C)";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Image = global::XingSub.Properties.Resources._06_42_;
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMenuItem.Size = new System.Drawing.Size(177, 22);
            this.pasteMenuItem.Text = "粘贴(&P)";
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteMenuItem.Size = new System.Drawing.Size(177, 22);
            this.deleteMenuItem.Text = "删除(&P)";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(174, 6);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectAllMenuItem.Text = "全选(&A)";
            this.selectAllMenuItem.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(174, 6);
            // 
            // insertNewLineMenuItem
            // 
            this.insertNewLineMenuItem.Name = "insertNewLineMenuItem";
            this.insertNewLineMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.insertNewLineMenuItem.Size = new System.Drawing.Size(177, 22);
            this.insertNewLineMenuItem.Text = "插入空行(&I)";
            this.insertNewLineMenuItem.Click += new System.EventHandler(this.insertNewLineMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetMenuItem,
            this.captureTargetMenuItem,
            this.timingModMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(59, 20);
            this.optionsMenuItem.Text = "选项(&O)";
            // 
            // offsetMenuItem
            // 
            this.offsetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetOneMenuItem,
            this.offsetTwoMenuItem,
            this.offsetBySpaceMenuItem});
            this.offsetMenuItem.Enabled = false;
            this.offsetMenuItem.Name = "offsetMenuItem";
            this.offsetMenuItem.Size = new System.Drawing.Size(118, 22);
            this.offsetMenuItem.Text = "光标偏移";
            // 
            // offsetOneMenuItem
            // 
            this.offsetOneMenuItem.Name = "offsetOneMenuItem";
            this.offsetOneMenuItem.Size = new System.Drawing.Size(118, 22);
            this.offsetOneMenuItem.Text = "1 格";
            this.offsetOneMenuItem.Click += new System.EventHandler(this.offsetOneMenuItem_Click);
            // 
            // offsetTwoMenuItem
            // 
            this.offsetTwoMenuItem.Name = "offsetTwoMenuItem";
            this.offsetTwoMenuItem.Size = new System.Drawing.Size(118, 22);
            this.offsetTwoMenuItem.Text = "2 格";
            this.offsetTwoMenuItem.Click += new System.EventHandler(this.offsetTwoMenuItem_Click);
            // 
            // offsetBySpaceMenuItem
            // 
            this.offsetBySpaceMenuItem.Checked = true;
            this.offsetBySpaceMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.offsetBySpaceMenuItem.Name = "offsetBySpaceMenuItem";
            this.offsetBySpaceMenuItem.Size = new System.Drawing.Size(118, 22);
            this.offsetBySpaceMenuItem.Text = "根据空格";
            this.offsetBySpaceMenuItem.Click += new System.EventHandler(this.offsetBySpaceMenuItem_Click);
            // 
            // captureTargetMenuItem
            // 
            this.captureTargetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NWEToolStripMenuItem,
            this.MPCToolStripMenuItem});
            this.captureTargetMenuItem.Name = "captureTargetMenuItem";
            this.captureTargetMenuItem.Size = new System.Drawing.Size(118, 22);
            this.captureTargetMenuItem.Text = "捕捉目标";
            // 
            // NWEToolStripMenuItem
            // 
            this.NWEToolStripMenuItem.Name = "NWEToolStripMenuItem";
            this.NWEToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.NWEToolStripMenuItem.Text = "Nero WaveEditor";
            // 
            // MPCToolStripMenuItem
            // 
            this.MPCToolStripMenuItem.Name = "MPCToolStripMenuItem";
            this.MPCToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.MPCToolStripMenuItem.Text = "Media Player Classic";
            // 
            // timingModMenuItem
            // 
            this.timingModMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectsModeMenuItem,
            this.normalModeMenuItem});
            this.timingModMenuItem.Name = "timingModMenuItem";
            this.timingModMenuItem.Size = new System.Drawing.Size(118, 22);
            this.timingModMenuItem.Text = "计时方式";
            // 
            // effectsModeMenuItem
            // 
            this.effectsModeMenuItem.Name = "effectsModeMenuItem";
            this.effectsModeMenuItem.Size = new System.Drawing.Size(118, 22);
            this.effectsModeMenuItem.Text = "特效模式";
            // 
            // normalModeMenuItem
            // 
            this.normalModeMenuItem.Checked = true;
            this.normalModeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalModeMenuItem.Name = "normalModeMenuItem";
            this.normalModeMenuItem.Size = new System.Drawing.Size(118, 22);
            this.normalModeMenuItem.Text = "正常模式";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(59, 20);
            this.helpMenuItem.Text = "帮助(&H)";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aboutMenuItem.Text = "关于(&A)";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.AllowDrop = true;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.MaxLength = 2147483647;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(559, 219);
            this.textBox1.TabIndex = 3;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 148);
            // 
            // contextCut
            // 
            this.contextCut.Image = global::XingSub.Properties.Resources._18_00_;
            this.contextCut.Name = "contextCut";
            this.contextCut.Size = new System.Drawing.Size(136, 22);
            this.contextCut.Text = "剪切(&T)";
            this.contextCut.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.Image = global::XingSub.Properties.Resources._17_00_;
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Size = new System.Drawing.Size(136, 22);
            this.contextCopy.Text = "复制(&C)";
            this.contextCopy.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // contextPaste
            // 
            this.contextPaste.Image = global::XingSub.Properties.Resources._06_42_;
            this.contextPaste.Name = "contextPaste";
            this.contextPaste.Size = new System.Drawing.Size(136, 22);
            this.contextPaste.Text = "粘贴(&P)";
            this.contextPaste.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.Image = global::XingSub.Properties.Resources._00_04_;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(136, 22);
            this.contextDelete.Text = "删除(&D)";
            this.contextDelete.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(133, 6);
            // 
            // contextSelectAll
            // 
            this.contextSelectAll.Name = "contextSelectAll";
            this.contextSelectAll.Size = new System.Drawing.Size(136, 22);
            this.contextSelectAll.Text = "全选(&A)";
            this.contextSelectAll.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(133, 6);
            // 
            // contextInsertNewline
            // 
            this.contextInsertNewline.Name = "contextInsertNewline";
            this.contextInsertNewline.Size = new System.Drawing.Size(136, 22);
            this.contextInsertNewline.Text = "插入空行(&I)";
            this.contextInsertNewline.Click += new System.EventHandler(this.insertNewLineMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "支持的文件类型(*.xss;*.xse;*.txt)|*.xss;*.xse;*.txt|XingSub 字幕时间轴(*.xss)|*.xss|XingSub 特" +
                "效时间轴(*.xse)|*.xse|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            this.openFileDialog1.Title = "打开文件";
            // 
            // timerAutoSave
            // 
            this.timerAutoSave.Enabled = true;
            this.timerAutoSave.Interval = 120000;
            this.timerAutoSave.Tick += new System.EventHandler(this.timerAutoSave_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 265);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "XingSub - 正常模式 [新文件]";
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
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.ToolStripMenuItem pluginMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureTargetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NWEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timingModMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MPCToolStripMenuItem;
    }
}

