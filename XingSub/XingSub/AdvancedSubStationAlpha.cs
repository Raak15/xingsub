using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingSub
{
    public class AdvancedSubStationAlpha
    {
        private SubStationInfo _scriptInfo = new SubStationInfo();
        private List<SubStationStyle> _styles = new List<SubStationStyle>();
        private List<SubStationEvent> _events = new List<SubStationEvent>();

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

        /// <summary>
        /// 把当前对象转换为 Advanced SubStation Alpha 文本
        /// </summary>
        /// <returns>Advanced SubStation Alpha 文本</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("[Script	Info]");
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
    }
}
