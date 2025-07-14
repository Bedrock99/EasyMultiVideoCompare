namespace EasyMultiVideoCompare
{
    public class CVideoFile
    {
        #region --- Variables ---

        public FileInfo GeneralInfo { get; private set; }

        private bool m_bBitmapsLoading = false;
        public List<Bitmap> Bitmaps { get; private set; } = new List<Bitmap>();
        public List<ulong> CompareHashes { get; private set; } = new List<ulong>();

        public VideoInformation VideoInformation { get; private set; }

        #endregion

        #region --- Constructor ---

        public CVideoFile(FileInfo pFile_)
        {
            GeneralInfo = pFile_;
        }

        #endregion

        #region --- GenerateCompareHashes ---

        public void GenerateCompareHashes()
        {
            if (CompareHashes.Count > 0)
                return;

            if (CConfig.SaveAndLoadCompareHashesOnDisk)
            {
                string strHashFileName = GeneralInfo.FullName + ".hash";
                CompareHashes = LoadULongListBinary(strHashFileName);
                if (CompareHashes.Count == 0)
                {
                    CompareHashes = VideoHasher.GetVideoHashes(GeneralInfo.FullName);
                    SaveULongListBinary(strHashFileName, CompareHashes);
                }
            }
            else
                CompareHashes = VideoHasher.GetVideoHashes(GeneralInfo.FullName);
        }

        #endregion

        #region --- Save/Load ULongListBinary ---

        public static void SaveULongListBinary(string filePath, List<ulong> data)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(data.Count);
                    foreach (ulong item in data)
                        writer.Write(item); 
                }
            }
            catch { }
        }

        public static List<ulong> LoadULongListBinary(string filePath)
        {
            List<ulong> data = new List<ulong>();
            if (!File.Exists(filePath))
                return data;

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int count = reader.ReadInt32(); 
                    for (int i = 0; i < count; i++)
                        data.Add(reader.ReadUInt64());
                }
            }
            catch { }

            return data;
        }

        #endregion

        #region --- LoadThumbnails ---

        public bool LoadThumbnails(int iHeight_)
        {
            if (m_bBitmapsLoading)
                return false;

            m_bBitmapsLoading = true;
            VideoInformation = VideoFrameReaderOpenCvSharp.GetVideoInformations(GeneralInfo.FullName);
            (int frameCount, string? errormessage) = VideoFrameReaderOpenCvSharp.GetTotalFrames(GeneralInfo.FullName);

            if (frameCount > 0)
            {
                Bitmaps.Clear();
                int iOffset = frameCount / (CConfig.PreviewBitmapCount + 2); //not at beginning or end
                for (int i = 1; i < CConfig.PreviewBitmapCount + 1; i++)
                {
                    (Bitmap bmp, errormessage) = VideoFrameReaderOpenCvSharp.ReadFrame(GeneralInfo.FullName, i * iOffset);
                    if(bmp != null)
                    {
                        bmp = new Bitmap(bmp, bmp.Size.ResizeKeepAspect(iHeight_ * 2, iHeight_ - 15));
                        Bitmaps.Add(bmp);
                    }
                }
            }

            //Set Error Images if image does not exist
            if (Bitmaps.Count < CConfig.PreviewBitmapCount)
            {
                Bitmap bmp = new Bitmap(Resources.error, Resources.error.Size.ResizeKeepAspect(iHeight_ * 2, iHeight_ - 15));
                Bitmaps.Add(bmp);
            }
            return true;
        }

        #endregion
    }
}
