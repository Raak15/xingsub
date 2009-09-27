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

        public AdvancedSubStationAlpha subtitles;

        private aboutForm aboutForm = new aboutForm();
        private paramsForm paramsForm = new paramsForm();
        private SubInfoForm subInfoForm = new SubInfoForm();

        private string configFile = Path.Combine(Environment.CurrentDirectory, "config.dat");
        private XSConfig appConfig;

        private const int PluginVersion = 2;

        public MainForm()
        {
            InitializeComponent();
        }

        #region 菜单事件
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
                subtitles = new AdvancedSubStationAlpha();
                subtitles.Styles.Add(new SubStationStyle());
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

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            if (!aboutForm.Created)
            {
                aboutForm = new aboutForm();
            }
            string text = "";
            if (pluginsList.Count > 0)
            {
                foreach (Type plug in pluginsList)
                {
                    text += Path.GetFileName(plug.Assembly.Location) + "\r\n";
                }
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
        #endregion

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

            //初始化字幕对象
            subtitles = new AdvancedSubStationAlpha();
            subtitles.Styles.Add(new SubStationStyle());

            LoadXSPlugins();
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
            List<int> pluginsId = new List<int>();
            string filter = "";
            for (int i = 0; i < pluginsList.Count; i++)
            {
                IXSPlugin plug = (IXSPlugin)Activator.CreateInstance(pluginsList[i]);
                if (plug.GetPluginType() == 0)
                {
                    pluginsId.Add(i);
                    filter += String.Format("{0}|*{1}|", plug.GetFileType(), plug.GetFileExt());
                }
            }

            if (pluginsId.Count == 0)
            {
                MessageBox.Show(Localizable.NoPluginAvailable, Localizable.NoPluginAvailableTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            openFileDialog1.Reset();
            openFileDialog1.Filter = filter.Substring(0, filter.Length - 1);
            openFileDialog1.Title = Localizable.ImportTitle;
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName.Length == 0) return;

            int index = pluginsId[openFileDialog1.FilterIndex - 1];
            IXSPlugin plugin = (IXSPlugin)Activator.CreateInstance(pluginsList[index]);

            subtitles = plugin.ReadAsSubtitle(openFileDialog1.FileName);
            ScriptTextBox.Text = subtitles.ToXingSub();

            MessageBox.Show(Localizable.ImportSussessMessage, Localizable.ImportTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            List<int> pluginsId = new List<int>();
            string filter = "";
            for (int i = 0; i < pluginsList.Count; i++)
            {
                IXSPlugin plug = (IXSPlugin)Activator.CreateInstance(pluginsList[i]);
                if (appConfig.EffectMode)
                {
                    if (plug.GetPluginType() == 2)
                    {
                        pluginsId.Add(i);
                        filter += String.Format("{0}|*{1}|", plug.GetFileType(), plug.GetFileExt());
                    }
                }
                else
                {
                    if (plug.GetPluginType() == 1)
                    {
                        pluginsId.Add(i);
                        filter += String.Format("{0}|*{1}|", plug.GetFileType(), plug.GetFileExt());
                    }
                }
            }

            if (pluginsId.Count == 0)
            {
                MessageBox.Show(Localizable.NoPluginAvailable, Localizable.NoPluginAvailableTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            saveFileDialog1.Reset();
            saveFileDialog1.Filter = filter.Substring(0, filter.Length - 1);
            saveFileDialog1.Title = Localizable.ExportTitle;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName.Length == 0) return;

            int index = pluginsId[saveFileDialog1.FilterIndex - 1];
            IXSPlugin plugin = (IXSPlugin)Activator.CreateInstance(pluginsList[index]);

            int result = 0;
            if (appConfig.EffectMode)
            {
                result = plugin.SaveFromText(saveFileDialog1.FileName, ScriptTextBox.Text);
            }
            else
            {
                subtitles.LoadXss(ScriptTextBox.Text);  //更新字幕对象
                result = plugin.SaveFromSubtitle(saveFileDialog1.FileName, subtitles);
            }

            if (result == 0)
            {
                MessageBox.Show(Localizable.ExportSussessMessage, Localizable.ExportTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                toolStripStatusLabel1.Text = String.Format(Localizable.InsertedTimeStamp, subtitles.TimeToStamp(timeString));
            }
            getCount = 0;
            lastString = timeString;
            timeString = "";
        }

        private void changeEffectsMode(bool mode)
        {
            appConfig.EffectMode = mode;
            offsetMenuItem.Enabled = mode;
            stylesToolStripMenuItem.Enabled = !mode;
            importMenuItem.Enabled = !mode;
            normalModeMenuItem.Checked = !mode;
            effectsModeMenuItem.Checked = mode;

            subtitles = new AdvancedSubStationAlpha();  //重置字幕对象

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
            subtitles = new AdvancedSubStationAlpha();  //重置字幕对象

            if (open)
            {
                appConfig.EffectMode = mode;
                offsetMenuItem.Enabled = mode;
                stylesToolStripMenuItem.Enabled = !mode;
                importMenuItem.Enabled = !mode;
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

        private void LoadXSPlugins()
        {
            string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] pathstr = Directory.GetFiles(location, "XSPlugin.*.*.dll");
            pluginsList = new List<Type>();

            foreach (string p in pathstr)
            {
                Assembly ase = Assembly.LoadFrom(p);
                if (ase.GetName().Version.Major == PluginVersion)
                {
                    Type[] types = ase.GetExportedTypes();
                    for (int i = 0; i < types.Length; i++)
                    {
                        if (types[i].IsClass && typeof(IXSPlugin).IsAssignableFrom(types[i]))
                        {
                            pluginsList.Add(types[i]);

                            string config = Path.Combine(Path.GetDirectoryName(p), Path.GetFileNameWithoutExtension(p) + ".xml");
                            if (File.Exists(config))
                            {
                                IXSPlugin plug = (IXSPlugin)Activator.CreateInstance(types[i]);

                                ToolStripItem pluginParams = paramsToolStripMenuItem.DropDownItems.Add(plug.GetFileType());
                                pluginParams.Name = pluginsList.IndexOf(types[i]).ToString();
                                pluginParams.Click += new EventHandler(pluginParams_Click);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(Localizable.FailedToLoadPluginMessage, PluginVersion.ToString()), String.Format(Localizable.FailedToLoadPluginTitle, Path.GetFileName(ase.Location)), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void autocloseTimeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appConfig.AutoClose = !appConfig.AutoClose;
            autocloseTimeWindowToolStripMenuItem.Checked = appConfig.AutoClose;
        }

        private void stylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!subInfoForm.Created)
            {
                subInfoForm = new SubInfoForm();
            }

            StringBuilder _stylesText = new StringBuilder(255);
            _stylesText.AppendLine("Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding");
            foreach (SubStationStyle _style in subtitles.Styles)
            {
                _stylesText.AppendLine(_style.ToString());
            }

            subInfoForm.stylesText.Text = _stylesText.ToString();
            subInfoForm.resWidth.Text = subtitles.ScriptInfo.PlayResX.ToString();
            subInfoForm.resHeight.Text = subtitles.ScriptInfo.PlayRexY.ToString();
            subInfoForm.OKButton.Click += new EventHandler(OKButton_Click);

            subInfoForm.Show();
        }

        void OKButton_Click(object sender, EventArgs e)
        {
            List<SubStationStyle> _styles = new List<SubStationStyle>();
            string[] lines =  subInfoForm.stylesText.Text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool isStyle = false;

            foreach (string s in lines)
            {
                string line = s.Trim();
                if (line.Replace(" ", "") == "Format:Name,Fontname,Fontsize,PrimaryColour,SecondaryColour,OutlineColour,BackColour,Bold,Italic,Underline,StrikeOut,ScaleX,ScaleY,Spacing,Angle,BorderStyle,Outline,Shadow,Alignment,MarginL,MarginR,MarginV,Encoding")
                {
                    isStyle = true;
                }

                if (isStyle)
                {
                    if (line.Length > 6)
                    {
                        if (line.Substring(0, 6) == "Style:")
                        {
                            SubStationStyle _style = new SubStationStyle(line);
                            _styles.Add(_style);
                        }
                    }
                }
            }

            if (!isStyle || _styles.Count == 0)
            {
                MessageBox.Show(Localizable.InvaildStyles, Localizable.InvaildStylesTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            subtitles.Styles = _styles;
            subtitles.ScriptInfo.PlayResX = int.Parse(subInfoForm.resWidth.Text);
            subtitles.ScriptInfo.PlayRexY = int.Parse(subInfoForm.resHeight.Text);

            subInfoForm.Close();
        }
    }
}
