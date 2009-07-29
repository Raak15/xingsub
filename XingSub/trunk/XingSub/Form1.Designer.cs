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
            this.timerCapture = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.InsertNewlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.FindAndReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuickReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EffectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OneOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OffsetBySpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.contextInsertNewline = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerAutoSave = new System.Windows.Forms.Timer(this.components);
            this.contextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuickFindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.OptionsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.ImportToolStripMenuItem,
            this.ExportToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.SaveAsToolStripMenuItem.Text = "另存为(&A)...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
            // 
            // ImportToolStripMenuItem
            // 
            this.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
            this.ImportToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ImportToolStripMenuItem.Text = "导入(&I)";
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PluginToolStripMenuItem});
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ExportToolStripMenuItem.Text = "导出(&E)";
            this.ExportToolStripMenuItem.MouseEnter += new System.EventHandler(this.ExportToolStripMenuItem_MouseEnter);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ExitToolStripMenuItem.Text = "退出(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.toolStripSeparator4,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.toolStripSeparator5,
            this.SelectAllToolStripMenuItem,
            this.toolStripSeparator6,
            this.InsertNewlineToolStripMenuItem,
            this.toolStripSeparator8,
            this.FindAndReplaceToolStripMenuItem,
            this.GotoToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.EditToolStripMenuItem.Text = "编辑(&E)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(174, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.DeleteToolStripMenuItem.Text = "删除(&P)";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(174, 6);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.SelectAllToolStripMenuItem.Text = "全选(&A)";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(174, 6);
            // 
            // InsertNewlineToolStripMenuItem
            // 
            this.InsertNewlineToolStripMenuItem.Name = "InsertNewlineToolStripMenuItem";
            this.InsertNewlineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.InsertNewlineToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.InsertNewlineToolStripMenuItem.Text = "插入空行(&I)";
            this.InsertNewlineToolStripMenuItem.Click += new System.EventHandler(this.InsertNewlineToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(174, 6);
            // 
            // FindAndReplaceToolStripMenuItem
            // 
            this.FindAndReplaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuickFindToolStripMenuItem,
            this.QuickReplaceToolStripMenuItem});
            this.FindAndReplaceToolStripMenuItem.Name = "FindAndReplaceToolStripMenuItem";
            this.FindAndReplaceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.FindAndReplaceToolStripMenuItem.Text = "查找和替换(&F)";
            // 
            // QuickReplaceToolStripMenuItem
            // 
            this.QuickReplaceToolStripMenuItem.Name = "QuickReplaceToolStripMenuItem";
            this.QuickReplaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.QuickReplaceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.QuickReplaceToolStripMenuItem.Text = "快速替换(&R)";
            // 
            // GotoToolStripMenuItem
            // 
            this.GotoToolStripMenuItem.Name = "GotoToolStripMenuItem";
            this.GotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.GotoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.GotoToolStripMenuItem.Text = "转到(&G)";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NormalToolStripMenuItem,
            this.EffectsToolStripMenuItem,
            this.toolStripSeparator2,
            this.OffsetToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.OptionsToolStripMenuItem.Text = "选项(&O)";
            // 
            // NormalToolStripMenuItem
            // 
            this.NormalToolStripMenuItem.Checked = true;
            this.NormalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem";
            this.NormalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.NormalToolStripMenuItem.Text = "正常模式";
            this.NormalToolStripMenuItem.Click += new System.EventHandler(this.NormalToolStripMenuItem_Click);
            // 
            // EffectsToolStripMenuItem
            // 
            this.EffectsToolStripMenuItem.Name = "EffectsToolStripMenuItem";
            this.EffectsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.EffectsToolStripMenuItem.Text = "特效模式";
            this.EffectsToolStripMenuItem.Click += new System.EventHandler(this.EffectsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // OffsetToolStripMenuItem
            // 
            this.OffsetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OneOffsetToolStripMenuItem,
            this.TwoOffsetToolStripMenuItem,
            this.OffsetBySpaceToolStripMenuItem});
            this.OffsetToolStripMenuItem.Enabled = false;
            this.OffsetToolStripMenuItem.Name = "OffsetToolStripMenuItem";
            this.OffsetToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.OffsetToolStripMenuItem.Text = "光标偏移";
            // 
            // OneOffsetToolStripMenuItem
            // 
            this.OneOffsetToolStripMenuItem.Name = "OneOffsetToolStripMenuItem";
            this.OneOffsetToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.OneOffsetToolStripMenuItem.Text = "1 格";
            this.OneOffsetToolStripMenuItem.Click += new System.EventHandler(this.OneOffsetToolStripMenuItem_Click);
            // 
            // TwoOffsetToolStripMenuItem
            // 
            this.TwoOffsetToolStripMenuItem.Name = "TwoOffsetToolStripMenuItem";
            this.TwoOffsetToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.TwoOffsetToolStripMenuItem.Text = "2 格";
            this.TwoOffsetToolStripMenuItem.Click += new System.EventHandler(this.TwoOffsetToolStripMenuItem_Click);
            // 
            // OffsetBySpaceToolStripMenuItem
            // 
            this.OffsetBySpaceToolStripMenuItem.Checked = true;
            this.OffsetBySpaceToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OffsetBySpaceToolStripMenuItem.Name = "OffsetBySpaceToolStripMenuItem";
            this.OffsetBySpaceToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.OffsetBySpaceToolStripMenuItem.Text = "根据空格";
            this.OffsetBySpaceToolStripMenuItem.Click += new System.EventHandler(this.OffsetBySpaceToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.AboutToolStripMenuItem.Text = "关于(&A)";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
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
            this.contextSelectAll.Click += new System.EventHandler(this.contextSelectAll_Click);
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
            this.contextInsertNewline.Click += new System.EventHandler(this.contextInsertNewline_Click);
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
            // contextCut
            // 
            this.contextCut.Image = global::XingSub.Properties.Resources._18_00_;
            this.contextCut.Name = "contextCut";
            this.contextCut.Size = new System.Drawing.Size(136, 22);
            this.contextCut.Text = "剪切(&T)";
            this.contextCut.Click += new System.EventHandler(this.contextCut_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.Image = global::XingSub.Properties.Resources._17_00_;
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Size = new System.Drawing.Size(136, 22);
            this.contextCopy.Text = "复制(&C)";
            this.contextCopy.Click += new System.EventHandler(this.contextCopy_Click);
            // 
            // contextPaste
            // 
            this.contextPaste.Image = global::XingSub.Properties.Resources._06_42_;
            this.contextPaste.Name = "contextPaste";
            this.contextPaste.Size = new System.Drawing.Size(136, 22);
            this.contextPaste.Text = "粘贴(&P)";
            this.contextPaste.Click += new System.EventHandler(this.contextPaste_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.Image = global::XingSub.Properties.Resources._00_04_;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(136, 22);
            this.contextDelete.Text = "删除(&D)";
            this.contextDelete.Click += new System.EventHandler(this.contextDelete_Click);
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Image = global::XingSub.Properties.Resources._49_48_;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.NewToolStripMenuItem.Text = "新建(&N)";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = global::XingSub.Properties.Resources._01_34_;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.OpenToolStripMenuItem.Text = "打开(&O)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = global::XingSub.Properties.Resources._01_00_;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.SaveToolStripMenuItem.Text = "保存(&S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Image = global::XingSub.Properties.Resources._02_39_;
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.UndoToolStripMenuItem.Text = "撤销(&U)";
            this.UndoToolStripMenuItem.Visible = false;
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Image = global::XingSub.Properties.Resources._01_39_;
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.RedoToolStripMenuItem.Text = "重做(&R)";
            this.RedoToolStripMenuItem.Visible = false;
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Image = global::XingSub.Properties.Resources._18_00_;
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.CutToolStripMenuItem.Text = "剪切(&T)";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = global::XingSub.Properties.Resources._17_00_;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.CopyToolStripMenuItem.Text = "复制(&C)";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Image = global::XingSub.Properties.Resources._06_42_;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.PasteToolStripMenuItem.Text = "粘贴(&P)";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // QuickFindToolStripMenuItem
            // 
            this.QuickFindToolStripMenuItem.Image = global::XingSub.Properties.Resources._19_01_;
            this.QuickFindToolStripMenuItem.Name = "QuickFindToolStripMenuItem";
            this.QuickFindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.QuickFindToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.QuickFindToolStripMenuItem.Text = "快速查找(&F)";
            // 
            // PluginToolStripMenuItem
            // 
            this.PluginToolStripMenuItem.Enabled = false;
            this.PluginToolStripMenuItem.Name = "PluginToolStripMenuItem";
            this.PluginToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.PluginToolStripMenuItem.Text = "(正在扫描插件...)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 265);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EffectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OneOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TwoOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OffsetBySpaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem FindAndReplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuickFindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuickReplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GotoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextCut;
        private System.Windows.Forms.ToolStripMenuItem contextCopy;
        private System.Windows.Forms.ToolStripMenuItem contextPaste;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem contextSelectAll;
        private System.Windows.Forms.Timer timerAutoSave;
        private System.Windows.Forms.ToolStripMenuItem InsertNewlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem contextInsertNewline;
        private System.Windows.Forms.ToolStripMenuItem PluginToolStripMenuItem;
    }
}

