using System;
using System.IO;
using System.Reflection;
using System.Xml;
using XingSub;

namespace XSPlugin.Simple.Ssa
{
    public class Ssa : IPlugin
    {
        private string descriptions = "SSA 字幕文件(*.ssa)";
        private string extension = "ssa";
        private bool isEffects = false;

        #region IPlugin 成员

        int IPlugin.Convert(string input, string path)
        {
            string currect = Assembly.GetExecutingAssembly().Location;
            string config = Path.Combine(Path.GetDirectoryName(currect), Path.GetFileNameWithoutExtension(currect) + ".header");

            XmlDocument xml = new XmlDocument();
            xml.Load(config);

            XmlNode ps = xml.DocumentElement["params"];

            string header = xml.DocumentElement["head"].FirstChild.Value;

            StreamWriter writer = File.CreateText(path);
            writer.WriteLine(header);

            string[] line = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i].Length > 7 && line[i + 1].Length >= 7)
                {
                    string startTime = line[i].Substring(0, 1) + ":" + line[i].Substring(1, 2) + ":" + line[i].Substring(3, 2) + "." + line[i].Substring(5, 2);
                    string endTime = line[i + 1].Substring(0, 1) + ":" + line[i + 1].Substring(1, 2) + ":" + line[i + 1].Substring(3, 2) + "." + line[i + 1].Substring(5, 2);
                    string subtitle = line[i].Substring(7);
                    writer.WriteLine("Dialogue: Marked=0," + startTime + "," + endTime + ",Default,,0000,0000,0000,," + subtitle);
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
