using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace XingSub
{
    public class SubStationEvent
    {
        #region 私有变量声明
        private int _layer = 0;
        private string _start = "0:00:00.00";
        private string _end = "0:00:00.00";
        private string _style = "Default";
        private string _actor = "";
        private int _marginL = 0;
        private int _marginR = 0;
        private int _marginV = 0;
        private string _effect = "";
        private string _text = "";
        #endregion

        #region 字段声明
        public int Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public string Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public string End
        {
            get { return _end; }
            set { _end = value; }
        }

        public string Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public string Actor
        {
            get { return _actor; }
            set { _actor = value; }
        }

        public int MarginL
        {
            get { return _marginL; }
            set { _marginL = value; }
        }

        public int MarginR
        {
            get { return _marginR; }
            set { _marginR = value; }
        }

        public int MarginV
        {
            get { return _marginV; }
            set { _marginV = value; }
        }

        public string Effect
        {
            get { return _effect; }
            set { _effect = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion

        /// <summary>
        /// 创建一条字幕
        /// </summary>
        /// <param name="layer">层</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="style">样式</param>
        /// <param name="actor">演员</param>
        /// <param name="marginL">左边距</param>
        /// <param name="marginR">右边距</param>
        /// <param name="marginV">纵边距</param>
        /// <param name="effect">特效</param>
        /// <param name="text">文本</param>
        public SubStationEvent(int layer, string start, string end, string style, string actor, int marginL, int marginR, int marginV, string effect, string text)
        {
            _layer = layer;
            _start = start;
            _end = end;
            _style = style;
            _actor = actor;
            _marginL = marginL;
            _marginR = marginR;
            _marginV = marginV;
            _effect = effect;
            _text = text;
        }

        /// <summary>
        /// 使用部分参数创建一条字幕
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="text">文本</param>
        public SubStationEvent(string start, string end, string text)
        {
            _start = start;
            _end = end;
            _text = text;
        }

        /// <summary>
        /// 创建一条字幕
        /// </summary>
        /// <param name="dialogue">Events 字符串</param>
        public SubStationEvent(string dialogue)
        {
            if (dialogue.Substring(0, 9) == "Dialogue:")
            {
                string dialogueString = dialogue.Substring(9).Trim();

                Regex reg = new Regex(@"(\d+),(\d{1}:\d{2}:\d{2}\.\d{2}),(\d{1}:\d{2}:\d{2}\.\d{2}),(.+?),(.*?),(.+?),(.+?),(.+?),(.*?),(.*)");

                if (reg.IsMatch(dialogueString))
                {
                    GroupCollection prms = reg.Match(dialogueString).Groups;

                    _layer = int.Parse(prms[1].Value);
                    _start = prms[2].Value;
                    _end = prms[3].Value;
                    _style = prms[4].Value;
                    _actor = prms[5].Value;
                    _marginL = int.Parse(prms[6].Value);
                    _marginR = int.Parse(prms[7].Value);
                    _marginV = int.Parse(prms[8].Value);
                    _effect = prms[9].Value;
                    _text = prms[10].Value;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// 创建一条空字幕
        /// </summary>
        public SubStationEvent()
        {
        }

        /// <summary>
        /// 把当前对象转换为 Events 字符串
        /// </summary>
        /// <returns>Events 字符串</returns>
        public override string ToString()
        {
            object[] prms = new object[10];

            prms[0] = _layer;
            prms[1] = _start;
            prms[2] = _end;
            prms[3] = _style;
            prms[4] = _actor;
            prms[5] = _marginL;
            prms[6] = _marginR;
            prms[7] = _marginV;
            prms[8] = _effect;
            prms[9] = _text;

            return String.Format("Dialogue: {0},{1},{2},{3},{4},{5:0000},{6:0000},{7:0000},{8},{9}", prms);
        }
    }
}
