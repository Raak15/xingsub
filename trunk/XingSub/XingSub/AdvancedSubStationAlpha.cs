using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingSub
{
    public class AdvancedSubStationAlpha
    {
        private SubStationInfo _scriptInfo;
        private List<SubStationStyle> _styles;
        private List<SubStationEvent> _events;

        /// <summary>
        /// 脚本信息
        /// </summary>
        internal SubStationInfo ScriptInfo
        {
            get { return _scriptInfo; }
            set { _scriptInfo = value; }
        }

        /// <summary>
        /// 字幕样式
        /// </summary>
        public List<SubStationStyle> Styles
        {
            get { return _styles; }
            set { _styles = value; }
        }

        /// <summary>
        /// 字幕
        /// </summary>
        public List<SubStationEvent> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public AdvancedSubStationAlpha()
        {
            _scriptInfo = new SubStationInfo();
            _styles = new List<SubStationStyle>();
            _events = new List<SubStationEvent>();
        }

        /// <summary>
        /// 从 ASS 加载
        /// </summary>
        /// <param name="text">ASS 文本</param>
        public void LoadAss(string text)
        {
            _styles = new List<SubStationStyle>();
            _events = new List<SubStationEvent>();

            string[] lines = text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int mode = 0;

            int playRexX = 0;
            int playRexY = 0;
            bool isStyle = false;
            bool isEvent = false;

            foreach (string s in lines)
            {
                string line = s.Trim();

                if (line == "[Script Info]")
                {
                    mode = 1;
                    System.Diagnostics.Debug.WriteLine(line);
                }
                else if (line == "[V4+ Styles]")
                {
                    mode = 2;
                    System.Diagnostics.Debug.WriteLine(line);
                }
                else if (line == "[Events]")
                {
                    mode = 3;
                    System.Diagnostics.Debug.WriteLine(line);
                }
                else
                {
                    switch (mode)
                    {
                        case 1:
                            if (line.Length > 9)
                            {
                                if (line.Substring(0, 9) == "PlayResX:")
                                {
                                    playRexX = int.Parse(line.Substring(9).Trim());
                                }
                                else if (line.Substring(0, 9) == "PlayResY:")
                                {
                                    playRexY = int.Parse(line.Substring(9).Trim());
                                }
                                
                                if (playRexX > 0 && playRexY > 0)
                                {
                                    _scriptInfo = new SubStationInfo(playRexX, playRexY);
                                }
                            }
                            break;
                        case 2:
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
                                        SubStationStyle substyle = new SubStationStyle(line);
                                        _styles.Add(substyle);
                                    }
                                }
                            }
                            break;
                        case 3:
                            if (line.Replace(" ", "") == "Format:Layer,Start,End,Style,Actor,MarginL,MarginR,MarginV,Effect,Text")
                            {
                                isEvent = true;
                            }

                            if (isEvent)
                            {
                                if (line.Length > 9)
                                {
                                    if (line.Substring(0, 9) == "Dialogue:")
                                    {
                                        SubStationEvent subevent = new SubStationEvent(line);
                                        _events.Add(subevent);
                                    }
                                }
                            }
                            break;
                        default:
                            //do nothing
                            break;
                    }
                }
            }

            bool hasDefault = false;
            foreach (SubStationStyle _style in _styles)
            {
                if (_style.Name == "Default") hasDefault = true;
            }
            if (!hasDefault) _styles.Insert(0, new SubStationStyle());
        }

        /// <summary>
        /// 从 XingSub 时间轴加载
        /// </summary>
        /// <param name="text">XingSub 对白时间轴文本</param>
        public void LoadXss(string text)
        {
            if (_styles.Count == 0)
            {
                _styles.Add(new SubStationStyle());
            }

            _events = new List<SubStationEvent>();
            string[] line = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i].Length > 7 && line[i + 1].Length >= 7)
                {
                    string startTime = TimeToStamp(line[i].Substring(0, 7));
                    string endTime = TimeToStamp(line[i + 1].Substring(0, 7));
                    string subtitle = line[i].Substring(7);

                    SubStationEvent subevent = new SubStationEvent(startTime, endTime, subtitle);
                    _events.Add(subevent);
                }
            }
        }

        /// <summary>
        /// 把当前对象转换为 XingSub 时间轴文本
        /// </summary>
        /// <returns>XingSub 时间轴文本</returns>
        public string ToXingSub()
        {
            StringBuilder builder = new StringBuilder(255);

            foreach (SubStationEvent subevent in _events)
            {
                builder.AppendLine(StampToTime(subevent.Start) + subevent.Text);
                builder.AppendLine(StampToTime(subevent.End));
            }

            System.Diagnostics.Debug.WriteLine(_events.Count + ":" + builder.ToString());

            return builder.ToString();
        }

        /// <summary>
        /// 把当前对象转换为 Advanced SubStation Alpha 文本
        /// </summary>
        /// <returns>Advanced SubStation Alpha 文本</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(255);

            result.AppendLine("[Script Info]");
            result.AppendLine(_scriptInfo.ToString());
            result.AppendLine();
            result.AppendLine("[V4+ Styles]");
            result.AppendLine("Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding");
            foreach (SubStationStyle _style in _styles)
            {
                result.AppendLine(_style.ToString());
            }
            result.AppendLine();
            result.AppendLine("[Events]");
            result.AppendLine("Format: Layer, Start, End, Style, Actor, MarginL, MarginR, MarginV, Effect, Text");
            foreach (SubStationEvent _event in _events)
            {
                result.AppendLine(_event.ToString());
            }

            return result.ToString();
        }

        /// <summary>
        /// “百分之一秒” 转换为 “XingSub 时间码”
        /// </summary>
        /// <param name="mseconds">百分之一秒</param>
        /// <returns>XingSub 时间码</returns>
        public string MsecondsToTime(int mseconds)
        {
            int left = mseconds;

            int ms = left % 100;
            left = (left - ms) / 100;

            int seconds = left % 60;
            left = (left - seconds) / 60;

            int minutes = left % 60;
            left = (left - minutes) / 60;

            int hours = left;

            return String.Format("{0}{1:00}{2:00}{3:00}", hours, minutes, seconds, ms);
        }

        /// <summary>
        /// “XingSub 时间码” 转换为 “百分之一秒”
        /// </summary>
        /// <param name="time">XingSub 时间码</param>
        /// <returns>百分之一秒</returns>
        public int TimeToMsecond(string time)
        {
            int hours = int.Parse(time.Substring(0, 1));
            int minutes = int.Parse(time.Substring(1, 2));
            int seconds = int.Parse(time.Substring(3, 2));
            int ms = int.Parse(time.Substring(5, 2));

            return ((hours * 60 + minutes) * 60 + seconds) * 100 + ms;
        }

        /// <summary>
        /// “XingSub 时间码” 转换为 “时间标记”
        /// </summary>
        /// <param name="time">XingSub 时间码</param>
        /// <returns>时间标记</returns>
        public string TimeToStamp(string time)
        {
            string hours = time.Substring(0, 1);
            string minutes = time.Substring(1, 2);
            string seconds = time.Substring(3, 2);
            string ms = time.Substring(5, 2);

            return String.Format("{0}:{1:00}:{2:00}.{3:00}", hours, minutes, seconds, ms);
        }

        /// <summary>
        /// “时间标记” 转换为 “XingSub时间码”
        /// </summary>
        /// <param name="stamp">时间标记</param>
        /// <returns>XingSub 时间码</returns>
        public string StampToTime(string stamp)
        {
            string hours = stamp.Substring(0, 1);
            string minutes = stamp.Substring(2, 2);
            string seconds = stamp.Substring(5, 2);
            string ms = stamp.Substring(8, 2);

            return String.Format("{0}{1:00}{2:00}{3:00}", hours, minutes, seconds, ms);
        }
    }
}
