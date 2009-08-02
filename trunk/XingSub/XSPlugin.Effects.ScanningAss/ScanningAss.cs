﻿using System;
using System.IO;
using System.Reflection;
using System.Xml;
using XingSub;

namespace XSPlugin.Effects.ScanningAss
{
    public class ScanningAss : IPlugin
    {
        private string descriptions = "光带扫字特效(*.ass)";
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
            header = header.Replace("{$color}", ps["color"].FirstChild.Value.Substring(1, 6));

            int delay = int.Parse(ps["delay"].FirstChild.Value);
            float spead = float.Parse(ps["spead"].FirstChild.Value);

            StreamWriter writer = File.CreateText(path);
            writer.WriteLine(header);

            string[] line = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < line.Length; i++)
            {
                string subtitle0 = "";
                string subtitle = "";
                string lineStart = "";
                string lineEnd = "";
                string lineEnd2 = "";

                string[] words = line[i].Split("+".ToCharArray());
                for (int j = 0; j < words.Length - 1; j++)
                {
                    if (words[j].Length > 7 && words[j + 1].Length >= 7)
                    {
                        int startTime = stringToMsecond(words[j].Substring(0, 7));
                        int endTime = stringToMsecond(words[j + 1].Substring(0, 7));
                        subtitle0 += words[j].Substring(7);
                        subtitle += "{\\K" + (endTime - startTime).ToString() + "}" + words[j].Substring(7);

                        if (lineStart.Length == 0) lineStart = stringToStamp(msecondsToString(startTime - 20));
                        lineEnd = stringToStamp(msecondsToString(endTime + 20 + delay));
                        lineEnd2 = stringToStamp(msecondsToString(endTime + 40 + delay));
                    }
                }

                string kdelay = (20 + delay).ToString();
                writer.WriteLine("Dialogue: 0," + lineStart + "," + lineEnd2 + ",optx0,,0000,0000,0000,,{\\pos(100,100)\\fad(200,200)}" + subtitle0);
                writer.WriteLine("Dialogue: 1," + lineStart + "," + lineEnd + ",optx1,,0000,0000,0000,,{\\pos(100,100)\\fad(200,0)\\K20}" + subtitle);
                writer.WriteLine("Dialogue: 2," + lineStart + "," + lineEnd2 + ",optx2,,0000,0000,0000,,{\\pos(100,100)\\fad(200,200)\\K" + kdelay + "}" + subtitle);
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