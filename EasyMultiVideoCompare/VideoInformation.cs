namespace EasyMultiVideoCompare
{
    public class VideoInformation
    {
        #region --- Variables ---

        public long Bitrate { get; private set; }
        public double FPS { get; private set; }
        public double FrameCount { get; private set; }
        public double FrameWidth { get; private set; }
        public double FrameHeight { get; private set; }
        public double Duration
        {
            get
            {
                return FrameCount / FPS;
            }
        }

        public string Resolution
        {
            get
            {
                return $"{FrameWidth}x{FrameHeight}";
            }
        }

        #endregion

        #region --- Constructor ---

        public VideoInformation(long bitrate, double fps, double framecount, double framewidth, double frameheight)
        {
            Bitrate = bitrate;
            FPS = fps;
            FrameCount = framecount;
            FrameWidth = framewidth;
            FrameHeight = frameheight;
        }

        #endregion
    }
}
