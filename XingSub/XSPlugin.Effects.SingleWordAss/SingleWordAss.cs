using System;
using System.IO;
using System.Reflection;
using System.Xml;
using XingSub;

namespace XSPlugin.Effects.SingleWordAss
{
    public class SingleWordAss : IPlugin
    {
        private string descriptions = "单字出现特效(*.ass)";
        private string extension = "ass";
        private bool isEffects = true;

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

            for (int i = 0; i < line.Length; i++)
            {
                string[] word = line[i].Split("+".ToCharArray());
                for (int j = 0; j < word.Length - 1; j++)
                {
                    if (word[j].Length > 7 && word[j + 1].Length >= 7)
                    {
                        string startTime = stringToStamp(word[j].Substring(0, 7));
                        string endTime = stringToStamp(word[j + 1].Substring(0, 7));
                        string subtitle = word[j].Substring(7).Trim();

                        writer.WriteLine("Dialogue: 0," + startTime + "," + endTime + ",optx1,,0000,0000,0000,," + subtitle);
                    }
                }
                writer.WriteLine();
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
