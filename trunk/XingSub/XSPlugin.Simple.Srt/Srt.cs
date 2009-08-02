using System;
using System.IO;
using XingSub;

namespace XSPlugin.Simple.Srt
{
    public class Srt: IPlugin
    {
        private string descriptions = "SRT 字幕文件(*.srt)";
        private string extension = "srt";
        private bool isEffects = false;

        #region IPlugin 成员

        int IPlugin.Convert(string input, string path)
        {
            StreamWriter writer = File.CreateText(path);
            string[] line = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int count = 1;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i].Length > 7 && line[i + 1].Length >= 7)
                {
                    string startTime = "0" + line[i].Substring(0, 1) + ":" + line[i].Substring(1, 2) + ":" + line[i].Substring(3, 2) + "," + line[i].Substring(5, 2);
                    string endTime = "0" + line[i + 1].Substring(0, 1) + ":" + line[i + 1].Substring(1, 2) + ":" + line[i + 1].Substring(3, 2) + "," + line[i + 1].Substring(5, 2);
                    string subtitle = line[i].Substring(7);
                    writer.WriteLine(count.ToString());
                    writer.WriteLine(startTime + " --> " + endTime);
                    writer.WriteLine(subtitle);
                    count++;
                }
            }

            writer.Flush();
            writer.Close();
            return 0;
        }

        string IPlugin.Descriptions()
        {
            return descriptions;
        }

        bool IPlugin.IsEffects()
        {
            return isEffects;
        }

        string IPlugin.Extension()
        {
            return extension;
        }

        #endregion
    }
}
