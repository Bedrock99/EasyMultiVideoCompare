#region Using...

using OpenCvSharp;

#endregion

namespace EasyMultiVideoCompare
{
    public class VideoFrameReaderOpenCvSharp
    {
        #region --- GetTotalFrames ---

        public static (int frameCount, string? errormessage) GetTotalFrames(string videoPath)
        {
            using (VideoCapture capture = new VideoCapture(videoPath))
            {
                if (!capture.IsOpened())
                {
                    MessageBox.Show($"Fehler: Video '{videoPath}' konnte nicht geöffnet werden.");
                    return (-1, $"Video '{videoPath}' could not be opened.");
                }

                double frameCount = capture.Get(VideoCaptureProperties.FrameCount);

                return ((int)frameCount, "");
            }
        }

        #endregion

        #region --- ReadFrame ---

        public static (Bitmap bitmap, string? errormessage) ReadFrame(string videoPath, int frameIndexToRead)
        {
            using (VideoCapture capture = new VideoCapture(videoPath))
            {
                if (!capture.IsOpened())
                {
                    return (null, $"Video '{videoPath}' could not be opened.");
                }

                capture.PosFrames = frameIndexToRead;
                using (Mat frame = new Mat())
                {
                    capture.Read(frame); 
                    if (!frame.Empty())
                    {
                        return (OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame), "");
                    }
                    else
                    {
                        return (null, $"Could not read frame {frameIndexToRead} from '{videoPath}'.");
                    }
                }
            }
        }

        #endregion

        #region --- GetVideoInformations ---

        public static VideoInformation GetVideoInformations(string videoPath)
        {
            using (var cap = new VideoCapture(videoPath))
            {
                if (!cap.IsOpened())
                    return null;

                return new VideoInformation(
                    Convert.ToInt64(cap.Get(VideoCaptureProperties.BitRate) * 1000.0), //from kbits to bits
                    cap.Get(VideoCaptureProperties.Fps),
                    cap.Get(VideoCaptureProperties.FrameCount),
                    cap.Get(VideoCaptureProperties.FrameWidth),
                    cap.Get(VideoCaptureProperties.FrameHeight)
                    );
            } 
        }

        #endregion
    }
}
