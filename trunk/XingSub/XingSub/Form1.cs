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
    public partial class Form1 : Form
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

        private aboutForm aboutForm = new aboutForm();

        public Form1()
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
                    this.Text = "XingSub - 特效模式 [新文件]";
                }
                else
                {
                    this.Text = "XingSub - 正常模式 [新文件]";
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

                effectMode = (Path.GetExtension(fileName) == ".xse");

                if (effectMode)
                {
                    this.Text = "XingSub - 特效模式 [" + fileName + "]";
                    normalModeMenuItem.Checked = false;
                    effectsModeMenuItem.Checked = true;
                    offsetMenuItem.Enabled = true;
                }
                else
                {
                    this.Text = "XingSub - 正常模式 [" + fileName + "]";
                    normalModeMenuItem.Checked = true;
                    effectsModeMenuItem.Checked = false;
                    offsetMenuItem.Enabled = false;
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
                    this.Text = "XingSub - 特效模式 [新文件*]";
                }
                else
                {
                    this.Text = "XingSub - 正常模式 [新文件*]";
                }
            }
            else
            {
                if (effectMode)
                {
                    this.Text = "XingSub - 特效模式 [" + fileName + "*]";
                }
                else
                {
                    this.Text = "XingSub - 正常模式 [" + fileName + "*]";
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
                saveFileDialog1.Filter = "XingSub 特效时间轴(*.xse)|*.xse|XingSub 字幕时间轴(*.xss)|*.xss|所有文件(*.*)|*.*";
                saveFileDialog1.DefaultExt = "xse";
                saveFileDialog1.Title = "保存 XingSub 特效时间轴";
            }
            else
            {
                saveFileDialog1.Filter = "XingSub 字幕时间轴(*.xss)|*.xss|XingSub 特效时间轴(*.xse)|*.xse|所有文件(*.*)|*.*";
                saveFileDialog1.DefaultExt = "xss";
                saveFileDialog1.Title = "保存 XingSub 字幕时间轴";
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
                this.Text = "XingSub - 特效模式 [" + fileName + "]";
                normalModeMenuItem.Checked = false;
                effectsModeMenuItem.Checked = true;
                offsetMenuItem.Enabled = true;
            }
            else
            {
                this.Text = "XingSub - 正常模式 [" + fileName + "]";
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
                toolStripStatusLabel1.Text = "已自动保存: " + autoSaveTime.ToString();
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
            offsetMenuItem.Enabled = false;
            normalModeMenuItem.Checked = true;
            effectsModeMenuItem.Checked = false;
            effectMode = false;
            if (Path.GetExtension(fileName) != ".xss")  //如果扩展名不符，要求另存。
            {
                fileName = "";
                isSaved = false;
            }
            if (fileName.Length == 0)
            {
                this.Text = "XingSub - 正常模式 [新文件*]";
            }
            else
            {
                this.Text = "XingSub - 正常模式 [" + fileName + "*]";
            }
            saveToFile();
        }

        private void effectsModeMenuItem_Click(object sender, EventArgs e)
        {
            offsetMenuItem.Enabled = true;
            normalModeMenuItem.Checked = false;
            effectsModeMenuItem.Checked = true;
            effectMode = true;
            if (Path.GetExtension(fileName) != ".xse")  //如果扩展名不符，要求另存。
            {
                fileName = "";
                isSaved = false;
            }
            if (fileName.Length == 0)
            {
                this.Text = "XingSub - 特效模式 [新文件*]";
            }
            else
            {
                this.Text = "XingSub - 特效模式 [" + fileName + "*]";
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] pathstr = Directory.GetFiles(location, "*.dll");
            pluginsList = new List<Type>();

            foreach (string p in pathstr)
            {
                Assembly ase = Assembly.LoadFrom(p);
                if (ase.GetName().Version.Major == Assembly.GetEntryAssembly().GetName().Version.Major)
                {
                    foreach (Type type in ase.GetExportedTypes())
                    {
                        if (type.IsClass && typeof(IPlugin).IsAssignableFrom(type))
                        {
                            pluginsList.Add(type);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("该插件的主版本号与本程序的主版本号不一致。\n为了避免接口升级带来的错误，插件的主版本号必须与本程序主版本号一致。\n\n当前程序版本号: " + Assembly.GetEntryAssembly().GetName().Version.ToString(), "已跳过加载插件 " + Path.GetFileName(ase.Location), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void exportMenuItem_MouseEnter(object sender, EventArgs e)
        {
            exportMenuItem.DropDownItems.Clear();
            foreach (Type plug in pluginsList)
            {
                IPlugin obj = (IPlugin)Activator.CreateInstance(plug);
                if (obj.IsEffects() == effectMode)
                {
                    ToolStripItem item = exportMenuItem.DropDownItems.Add(obj.Descriptions());
                    item.Name = pluginsList.IndexOf(plug).ToString();
                    item.Click += new EventHandler(item_Click);
                }
            }
            if (exportMenuItem.DropDownItems.Count == 0)
            {
                ToolStripItem item = exportMenuItem.DropDownItems.Add("(没有发现导出插件)");
                item.Enabled = false;
            }
        }

        private void item_Click(object sender, EventArgs e)
        {
            ToolStripItem menu = (ToolStripItem)sender;
            Type plug = pluginsList[int.Parse(menu.Name)];
            IPlugin obj = (IPlugin)Activator.CreateInstance(plug);

            saveFileDialog1.Reset();
            saveFileDialog1.Filter = obj.Descriptions() + "|*." + obj.Extension() + "|所有文件(*.*)|*.*";
            saveFileDialog1.DefaultExt = obj.Extension();
            saveFileDialog1.Title = "导出字幕";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Length == 0) return;

            if (obj.Convert(textBox1.Text, saveFileDialog1.FileName) == 0)
            {
                MessageBox.Show("字幕导出成功", "导出字幕", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool saveToFile()
        {
            if (fileName.Length == 0)
            {
                saveFileDialog1.Reset();
                if (effectMode)
                {
                    saveFileDialog1.Filter = "XingSub 特效时间轴(*.xse)|*.xse|所有文件(*.*)|*.*";
                    saveFileDialog1.DefaultExt = "xse";
                    saveFileDialog1.Title = "保存 XingSub 特效时间轴";
                }
                else
                {
                    saveFileDialog1.Filter = "XingSub 字幕时间轴(*.xss)|*.xss|所有文件(*.*)|*.*";
                    saveFileDialog1.DefaultExt = "xss";
                    saveFileDialog1.Title = "保存 XingSub 字幕时间轴";
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
                this.Text = "XingSub - 特效模式 [" + fileName + "]";
            }
            else
            {
                this.Text = "XingSub - 正常模式 [" + fileName + "]";
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
                DialogResult result = MessageBox.Show("文件已更改，您需要保存吗？", "保存文件", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                toolStripStatusLabel1.Text = "已插入时间标记: " + timeString.Substring(0, 1) + ":" + timeString.Substring(1, 2) + ":" + timeString.Substring(3, 2) + "." + timeString.Substring(5, 2);
            }
            getCount = 0;
            lastString = timeString;
            timeString = "";
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
    }
}
