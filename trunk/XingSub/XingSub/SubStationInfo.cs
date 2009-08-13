using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingSub
{
    class SubStationInfo
    {
        #region 私有变量声明
        private string _scriptType = "v4.00+";
        private string _collisions = "Normal";
        private int _playResX = 640;
        private int _playRexY = 480;
        private float _timer = 100;
        #endregion

        #region 字段声明
        public string ScriptType
        {
            get { return _scriptType; }
            set { _scriptType = value; }
        }
        
        public string Collisions
        {
            get { return _collisions; }
            set { _collisions = value; }
        }
        
        public int PlayResX
        {
            get { return _playResX; }
            set { _playResX = value; }
        }
        
        public int PlayRexY
        {
            get { return _playRexY; }
            set { _playRexY = value; }
        }
        
        public float Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }
        #endregion

        /// <summary>
        /// 创建脚本信息
        /// </summary>
        /// <param name="playResX">横向分辨率</param>
        /// <param name="playRexY">纵向分辨率</param>
        public SubStationInfo(int playResX, int playRexY)
        {
            _playResX = playResX;
            _playRexY = playRexY;
        }

        /// <summary>
        /// 使用默认参数创建脚本信息
        /// </summary>
        public SubStationInfo()
        {
        }

        /// <summary>
        /// 把当前对象转换为 Script Info 字符串
        /// </summary>
        /// <returns>Script Info 字符串</returns>
        public override string ToString()
        {
            return String.Format("ScriptType: {0}\nCollisions: {1}\nPlayResX: {2}\nPlayResY: {3}\nTimer: {4:F4}", _scriptType, _collisions, _playResX, _playRexY, _timer);
        }
    }
}
