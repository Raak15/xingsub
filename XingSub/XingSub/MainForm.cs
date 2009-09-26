using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XingSub
{
    public partial class MainForm : Form
    {
        #region 声明 Win32 API
        //FindWindow
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //EnumChildWindows
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        //GetClassName
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        //SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, StringBuilder lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private const UInt32 WM_GETTEXT = 0x000D;
        private const UInt32 WM_CLOSE = 0x0010;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        private static EnumWindowsProc callbackEnumNWEChild = new EnumWindowsProc(WaveEditorProc);
        private static EnumWindowsProc callbackEnumMPCChild = new EnumWindowsProc(MediaPlayerProc);
        #endregion

        private static int getCount = 0;
        private static string timeString = "";
        private static string lastString = "";

        private bool isSaved = true;
        private string fileName = "";

        private List<Type> pluginsList;
        private List<Type> readersList;

        private List<int> pluginsId;

        public AdvancedSubStationAlpha subtitles;

        private aboutForm aboutForm = new aboutForm();
        private paramsForm paramsForm = new paramsForm();
        private SubInfoForm subInfoForm = new SubInfoForm();

        private string configFile = Path.Combine(Environment.CurrentDirectory, "config.dat");
        private XSConfig appConfig;

        public MainForm()
        {
            InitializeComponent();
        }

        private static bool WaveEditorProc(IntPtr hWnd, IntPtr lParam)
        {
            if (getCount < 4)
            {
                StringBuilder className = new StringBuilder(200);
                GetClassName(hWnd, className, 200);
                if (className.ToString() == "Edit")
                {
                    StringBuilder buffer = new StringBuilder(255);
                    SendMessage(hWnd, WM_GETTEXT, new IntPtr(255), buffer);
                    if (buffer.Length == 0)
                    {
                        timeString = "";
                        getCount = 0;
                    }
                    else
                    {
                        switch (getCount)
                        {
                            case 0: //时
                                timeString += buffer.ToString();
                                getCount++;
                                break;
                            case 1: //分
                                if (buffer.Length == 1)
                                {
                                    timeString += "0";
                                }
                                timeString += buffer.ToString();
                                getCount++;
                                break;
                            case 2: //秒
                                if (buffer.Length == 1)
                                {
                                    timeString += "0";
                                }
                                timeString += buffer.ToString();
                                getCount++;
                                break;
                            case 3: //秒后两位小数
                                if (buffer.Length == 2)
                                {
                                    timeString += "0";
                                }
                                timeString += Math.Round(float.Parse(buffer.ToString()) / 10, 0).ToString();
                                getCount++;
                                break;
                        }
                    }
                }
            }
            return true;
        }
            
        private static bool MediaPlayerProc(IntPtr hWnd, IntPtr lParam)
        {
            if (getCount == 0)
            {
                StringBuilder className = new StringBuilder(200);
                GetClassName(hWnd, className, 200);
                if (className.ToString() == "Edit")
                {
                    StringBuilder buffer = new StringBuilder(255);
                    SendMessage(hWnd, WM_GETTEXT, new IntPtr(255), buffer);

                    Regex reg = new Regex(@"(\d{2}):(\d{2}):(\d{2}).(\d{3})");

                    if (reg.IsMatch(buffer.ToString()))
                    {
                        Match matchTime = reg.Match(buffer.ToString());
                        string hours = matchTime.Groups[1].Value.Substring(1);
                        string minutes = matchTime.Groups[2].Value;
                        string seconds = matchTime.Groups[3].Value;
                        string ms = Math.Round(float.Parse(matchTime.Groups[4].Value) / 10, 0).ToString();
                        timeString = hours + minutes + seconds + ms;
                        getCount++;
                    }
                }
            }
            return true;
        }

        private void timerCapture_Tick(object sender, EventArgs e)
        {
            switch (appConfig.TimeSource)
            {
                case TimingApp.NeroWaveEditor:
                    captureWaveEditor();
                    break;
                case TimingApp.MediaPlayerClassic:
                    captureMediaPlayer();
                    break;
            }
            
        }

        private void captureWaveEditor()
        {
            IntPtr h = FindWindow(null, "手动定义标记");
            if (getCount == 0)   //未取则继续
            {
                if (h.ToInt32() > 0)
                {
                    EnumChildWindows(h, callbackEnumNWEChild, this.Handle);
                }
            }
            else if (getCount == 4) //取够4次，插入时间
            {
                if (appConfig.AutoClose)
                {
                    PostMessage(h, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
                insertTime();
            }
            else
            {
                getCount = 0;
                timeString = "";
            }
        }

        private void captureMediaPlayer()
        {
            IntPtr h = FindWindow(null, "转到...");
            if (getCount == 0)   //未取够1次则继续
            {
                if (h.ToInt32() > 0)
                {
                    EnumChildWindows(h, callbackEnumMPCChild, this.Handle);
                }
            }
            else if (getCount == 1) //取够1次，插入时间
            {
                insertTime();
            }
            else
            {
                getCount = 0;
                timeString = "";
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            if (askToSave())
            {
                ScriptTextBox.Text = "";
                fileName = "";
                isSaved = true;
                if (appConfig.EffectMode)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, Localizable.NewFile);
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, Localizable.NewFile);
                }
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (askToSave())
            {
                openFileDialog1.Reset();
                openFileDialog1.Filter = Localizable.OpenFileType;
                openFileDialog1.Title = Localizable.OpenTitle;
                openFileDialog1.ShowDialog();

                if (openFileDialog1.FileName.Length == 0) return;

                fileName = openFileDialog1.FileName;

                StreamReader fileReader = File.OpenText(fileName);
                string fileContent = fileReader.ReadToEnd();
                fileReader.Close();

                subtitles = new AdvancedSubStationAlpha();

                System.Diagnostics.Debug.WriteLine(isSaved);
                switch (Path.GetExtension(fileName))
                {
                    case ".xss":
                        subtitles.LoadXss(fileContent);
                        ScriptTextBox.Text = fileContent;
                        changeEffectsMode(false, true);
                        this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
                        break;
                    case ".ass":
                        subtitles.LoadAss(fileContent);
                        ScriptTextBox.Text = subtitles.ToXingSub();
                        changeEffectsMode(false, true);
                        this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
                        break;
                    case ".xse":
                        ScriptTextBox.Text = fileContent;
                        changeEffectsMode(true, true);
                        this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName);
                        break;
                    default:
                        ScriptTextBox.Text = fileContent;
                        changeEffectsMode(false, true);
                        this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
                        break;
                }

                isSaved = true;
            }
        }

        private void ScriptTextBox_TextChanged(object sender, EventArgs e)
        {
            isSaved = false;
            if (fileName.Length == 0)
            {
                if (appConfig.EffectMode)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, Localizable.NewFile + "*");
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, Localizable.NewFile + "*");
                }
            }
            else
            {
                if (appConfig.EffectMode)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName + "*");
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName + "*");
                }
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!askToSave())
            {
                e.Cancel = true;
            }
            else
            {
                FileStream fs = new FileStream(configFile, FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(XSConfig));
                xs.Serialize(fs, appConfig);
                fs.Close();
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            if (!aboutForm.Created)
            {
                aboutForm = new aboutForm();
            }
            string text = "";
            foreach (Type plug in pluginsList)
            {
                text += Path.GetFileName(plug.Assembly.Location) + "\r\n";
            }
            aboutForm.versionLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            aboutForm.pluginsTextBox.Text = text;
            aboutForm.Show();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Reset();
            if (appConfig.EffectMode)
            {
                saveFileDialog1.Filter = Localizable.SaveAsFileType;
                saveFileDialog1.DefaultExt = "xse";
                saveFileDialog1.Title = Localizable.SaveEffectsTitle;
            }
            else
            {
                saveFileDialog1.Filter = Localizable.SaveAsFileType;
                saveFileDialog1.DefaultExt = "xss";
                saveFileDialog1.Title = Localizable.SaveSubtitlesTitle;
            }
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Length == 0) return;
            fileName = saveFileDialog1.FileName;
            StreamWriter fileWriter = File.CreateText(fileName);
            fileWriter.Write(ScriptTextBox.Text);
            fileWriter.Flush();
            fileWriter.Close();
            isSaved = true;

            appConfig.EffectMode = (Path.GetExtension(fileName) == ".xse");
            if (appConfig.EffectMode)
            {
                this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName);
                normalModeMenuItem.Checked = false;
                effectsModeMenuItem.Checked = true;
                offsetMenuItem.Enabled = true;
            }
            else
            {
                this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
                normalModeMenuItem.Checked = true;
                effectsModeMenuItem.Checked = false;
                offsetMenuItem.Enabled = false;
            }
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            if (ScriptTextBox.SelectionLength > 0)
            {
                ScriptTextBox.Cut();
            }
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (ScriptTextBox.SelectionLength > 0)
            {
                ScriptTextBox.Copy();
            }
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                ScriptTextBox.Paste();
            }
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            ScriptTextBox.SelectAll();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            ScriptTextBox.SelectedText = "";
        }

        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            if (!isSaved && fileName.Length > 0)
            {
                DateTime autoSaveTime = DateTime.Now;
                string autoSavePath = fileName + ".AutoSaved";
                string autoSaveFile = Path.Combine(autoSavePath, Path.GetFileNameWithoutExtension(fileName) + "." + autoSaveTime.Year + autoSaveTime.Month + autoSaveTime.Day + autoSaveTime.Hour + autoSaveTime.Minute + autoSaveTime.Second + Path.GetExtension(fileName));
                if (!Directory.Exists(autoSavePath))
                {
                    Directory.CreateDirectory(autoSavePath);
                }
                StreamWriter fileWriter = File.CreateText(autoSaveFile);
                fileWriter.Write(ScriptTextBox.Text);
                fileWriter.Flush();
                fileWriter.Close();
                toolStripStatusLabel1.Text = String.Format(Localizable.AutoSaved, autoSaveTime.ToString());
            }
        }

        private void insertNewLineMenuItem_Click(object sender, EventArgs e)
        {
            int nextNewline = ScriptTextBox.Text.Substring(ScriptTextBox.SelectionStart).IndexOf(Environment.NewLine);
            if (nextNewline == -1)
            {
                ScriptTextBox.Text += Environment.NewLine;
                ScriptTextBox.SelectionStart = ScriptTextBox.Text.Length;
            }
            else
            {
                ScriptTextBox.SelectionStart += nextNewline;
                ScriptTextBox.SelectedText = Environment.NewLine;
            }
        }

        private void normalModeMenuItem_Click(object sender, EventArgs e)
        {
            changeEffectsMode(false);
            saveToFile();
        }

        private void effectsModeMenuItem_Click(object sender, EventArgs e)
        {
            changeEffectsMode(true);
            saveToFile();
        }

        private void offsetOneMenuItem_Click(object sender, EventArgs e)
        {
            offsetOneMenuItem.Checked = true;
            offsetTwoMenuItem.Checked = false;
            offsetBySpaceMenuItem.Checked = false;
            appConfig.TimeOffset = 1;
        }

        private void offsetTwoMenuItem_Click(object sender, EventArgs e)
        {
            offsetOneMenuItem.Checked = false;
            offsetTwoMenuItem.Checked = true;
            offsetBySpaceMenuItem.Checked = false;
            appConfig.TimeOffset = 2;
        }

        private void offsetBySpaceMenuItem_Click(object sender, EventArgs e)
        {
            offsetOneMenuItem.Checked = false;
            offsetTwoMenuItem.Checked = false;
            offsetBySpaceMenuItem.Checked = true;
            appConfig.TimeOffset = 0;
        }

        private void NWEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NWEToolStripMenuItem.Checked = true;
            MPCToolStripMenuItem.Checked = false;
            appConfig.TimeSource = TimingApp.NeroWaveEditor;
        }

        private void MPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NWEToolStripMenuItem.Checked = false;
            MPCToolStripMenuItem.Checked = true;
            appConfig.TimeSource = TimingApp.MediaPlayerClassic;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 读取配置文件
            if (File.Exists(configFile))
            {
                FileStream fs = new FileStream(configFile, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(XSConfig));
                try
                {
                    appConfig = (XSConfig)xs.Deserialize(fs);
                }
                catch (InvalidOperationException)
                {
                    appConfig = new XSConfig();
                    MessageBox.Show(Localizable.ConfigWarningMessage, Localizable.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                fs.Close();
            }
            else
            {
                appConfig = new XSConfig();
            }

            // 设置窗口大小和位置
            if (appConfig.DesktopBounds.Equals(new Rectangle(-1, -1, -1, -1)))
            {
                appConfig.DesktopBounds = this.DesktopBounds;
            }
            else
            {
                this.DesktopBounds = appConfig.DesktopBounds;
            }

            // 应用自动关闭设置
            autocloseTimeWindowToolStripMenuItem.Checked = appConfig.AutoClose;

            // 应用特效模式设置
            offsetMenuItem.Enabled = appConfig.EffectMode;
            normalModeMenuItem.Checked = !appConfig.EffectMode;
            effectsModeMenuItem.Checked = appConfig.EffectMode;

            if (appConfig.EffectMode)
            {
                this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, Localizable.NewFile);
            }
            else
            {
                this.Text = String.Format(Localizable.Title, Localizable.NormalMode, Localizable.NewFile);
            }

            // 应用偏移设置
            offsetBySpaceMenuItem.Checked = (appConfig.TimeOffset == 0);
            offsetOneMenuItem.Checked = (appConfig.TimeOffset == 1);
            offsetTwoMenuItem.Checked = (appConfig.TimeOffset == 2);

            // 应用捕获目标设置
            NWEToolStripMenuItem.Checked = (appConfig.TimeSource == TimingApp.NeroWaveEditor);
            MPCToolStripMenuItem.Checked = (appConfig.TimeSource == TimingApp.MediaPlayerClassic);

            //scanPlugin(); //扫描插件
            //scanReader(); //扫描导入
        }

        private void pluginParams_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            string location = pluginsList[int.Parse(item.Name)].Assembly.Location;

            if (!paramsForm.Created)
            {
                paramsForm = new paramsForm();
            }
            paramsForm.paramsFile = Path.Combine(Path.GetDirectoryName(location), Path.GetFileNameWithoutExtension(location) + ".header");
            paramsForm.Show();
        }

        private void importMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            pluginsId = new List<int>();
            string filter = "";
            for (int i = 0; i < pluginsList.Count; i++)
            {
                IPlugin obj = (IPlugin)Activator.CreateInstance(pluginsList[i]);
                if (obj.IsEffects() == appConfig.EffectMode)
                {
                    pluginsId.Add(i);
                    filter += String.Format("{0}|*.{1}|", obj.Descriptions(), obj.Extension());
                }
            }
            filter = filter.Substring(0, filter.Length - 1);

            saveFileDialog1.Reset();
            saveFileDialog1.Filter = filter;
            saveFileDialog1.Title = Localizable.ExportTitle;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Length == 0) return;

            int index = pluginsId[saveFileDialog1.FilterIndex - 1];
            IPlugin plugin = (IPlugin)Activator.CreateInstance(pluginsList[index]);

            if (plugin.Convert(ScriptTextBox.Text, saveFileDialog1.FileName) == 0)
            {
                MessageBox.Show(Localizable.ExportSussessMessage, Localizable.ExportTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void reader_Click(object sender, EventArgs e)
        {
            ToolStripItem menu = (ToolStripItem)sender;
            Type type = readersList[importMenuItem.DropDownItems.IndexOf(menu)];
            IReader obj = (IReader)Activator.CreateInstance(type);

            string pathToSaveHeader = "";

            if (obj.HasHeader())
            {
                DialogResult msg = MessageBox.Show("The format of this file has headers. If you import it you will lose the header, but you have chance to save it as a header file so that you can include it in exporting.\nDo you want to save the header?", "Save Header", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (msg == DialogResult.Yes)
                {
                    saveFileDialog1.Reset();
                    saveFileDialog1.Filter = "XingSub Header File(*.header)|*.header|All Files(*.*)|*.*";
                    saveFileDialog1.DefaultExt = "header";
                    saveFileDialog1.Title = "Save Header";
                    saveFileDialog1.ShowDialog();
                    pathToSaveHeader = saveFileDialog1.FileName;
                }
            }

            openFileDialog1.Reset();
            openFileDialog1.Filter = String.Format(Localizable.ExportFileType, obj.Descriptions(), obj.Extension());
            saveFileDialog1.DefaultExt = obj.Extension();
            saveFileDialog1.Title = "Save Header";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Length == 0) return;
        }

        private bool saveToFile()
        {
            if (fileName.Length == 0 || (Path.GetExtension(fileName) != ".xse" && Path.GetExtension(fileName) != ".xss" && Path.GetExtension(fileName) != ".ass"))
            {
                saveFileDialog1.Reset();
                if (appConfig.EffectMode)
                {
                    saveFileDialog1.Filter = Localizable.SaveEffectsFileType;
                    saveFileDialog1.DefaultExt = "xse";
                    saveFileDialog1.Title = Localizable.SaveEffectsTitle;
                }
                else
                {
                    saveFileDialog1.Filter = Localizable.SaveSubtitlesFileType;
                    saveFileDialog1.DefaultExt = "xss";
                    saveFileDialog1.Title = Localizable.SaveSubtitlesTitle;
                }
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName.Length == 0) return false;
                fileName = saveFileDialog1.FileName;
            }

            StreamWriter fileWriter = File.CreateText(fileName);

            if (appConfig.EffectMode)
            {
                fileWriter.Write(ScriptTextBox.Text);
                this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName);
            }
            else
            {
                subtitles.LoadXss(ScriptTextBox.Text);

                switch (Path.GetExtension(fileName))
                {
                    case ".xss":
                        fileWriter.Write(ScriptTextBox.Text);
                        break;
                    case ".ass":
                        fileWriter.Write(subtitles.ToString());
                        break;
                }

                this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
            }

            fileWriter.Flush();
            fileWriter.Close();
            isSaved = true;

            string autoSavePath = fileName + ".AutoSaved";
            if (Directory.Exists(autoSavePath))
            {
                Directory.Delete(autoSavePath, true);
            }

            return true;
        }

        private bool askToSave()
        {
            if (isSaved)
            {
                return true;
            }
            else
            {
                DialogResult result = MessageBox.Show(Localizable.AskToSaveMessage, Localizable.AskToSaveTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        return saveToFile();
                    case DialogResult.No:
                        return true;
                    default:
                        return false;
                }
            }
        }

        private void insertTime()
        {
            if (timeString.Length == 7 && timeString != lastString && timeString != "0000000")
            {
                if (appConfig.EffectMode) //特效模式
                {
                    //插入时间
                    ScriptTextBox.SelectedText = "+" + timeString;

                    //定位到下一音节
                    int endOfLine = ScriptTextBox.Text.Substring(ScriptTextBox.SelectionStart).IndexOf(Environment.NewLine);
                    if (endOfLine == -1)
                    {
                        endOfLine = ScriptTextBox.Text.Length - ScriptTextBox.SelectionStart;
                    }
                    int nextWord;   //寻找下一音节
                    if (appConfig.TimeOffset == 0)    //自动偏移
                    {
                        nextWord = ScriptTextBox.Text.Substring(ScriptTextBox.SelectionStart).IndexOf(" ") + 1;   //下一空格
                    }
                    else
                    {
                        nextWord = appConfig.TimeOffset;
                    }

                    if (nextWord > endOfLine || nextWord == 0)   //如果超过行尾
                    {
                        ScriptTextBox.SelectionStart += endOfLine;
                    }
                    else
                    {
                        ScriptTextBox.SelectionStart += nextWord;
                    }

                    if (endOfLine == 0)   //如果已到达行尾
                    {
                        ScriptTextBox.SelectionStart += 2;   //定位到下一行
                    }
                }
                else
                {
                    //定位到行首
                    int lastNewline = ScriptTextBox.Text.Substring(0, ScriptTextBox.SelectionStart).LastIndexOf(Environment.NewLine);
                    if (lastNewline == -1)
                    {
                        ScriptTextBox.SelectionStart = 0;
                    }
                    else
                    {
                        ScriptTextBox.SelectionStart = lastNewline + 2;
                    }

                    //插入时间
                    ScriptTextBox.SelectedText = timeString;

                    //定位到下一行首
                    int nextNewline = ScriptTextBox.Text.Substring(ScriptTextBox.SelectionStart).IndexOf(Environment.NewLine);
                    if (nextNewline == -1)
                    {
                        ScriptTextBox.Text += Environment.NewLine;
                        ScriptTextBox.SelectionStart = ScriptTextBox.Text.Length;
                    }
                    else
                    {
                        ScriptTextBox.SelectionStart += (nextNewline + 2);
                    }
                }

                ScriptTextBox.ScrollToCaret();

                toolStripStatusLabel1.Text = String.Format(Localizable.InsertedTimeStamp, stringToStamp(timeString));
            }
            getCount = 0;
            lastString = timeString;
            timeString = "";
        }

        private void changeEffectsMode(bool mode)
        {
            appConfig.EffectMode = mode;
            offsetMenuItem.Enabled = mode;
            normalModeMenuItem.Checked = !mode;
            effectsModeMenuItem.Checked = mode;

            if (mode)
            {
                if (Path.GetExtension(fileName) != ".xse")  //如果扩展名不符，要求另存。
                {
                    fileName = "";
                    isSaved = false;
                }

                if (fileName.Length == 0)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, Localizable.NewFile + "*");
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName + "*");
                }
            }
            else
            {
                if (Path.GetExtension(fileName) != ".xss" && Path.GetExtension(fileName) != ".ass")  //如果扩展名不符，要求另存。
                {
                    fileName = "";
                    isSaved = false;
                }

                if (fileName.Length == 0)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, Localizable.NewFile + "*");
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName + "*");
                }
            }
        }

        private void changeEffectsMode(bool mode, bool open)
        {
            if (open)
            {
                appConfig.EffectMode = mode;
                offsetMenuItem.Enabled = mode;
                normalModeMenuItem.Checked = !mode;
                effectsModeMenuItem.Checked = mode;

                if (mode)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName);
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
                }
            }
        }

        private void scanPlugin()
        {
            string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] pathstr = Directory.GetFiles(location, "XSPlugin.*.*.dll");
            pluginsList = new List<Type>();

            foreach (string p in pathstr)
            {
                Assembly ase = Assembly.LoadFrom(p);
                if (ase.GetName().Version.Major == Assembly.GetEntryAssembly().GetName().Version.Major)
                {
                    Type[] types = ase.GetExportedTypes();
                    for (int i = 0; i < types.Length; i++)
                    {
                        if (types[i].IsClass && typeof(IPlugin).IsAssignableFrom(types[i]))
                        {
                            pluginsList.Add(types[i]);

                            IPlugin obj = (IPlugin)Activator.CreateInstance(types[i]);
                            //ToolStripItem item = exportMenuItem.DropDownItems.Add(obj.Descriptions());
                            //item.Click += new EventHandler(plugin_Click);
                            //item.Visible = (obj.IsEffects() == appConfig.EffectMode);

                            string pluginFile = types[i].Assembly.Location;
                            string config = Path.Combine(Path.GetDirectoryName(pluginFile), Path.GetFileNameWithoutExtension(pluginFile) + ".header");
                            if (File.Exists(config))
                            {
                                ToolStripItem pluginParams = paramsToolStripMenuItem.DropDownItems.Add(obj.Descriptions());
                                pluginParams.Name = pluginsList.IndexOf(types[i]).ToString();
                                pluginParams.Click += new EventHandler(pluginParams_Click);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(Localizable.FailedToLoadPluginMessage, Assembly.GetEntryAssembly().GetName().Version.ToString()), String.Format(Localizable.FailedToLoadPluginTitle, Path.GetFileName(ase.Location)), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void scanReader()
        {
            string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] pathstr = Directory.GetFiles(location, "XSReader.*.*.dll");
            readersList = new List<Type>();

            foreach (string p in pathstr)
            {
                Assembly ase = Assembly.LoadFrom(p);
                if (ase.GetName().Version.Major == Assembly.GetEntryAssembly().GetName().Version.Major)
                {
                    Type[] types = ase.GetExportedTypes();
                    for (int i = 0; i < types.Length; i++)
                    {
                        if (types[i].IsClass && typeof(IReader).IsAssignableFrom(types[i]))
                        {
                            readersList.Add(types[i]);

                            IReader obj = (IReader)Activator.CreateInstance(types[i]);
                            ToolStripItem item = importMenuItem.DropDownItems.Add(obj.Descriptions());
                            item.Click += new EventHandler(reader_Click);
                            item.Visible = (obj.IsEffects() == appConfig.EffectMode);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(Localizable.FailedToLoadPluginMessage, Assembly.GetEntryAssembly().GetName().Version.ToString()), String.Format(Localizable.FailedToLoadPluginTitle, Path.GetFileName(ase.Location)), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private string msecondsToString(int mseconds)
        {
            int left = mseconds;

            int ms = left % 100;
            left = (left - ms) / 100;

            int seconds = left % 60;
            left = (left - seconds) / 60;

            int minutes = left % 60;
            left = (left - minutes) / 60;

            int hours = left;

            string result = "";
            result += hours.ToString();
            if (minutes < 10) result += "0";
            result += minutes.ToString();
            if (seconds < 10) result += "0";
            result += seconds.ToString();
            if (ms < 10) result += "0";
            result += ms.ToString();

            return result;
        }

        private int stringToMsecond(string time)
        {
            int hours = int.Parse(time.Substring(0, 1));
            int minutes = int.Parse(time.Substring(1, 2));
            int seconds = int.Parse(time.Substring(3, 2));
            int ms = int.Parse(time.Substring(5, 2));

            int result = ((hours * 60 + minutes) * 60 + seconds) * 100 + ms;

            return result;
        }

        private string stringToStamp(string time)
        {
            string hours = time.Substring(0, 1);
            string minutes = time.Substring(1, 2);
            string seconds = time.Substring(3, 2);
            string ms = time.Substring(5, 2);

            string result = hours + ":" + minutes + ":" + seconds + "." + ms;
            
            return result;
        }

        private void autocloseTimeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appConfig.AutoClose = !appConfig.AutoClose;
            autocloseTimeWindowToolStripMenuItem.Checked = appConfig.AutoClose;
        }

        private void PreferancesMenuItem_Click(object sender, EventArgs e)
        {
            if (!subInfoForm.Created)
            {
                subInfoForm = new SubInfoForm();
            }
            subInfoForm.Show();
        }
    }
}
