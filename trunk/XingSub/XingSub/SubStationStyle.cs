using System;

namespace XingSub
{
    public class SubStationStyle
    {
        #region 私有变量声明
        private string _name = "Default";
        private string _fontname = "Simhei";
        private float _fontsize = 24;
        private string _primaryColour = "&H00ffffff";
        private string _secondaryColour = "&H00ffffff";
        private string _outlineColour = "&H00232323";
        private string _backColour = "&H80232323";
        private int _bold = -1;
        private int _italic = 0;
        private int _underline = 0;
        private float _strikeOut = 0;
        private float _scaleX = 100;
        private float _scaleY = 100;
        private float _spacing = 0;
        private float _angle = 0;
        private int _borderStyle = 1;
        private float _outline = 1;
        private float _shadow = 1;
        private int _alignment = 2;
        private float _marginL = 20;
        private float _marginR = 20;
        private float _marginV = 15;
        private int _encoding = 1;
        #endregion

        #region 字段声明
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Fontname
        {
            get { return _fontname; }
            set { _fontname = value; }
        }
        
        public float Fontsize
        {
            get { return _fontsize; }
            set { _fontsize = value; }
        }
        
        public string PrimaryColour
        {
            get { return _primaryColour; }
            set { _primaryColour = value; }
        }
        
        public string SecondaryColour
        {
            get { return _secondaryColour; }
            set { _secondaryColour = value; }
        }
        
        public string OutlineColour
        {
            get { return _outlineColour; }
            set { _outlineColour = value; }
        }
        
        public string BackColour
        {
            get { return _backColour; }
            set { _backColour = value; }
        }
        
        public int Bold
        {
            get { return _bold; }
            set { _bold = value; }
        }
        
        public int Italic
        {
            get { return _italic; }
            set { _italic = value; }
        }
        
        public int Underline
        {
            get { return _underline; }
            set { _underline = value; }
        }
        
        public float StrikeOut
        {
            get { return _strikeOut; }
            set { _strikeOut = value; }
        }
        
        public float ScaleX
        {
            get { return _scaleX; }
            set { _scaleX = value; }
        }
        
        public float ScaleY
        {
            get { return _scaleY; }
            set { _scaleY = value; }
        }
        
        public float Spacing
        {
            get { return _spacing; }
            set { _spacing = value; }
        }
        
        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }
        
        public int BorderStyle
        {
            get { return _borderStyle; }
            set { _borderStyle = value; }
        }
        
        public float Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }
        
        public float Shadow
        {
            get { return _shadow; }
            set { _shadow = value; }
        }
        
        public int Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }
        
        public float MarginL
        {
            get { return _marginL; }
            set { _marginL = value; }
        }
        
        public float MarginR
        {
            get { return _marginR; }
            set { _marginR = value; }
        }
        
        public float MarginV
        {
            get { return _marginV; }
            set { _marginV = value; }
        }
        
        public int Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }
        #endregion

        /// <summary>
        /// 创建一个字幕样式
        /// </summary>
        /// <param name="name">样式名称</param>
        /// <param name="fontname">字体名称</param>
        /// <param name="fontsize">字体大小</param>
        /// <param name="primaryColour">主要色彩</param>
        /// <param name="secondaryColour">次要色彩</param>
        /// <param name="outlineColour">边线色彩</param>
        /// <param name="backColour">背景色彩</param>
        /// <param name="bold">加粗</param>
        /// <param name="italic">倾斜</param>
        /// <param name="underline">下划线</param>
        /// <param name="strikeOut">删除线</param>
        /// <param name="scaleX">横向缩放</param>
        /// <param name="scaleY">纵向缩放</param>
        /// <param name="spacing">间隔</param>
        /// <param name="angle">旋转角度</param>
        /// <param name="borderStyle">边线样式</param>
        /// <param name="outline">边线大小</param>
        /// <param name="shadow">阴影距离</param>
        /// <param name="alignment">对齐方式</param>
        /// <param name="marginL">左边距</param>
        /// <param name="marginR">右边距</param>
        /// <param name="marginV">纵边距</param>
        /// <param name="encoding">编码</param>
        public SubStationStyle(string name, string fontname, float fontsize, string primaryColour, string secondaryColour, string outlineColour, string backColour, int bold, int italic, int underline, float strikeOut, float scaleX, float scaleY, float spacing, float angle, int borderStyle, float outline, float shadow, int alignment, float marginL, float marginR, float marginV, int encoding)
        {
            _name = name;
            _fontname = fontname;
            _fontsize = fontsize;
            _primaryColour = primaryColour;
            _secondaryColour = secondaryColour;
            _outlineColour = outlineColour;
            _backColour = backColour;
            _bold = bold;
            _italic = italic;
            _underline = underline;
            _strikeOut = strikeOut;
            _scaleX = scaleX;
            _scaleY = scaleY;
            _spacing = spacing;
            _angle = angle;
            _borderStyle = borderStyle;
            _outline = outline;
            _shadow = shadow;
            _alignment = alignment;
            _marginL = marginL;
            _marginR = marginR;
            _marginV = marginV;
            _encoding = encoding;
        }

        /// <summary>
        /// 使用默认参数创建一个字幕样式
        /// </summary>
        /// <param name="name">样式名称</param>
        /// <param name="fontsize">字体大小</param>
        public SubStationStyle(string name, float fontsize)
        {
            _name = name;
            _fontsize = fontsize;
        }

        /// <summary>
        /// 通过 V4+ Styles 字符串创建一个字幕样式
        /// </summary>
        /// <param name="style">V4+ Styles 字符串</param>
        public SubStationStyle(string style)
        {
            if (style.Substring(0, 6) == "Style:")
            {
                string styleString = style.Substring(6).Trim();
                string[] prms = styleString.Split(",".ToCharArray());

                if (prms.Length == 23)
                {
                    _name = prms[0];
                    _fontname = prms[1];
                    _fontsize = float.Parse(prms[2]);
                    _primaryColour = prms[3];
                    _secondaryColour = prms[4];
                    _outlineColour = prms[5];
                    _backColour = prms[6];
                    _bold = int.Parse(prms[7]);
                    _italic = int.Parse(prms[8]);
                    _underline = int.Parse(prms[9]);
                    _strikeOut = float.Parse(prms[10]);
                    _scaleX = float.Parse(prms[11]);
                    _scaleY = float.Parse(prms[12]);
                    _spacing = float.Parse(prms[13]);
                    _angle = float.Parse(prms[14]);
                    _borderStyle = int.Parse(prms[15]);
                    _outline = float.Parse(prms[16]);
                    _shadow = float.Parse(prms[17]);
                    _alignment = int.Parse(prms[18]);
                    _marginL = float.Parse(prms[19]);
                    _marginR = float.Parse(prms[20]);
                    _marginV = float.Parse(prms[21]);
                    _encoding = int.Parse(prms[22]);
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
        /// 使用默认参数创建一个字幕样式
        /// </summary>
        public SubStationStyle()
        {
        }

        /// <summary>
        /// 把当前对象转换为 V4+ Styles 字符串
        /// </summary>
        /// <returns>V4+ Styles 字符串</returns>
        public override string ToString()
        {
            object[] prms = new object[23];

            prms[0] = _name;
            prms[1] = _fontname;
            prms[2] = _fontsize;
            prms[3] = _primaryColour;
            prms[4] = _secondaryColour;
            prms[5] = _outlineColour;
            prms[6] = _backColour;
            prms[7] = _bold;
            prms[8] = _italic;
            prms[9] = _underline;
            prms[10] = _strikeOut;
            prms[11] = _scaleX;
            prms[12] = _scaleY;
            prms[13] = _spacing;
            prms[14] = _angle;
            prms[15] = _borderStyle;
            prms[16] = _outline;
            prms[17] = _shadow;
            prms[18] = _alignment;
            prms[19] = _marginL;
            prms[20] = _marginR;
            prms[21] = _marginV;
            prms[22] = _encoding;

            return String.Format("Style: {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14:F2},{15},{16},{17},{18},{19},{20},{21},{22}", prms);
        }
    }
}
