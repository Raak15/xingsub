using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XingSub
{
    public partial class mainForm : Form
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

        private const UInt32 WM_GETTEXT = 0x000D;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        private static EnumWindowsProc callbackEnumChildWindows = new EnumWindowsProc(ChildWindowProc);
        #endregion

        private static int getCount = 0;
        private static string timeString = "";
        private static string lastString = "";
        private static int timeSource = 0; //0=Nero; 1=MPC

        private bool isSaved = true;
        private string fileName = "";
        private bool effectMode = false;
        private int timeOffset = 0;

        private List<Type> pluginsList;
        private List<Type> readersList;

        private aboutForm aboutForm = new aboutForm();
        private paramsForm paramsForm = new paramsForm();

        public mainForm()
        {
            InitializeComponent();
        }

        private static bool ChildWindowProc(IntPtr hWnd, IntPtr lParam)
        {
            switch (timeSource)
            {
                case 0:
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
                    break;
                case 1:
                    if (getCount < 1)
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
                    break;
            }
            return true;
        }

        private void timerCapture_Tick(object sender, EventArgs e)
        {
            switch (timeSource)
            {
                case 0:
                    if (getCount < 4)   //未取够4次则继续
                    {
                        IntPtr h = FindWindow(null, "手动定义标记");
                        if (h.ToInt32() > 0)
                        {
                            EnumChildWindows(h, callbackEnumChildWindows, this.Handle);
                        }
                    }
                    else if (getCount == 4) //取够4次，插入时间
                    {
                        insertTime();
                    }
                    break;
                case 1:
                    if (getCount < 1)   //未取够1次则继续
                    {
                        IntPtr h = FindWindow(null, "转到...");
                        if (h.ToInt32() > 0)
                        {
                            EnumChildWindows(h, callbackEnumChildWindows, this.Handle);
                        }
                    }
                    else if (getCount == 1) //取够1次，插入时间
                    {
                        insertTime();
                    }
                    break;
            }
            
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            if (askToSave())
            {
                textBox1.Text = "";
                fileName = "";
                isSaved = true;
                if (effectMode)
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
                openFileDialog1.ShowDialog();

                if (openFileDialog1.FileName.Length == 0) return;

                fileName = openFileDialog1.FileName;

                StreamReader fileReader = File.OpenText(fileName);
                textBox1.Text = fileReader.ReadToEnd();
                fileReader.Close();

                isSaved = true;

                changeEffectsMode(Path.GetExtension(fileName) == ".xse");

                if (effectMode)
                {
                    this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName);
                }
                else
                {
                    this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isSaved = false;
            if (fileName.Length == 0)
            {
                if (effectMode)
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
                if (effectMode)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!askToSave()) e.Cancel = true;
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
            if (effectMode)
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
            fileWriter.Write(textBox1.Text);
            fileWriter.Flush();
            fileWriter.Close();
            isSaved = true;

            effectMode = (Path.GetExtension(fileName) == ".xse");
            if (effectMode)
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
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Cut();
            }
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                textBox1.Paste();
            }
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
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
                fileWriter.Write(textBox1.Text);
                fileWriter.Flush();
                fileWriter.Close();
                toolStripStatusLabel1.Text = String.Format(Localizable.AutoSaved, autoSaveTime.ToString());
            }
        }

        private void insertNewLineMenuItem_Click(object sender, EventArgs e)
        {
            int nextNewline = textBox1.Text.Substring(textBox1.SelectionStart).IndexOf(Environment.NewLine);
            if (nextNewline == -1)
            {
                textBox1.Text += Environment.NewLine;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            else
            {
                textBox1.SelectionStart += nextNewline;
                textBox1.SelectedText = Environment.NewLine;
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
            timeOffset = 1;
        }

        private void offsetTwoMenuItem_Click(object sender, EventArgs e)
        {
            offsetOneMenuItem.Checked = false;
            offsetTwoMenuItem.Checked = true;
            offsetBySpaceMenuItem.Checked = false;
            timeOffset = 2;
        }

        private void offsetBySpaceMenuItem_Click(object sender, EventArgs e)
        {
            offsetOneMenuItem.Checked = false;
            offsetTwoMenuItem.Checked = false;
            offsetBySpaceMenuItem.Checked = true;
            timeOffset = 0;
        }

        private void NWEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NWEToolStripMenuItem.Checked = true;
            MPCToolStripMenuItem.Checked = false;
            timeSource = 0;
        }

        private void MPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NWEToolStripMenuItem.Checked = false;
            MPCToolStripMenuItem.Checked = true;
            timeSource = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void plugin_Click(object sender, EventArgs e)
        {
            ToolStripItem menu = (ToolStripItem)sender;
            Type plug = pluginsList[exportMenuItem.DropDownItems.IndexOf(menu)];
            IPlugin obj = (IPlugin)Activator.CreateInstance(plug);

            saveFileDialog1.Reset();
            saveFileDialog1.Filter = String.Format(Localizable.ExportFileType, obj.Descriptions(), obj.Extension());
            saveFileDialog1.DefaultExt = obj.Extension();
            saveFileDialog1.Title = Localizable.ExportTitle;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Length == 0) return;

            if (obj.Convert(textBox1.Text, saveFileDialog1.FileName) == 0)
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
            if (fileName.Length == 0)
            {
                saveFileDialog1.Reset();
                if (effectMode)
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
            fileWriter.Write(textBox1.Text);
            fileWriter.Flush();
            fileWriter.Close();
            isSaved = true;
            if (effectMode)
            {
                this.Text = String.Format(Localizable.Title, Localizable.EffectsMode, fileName);
            }
            else
            {
                this.Text = String.Format(Localizable.Title, Localizable.NormalMode, fileName);
            }

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
                if (effectMode) //特效模式
                {
                    //插入时间
                    textBox1.SelectedText = "+" + timeString;

                    //定位到下一音节
                    int endOfLine = textBox1.Text.Substring(textBox1.SelectionStart).IndexOf(Environment.NewLine);
                    if (endOfLine == -1)
                    {
                        endOfLine = textBox1.Text.Length - textBox1.SelectionStart;
                    }
                    int nextWord;   //寻找下一音节
                    if (timeOffset == 0)    //自动偏移
                    {
                        nextWord = textBox1.Text.Substring(textBox1.SelectionStart).IndexOf(" ") + 1;   //下一空格
                    }
                    else
                    {
                        nextWord = timeOffset;
                    }

                    if (nextWord > endOfLine || nextWord == 0)   //如果超过行尾
                    {
                        textBox1.SelectionStart += endOfLine;
                    }
                    else
                    {
                        textBox1.SelectionStart += nextWord;
                    }

                    if (endOfLine == 0)   //如果已到达行尾
                    {
                        textBox1.SelectionStart += 2;   //定位到下一行
                    }
                }
                else
                {
                    //定位到行首
                    int lastNewline = textBox1.Text.Substring(0, textBox1.SelectionStart).LastIndexOf(Environment.NewLine);
                    if (lastNewline == -1)
                    {
                        textBox1.SelectionStart = 0;
                    }
                    else
                    {
                        textBox1.SelectionStart = lastNewline + 2;
                    }

                    //插入时间
                    textBox1.SelectedText = timeString;

                    //定位到下一行首
                    int nextNewline = textBox1.Text.Substring(textBox1.SelectionStart).IndexOf(Environment.NewLine);
                    if (nextNewline == -1)
                    {
                        textBox1.Text += Environment.NewLine;
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                    else
                    {
                        textBox1.SelectionStart += (nextNewline + 2);
                    }
                }
                toolStripStatusLabel1.Text = String.Format(Localizable.InsertedTimeStamp, stringToStamp(timeString));
            }
            getCount = 0;
            lastString = timeString;
            timeString = "";
        }

        private void changeEffectsMode(bool mode)
        {
            effectMode = mode;
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
                if (Path.GetExtension(fileName) != ".xss")  //如果扩展名不符，要求另存。
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

            for (int i = 0; i < pluginsList.Count; i++)
            {
                IPlugin obj = (IPlugin)Activator.CreateInstance(pluginsList[i]);
                exportMenuItem.DropDownItems[i].Visible = (obj.IsEffects() == mode);
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
                            ToolStripItem item = exportMenuItem.DropDownItems.Add(obj.Descriptions());
                            item.Click += new EventHandler(plugin_Click);
                            item.Visible = (obj.IsEffects() == effectMode);

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
                            item.Visible = (obj.IsEffects() == effectMode);
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
    }
}
