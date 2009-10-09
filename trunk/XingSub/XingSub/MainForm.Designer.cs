namespace XingSub
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resyncToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.autocloseTimeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.paramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.AccessibleDescription = null;
            this.menuStrip1.AccessibleName = null;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackgroundImage = null;
            this.menuStrip1.Font = null;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.optionsMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.AccessibleDescription = null;
            this.fileMenuItem.AccessibleName = null;
            resources.ApplyResources(this.fileMenuItem, "fileMenuItem");
            this.fileMenuItem.BackgroundImage = null;
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator3,
            this.importMenuItem,
            this.exportMenuItem,
            this.toolStripSeparator4,
            this.resyncToolToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.ShortcutKeyDisplayString = null;
            // 
            // newMenuItem
            // 
            this.newMenuItem.AccessibleDescription = null;
            this.newMenuItem.AccessibleName = null;
            resources.ApplyResources(this.newMenuItem, "newMenuItem");
            this.newMenuItem.BackgroundImage = null;
            this.newMenuItem.Image = global::XingSub.Properties.Resources.New;
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeyDisplayString = null;
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.AccessibleDescription = null;
            this.openMenuItem.AccessibleName = null;
            resources.ApplyResources(this.openMenuItem, "openMenuItem");
            this.openMenuItem.BackgroundImage = null;
            this.openMenuItem.Image = global::XingSub.Properties.Resources.Open;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeyDisplayString = null;
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.AccessibleDescription = null;
            this.saveMenuItem.AccessibleName = null;
            resources.ApplyResources(this.saveMenuItem, "saveMenuItem");
            this.saveMenuItem.BackgroundImage = null;
            this.saveMenuItem.Image = global::XingSub.Properties.Resources.Save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeyDisplayString = null;
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.AccessibleDescription = null;
            this.saveAsMenuItem.AccessibleName = null;
            resources.ApplyResources(this.saveAsMenuItem, "saveAsMenuItem");
            this.saveAsMenuItem.BackgroundImage = null;
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeyDisplayString = null;
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AccessibleDescription = null;
            this.toolStripSeparator3.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // importMenuItem
            // 
            this.importMenuItem.AccessibleDescription = null;
            this.importMenuItem.AccessibleName = null;
            resources.ApplyResources(this.importMenuItem, "importMenuItem");
            this.importMenuItem.BackgroundImage = null;
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.ShortcutKeyDisplayString = null;
            this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.AccessibleDescription = null;
            this.exportMenuItem.AccessibleName = null;
            resources.ApplyResources(this.exportMenuItem, "exportMenuItem");
            this.exportMenuItem.BackgroundImage = null;
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.ShortcutKeyDisplayString = null;
            this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AccessibleDescription = null;
            this.toolStripSeparator4.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // resyncToolToolStripMenuItem
            // 
            this.resyncToolToolStripMenuItem.AccessibleDescription = null;
            this.resyncToolToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.resyncToolToolStripMenuItem, "resyncToolToolStripMenuItem");
            this.resyncToolToolStripMenuItem.BackgroundImage = null;
            this.resyncToolToolStripMenuItem.Name = "resyncToolToolStripMenuItem";
            this.resyncToolToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.resyncToolToolStripMenuItem.Click += new System.EventHandler(this.resyncToolToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.AccessibleDescription = null;
            this.exitMenuItem.AccessibleName = null;
            resources.ApplyResources(this.exitMenuItem, "exitMenuItem");
            this.exitMenuItem.BackgroundImage = null;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeyDisplayString = null;
            this.exitMenuItem.Click += new System.EventHandler(this.editMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.AccessibleDescription = null;
            this.editMenuItem.AccessibleName = null;
            resources.ApplyResources(this.editMenuItem, "editMenuItem");
            this.editMenuItem.BackgroundImage = null;
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
            this.editMenuItem.ShortcutKeyDisplayString = null;
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.AccessibleDescription = null;
            this.cutMenuItem.AccessibleName = null;
            resources.ApplyResources(this.cutMenuItem, "cutMenuItem");
            this.cutMenuItem.BackgroundImage = null;
            this.cutMenuItem.Image = global::XingSub.Properties.Resources.Cut;
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.ShortcutKeyDisplayString = null;
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.AccessibleDescription = null;
            this.copyMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyMenuItem, "copyMenuItem");
            this.copyMenuItem.BackgroundImage = null;
            this.copyMenuItem.Image = global::XingSub.Properties.Resources.Copy;
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeyDisplayString = null;
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.AccessibleDescription = null;
            this.pasteMenuItem.AccessibleName = null;
            resources.ApplyResources(this.pasteMenuItem, "pasteMenuItem");
            this.pasteMenuItem.BackgroundImage = null;
            this.pasteMenuItem.Image = global::XingSub.Properties.Resources.Paste;
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.ShortcutKeyDisplayString = null;
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.AccessibleDescription = null;
            this.deleteMenuItem.AccessibleName = null;
            resources.ApplyResources(this.deleteMenuItem, "deleteMenuItem");
            this.deleteMenuItem.BackgroundImage = null;
            this.deleteMenuItem.Image = global::XingSub.Properties.Resources.Delete;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.ShortcutKeyDisplayString = null;
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AccessibleDescription = null;
            this.toolStripSeparator5.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.AccessibleDescription = null;
            this.selectAllMenuItem.AccessibleName = null;
            resources.ApplyResources(this.selectAllMenuItem, "selectAllMenuItem");
            this.selectAllMenuItem.BackgroundImage = null;
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.ShortcutKeyDisplayString = null;
            this.selectAllMenuItem.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AccessibleDescription = null;
            this.toolStripSeparator6.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // insertNewLineMenuItem
            // 
            this.insertNewLineMenuItem.AccessibleDescription = null;
            this.insertNewLineMenuItem.AccessibleName = null;
            resources.ApplyResources(this.insertNewLineMenuItem, "insertNewLineMenuItem");
            this.insertNewLineMenuItem.BackgroundImage = null;
            this.insertNewLineMenuItem.Name = "insertNewLineMenuItem";
            this.insertNewLineMenuItem.ShortcutKeyDisplayString = null;
            this.insertNewLineMenuItem.Click += new System.EventHandler(this.insertNewLineMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.AccessibleDescription = null;
            this.optionsMenuItem.AccessibleName = null;
            resources.ApplyResources(this.optionsMenuItem, "optionsMenuItem");
            this.optionsMenuItem.BackgroundImage = null;
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetMenuItem,
            this.captureTargetMenuItem,
            this.timingModeMenuItem,
            this.autocloseTimeWindowToolStripMenuItem,
            this.toolStripSeparator2,
            this.paramsToolStripMenuItem,
            this.stylesToolStripMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.ShortcutKeyDisplayString = null;
            // 
            // offsetMenuItem
            // 
            this.offsetMenuItem.AccessibleDescription = null;
            this.offsetMenuItem.AccessibleName = null;
            resources.ApplyResources(this.offsetMenuItem, "offsetMenuItem");
            this.offsetMenuItem.BackgroundImage = null;
            this.offsetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offsetOneMenuItem,
            this.offsetTwoMenuItem,
            this.offsetBySpaceMenuItem});
            this.offsetMenuItem.Name = "offsetMenuItem";
            this.offsetMenuItem.ShortcutKeyDisplayString = null;
            // 
            // offsetOneMenuItem
            // 
            this.offsetOneMenuItem.AccessibleDescription = null;
            this.offsetOneMenuItem.AccessibleName = null;
            resources.ApplyResources(this.offsetOneMenuItem, "offsetOneMenuItem");
            this.offsetOneMenuItem.BackgroundImage = null;
            this.offsetOneMenuItem.Name = "offsetOneMenuItem";
            this.offsetOneMenuItem.ShortcutKeyDisplayString = null;
            this.offsetOneMenuItem.Click += new System.EventHandler(this.offsetOneMenuItem_Click);
            // 
            // offsetTwoMenuItem
            // 
            this.offsetTwoMenuItem.AccessibleDescription = null;
            this.offsetTwoMenuItem.AccessibleName = null;
            resources.ApplyResources(this.offsetTwoMenuItem, "offsetTwoMenuItem");
            this.offsetTwoMenuItem.BackgroundImage = null;
            this.offsetTwoMenuItem.Name = "offsetTwoMenuItem";
            this.offsetTwoMenuItem.ShortcutKeyDisplayString = null;
            this.offsetTwoMenuItem.Click += new System.EventHandler(this.offsetTwoMenuItem_Click);
            // 
            // offsetBySpaceMenuItem
            // 
            this.offsetBySpaceMenuItem.AccessibleDescription = null;
            this.offsetBySpaceMenuItem.AccessibleName = null;
            resources.ApplyResources(this.offsetBySpaceMenuItem, "offsetBySpaceMenuItem");
            this.offsetBySpaceMenuItem.BackgroundImage = null;
            this.offsetBySpaceMenuItem.Checked = true;
            this.offsetBySpaceMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.offsetBySpaceMenuItem.Name = "offsetBySpaceMenuItem";
            this.offsetBySpaceMenuItem.ShortcutKeyDisplayString = null;
            this.offsetBySpaceMenuItem.Click += new System.EventHandler(this.offsetBySpaceMenuItem_Click);
            // 
            // captureTargetMenuItem
            // 
            this.captureTargetMenuItem.AccessibleDescription = null;
            this.captureTargetMenuItem.AccessibleName = null;
            resources.ApplyResources(this.captureTargetMenuItem, "captureTargetMenuItem");
            this.captureTargetMenuItem.BackgroundImage = null;
            this.captureTargetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NWEToolStripMenuItem,
            this.MPCToolStripMenuItem});
            this.captureTargetMenuItem.Name = "captureTargetMenuItem";
            this.captureTargetMenuItem.ShortcutKeyDisplayString = null;
            // 
            // NWEToolStripMenuItem
            // 
            this.NWEToolStripMenuItem.AccessibleDescription = null;
            this.NWEToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.NWEToolStripMenuItem, "NWEToolStripMenuItem");
            this.NWEToolStripMenuItem.BackgroundImage = null;
            this.NWEToolStripMenuItem.Checked = true;
            this.NWEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NWEToolStripMenuItem.Name = "NWEToolStripMenuItem";
            this.NWEToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.NWEToolStripMenuItem.Click += new System.EventHandler(this.NWEToolStripMenuItem_Click);
            // 
            // MPCToolStripMenuItem
            // 
            this.MPCToolStripMenuItem.AccessibleDescription = null;
            this.MPCToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.MPCToolStripMenuItem, "MPCToolStripMenuItem");
            this.MPCToolStripMenuItem.BackgroundImage = null;
            this.MPCToolStripMenuItem.Name = "MPCToolStripMenuItem";
            this.MPCToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.MPCToolStripMenuItem.Click += new System.EventHandler(this.MPCToolStripMenuItem_Click);
            // 
            // timingModeMenuItem
            // 
            this.timingModeMenuItem.AccessibleDescription = null;
            this.timingModeMenuItem.AccessibleName = null;
            resources.ApplyResources(this.timingModeMenuItem, "timingModeMenuItem");
            this.timingModeMenuItem.BackgroundImage = null;
            this.timingModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalModeMenuItem,
            this.effectsModeMenuItem});
            this.timingModeMenuItem.Name = "timingModeMenuItem";
            this.timingModeMenuItem.ShortcutKeyDisplayString = null;
            // 
            // normalModeMenuItem
            // 
            this.normalModeMenuItem.AccessibleDescription = null;
            this.normalModeMenuItem.AccessibleName = null;
            resources.ApplyResources(this.normalModeMenuItem, "normalModeMenuItem");
            this.normalModeMenuItem.BackgroundImage = null;
            this.normalModeMenuItem.Checked = true;
            this.normalModeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalModeMenuItem.Name = "normalModeMenuItem";
            this.normalModeMenuItem.ShortcutKeyDisplayString = null;
            this.normalModeMenuItem.Click += new System.EventHandler(this.normalModeMenuItem_Click);
            // 
            // effectsModeMenuItem
            // 
            this.effectsModeMenuItem.AccessibleDescription = null;
            this.effectsModeMenuItem.AccessibleName = null;
            resources.ApplyResources(this.effectsModeMenuItem, "effectsModeMenuItem");
            this.effectsModeMenuItem.BackgroundImage = null;
            this.effectsModeMenuItem.Name = "effectsModeMenuItem";
            this.effectsModeMenuItem.ShortcutKeyDisplayString = null;
            this.effectsModeMenuItem.Click += new System.EventHandler(this.effectsModeMenuItem_Click);
            // 
            // autocloseTimeWindowToolStripMenuItem
            // 
            this.autocloseTimeWindowToolStripMenuItem.AccessibleDescription = null;
            this.autocloseTimeWindowToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.autocloseTimeWindowToolStripMenuItem, "autocloseTimeWindowToolStripMenuItem");
            this.autocloseTimeWindowToolStripMenuItem.BackgroundImage = null;
            this.autocloseTimeWindowToolStripMenuItem.Checked = true;
            this.autocloseTimeWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autocloseTimeWindowToolStripMenuItem.Name = "autocloseTimeWindowToolStripMenuItem";
            this.autocloseTimeWindowToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.autocloseTimeWindowToolStripMenuItem.Click += new System.EventHandler(this.autocloseTimeWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // paramsToolStripMenuItem
            // 
            this.paramsToolStripMenuItem.AccessibleDescription = null;
            this.paramsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.paramsToolStripMenuItem, "paramsToolStripMenuItem");
            this.paramsToolStripMenuItem.BackgroundImage = null;
            this.paramsToolStripMenuItem.Name = "paramsToolStripMenuItem";
            this.paramsToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // stylesToolStripMenuItem
            // 
            this.stylesToolStripMenuItem.AccessibleDescription = null;
            this.stylesToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.stylesToolStripMenuItem, "stylesToolStripMenuItem");
            this.stylesToolStripMenuItem.BackgroundImage = null;
            this.stylesToolStripMenuItem.Name = "stylesToolStripMenuItem";
            this.stylesToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.stylesToolStripMenuItem.Click += new System.EventHandler(this.stylesToolStripMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.AccessibleDescription = null;
            this.helpMenuItem.AccessibleName = null;
            resources.ApplyResources(this.helpMenuItem, "helpMenuItem");
            this.helpMenuItem.BackgroundImage = null;
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.ShortcutKeyDisplayString = null;
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.AccessibleDescription = null;
            this.aboutMenuItem.AccessibleName = null;
            resources.ApplyResources(this.aboutMenuItem, "aboutMenuItem");
            this.aboutMenuItem.BackgroundImage = null;
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.ShortcutKeyDisplayString = null;
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleDescription = null;
            this.statusStrip1.AccessibleName = null;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = null;
            this.statusStrip1.Font = null;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleDescription = null;
            this.toolStripStatusLabel1.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.BackgroundImage = null;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleDescription = null;
            this.contextMenuStrip1.AccessibleName = null;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.BackgroundImage = null;
            this.contextMenuStrip1.Font = null;
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
            // 
            // contextCut
            // 
            this.contextCut.AccessibleDescription = null;
            this.contextCut.AccessibleName = null;
            resources.ApplyResources(this.contextCut, "contextCut");
            this.contextCut.BackgroundImage = null;
            this.contextCut.Image = global::XingSub.Properties.Resources.Cut;
            this.contextCut.Name = "contextCut";
            this.contextCut.ShortcutKeyDisplayString = null;
            this.contextCut.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.AccessibleDescription = null;
            this.contextCopy.AccessibleName = null;
            resources.ApplyResources(this.contextCopy, "contextCopy");
            this.contextCopy.BackgroundImage = null;
            this.contextCopy.Image = global::XingSub.Properties.Resources.Copy;
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.ShortcutKeyDisplayString = null;
            this.contextCopy.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // contextPaste
            // 
            this.contextPaste.AccessibleDescription = null;
            this.contextPaste.AccessibleName = null;
            resources.ApplyResources(this.contextPaste, "contextPaste");
            this.contextPaste.BackgroundImage = null;
            this.contextPaste.Image = global::XingSub.Properties.Resources.Paste;
            this.contextPaste.Name = "contextPaste";
            this.contextPaste.ShortcutKeyDisplayString = null;
            this.contextPaste.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.AccessibleDescription = null;
            this.contextDelete.AccessibleName = null;
            resources.ApplyResources(this.contextDelete, "contextDelete");
            this.contextDelete.BackgroundImage = null;
            this.contextDelete.Image = global::XingSub.Properties.Resources.Delete;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.ShortcutKeyDisplayString = null;
            this.contextDelete.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.AccessibleDescription = null;
            this.toolStripSeparator7.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // contextSelectAll
            // 
            this.contextSelectAll.AccessibleDescription = null;
            this.contextSelectAll.AccessibleName = null;
            resources.ApplyResources(this.contextSelectAll, "contextSelectAll");
            this.contextSelectAll.BackgroundImage = null;
            this.contextSelectAll.Name = "contextSelectAll";
            this.contextSelectAll.ShortcutKeyDisplayString = null;
            this.contextSelectAll.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.AccessibleDescription = null;
            this.toolStripSeparator9.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // contextInsertNewline
            // 
            this.contextInsertNewline.AccessibleDescription = null;
            this.contextInsertNewline.AccessibleName = null;
            resources.ApplyResources(this.contextInsertNewline, "contextInsertNewline");
            this.contextInsertNewline.BackgroundImage = null;
            this.contextInsertNewline.Name = "contextInsertNewline";
            this.contextInsertNewline.ShortcutKeyDisplayString = null;
            this.contextInsertNewline.Click += new System.EventHandler(this.insertNewLineMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
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
            this.ScriptTextBox.AccessibleDescription = null;
            this.ScriptTextBox.AccessibleName = null;
            this.ScriptTextBox.AllowDrop = true;
            resources.ApplyResources(this.ScriptTextBox, "ScriptTextBox");
            this.ScriptTextBox.BackgroundImage = null;
            this.ScriptTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.ScriptTextBox.Font = null;
            this.ScriptTextBox.HideSelection = false;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.TextChanged += new System.EventHandler(this.ScriptTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.ScriptTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = null;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem stylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem resyncToolToolStripMenuItem;
    }
}

