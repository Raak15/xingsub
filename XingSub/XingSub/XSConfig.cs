using System.Drawing;

namespace XingSub
{
    public class XSConfig
    {
        private bool effectMode = false;
        private bool autoClose = true;
        private int timeOffset = 0;
        private TimingApp timeSource = TimingApp.NeroWaveEditor;
        private Rectangle desktopBounds = new Rectangle(-1, -1, -1, -1);

        public bool EffectMode
        {
            get { return effectMode; }
            set { effectMode = value; }
        }
        
        public bool AutoClose
        {
            get { return autoClose; }
            set { autoClose = value; }
        }
        
        public int TimeOffset
        {
            get { return timeOffset; }
            set { timeOffset = value; }
        }

        public TimingApp TimeSource
        {
            get { return timeSource; }
            set { timeSource = value; }
        }
        
        public Rectangle DesktopBounds
        {
            get { return desktopBounds; }
            set { desktopBounds = value; }
        }
    }
}
