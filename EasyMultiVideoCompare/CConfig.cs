#region Using...

using System.ComponentModel;

#endregion

namespace EasyMultiVideoCompare
{
    public static class CConfig
    {
        #region --- Variables ---

        public static CRegistryConfig m_pConfig = new CRegistryConfig("EasyMultiVideoCompare");

        public static BindingList<string> CompareFolders = new BindingList<string>();
        public static List<string> SearchFileTypes = new List<string>();

        public static bool SearchRecursive;
        public static bool SaveAndLoadCompareHashesOnDisk;

        public static int PreviewBitmapCount;
        public static int PreviewBitmapSize;

        public static int MaxHammingDistance;
        public static double MinMatchRatio;

        //Video Viewer
        public static bool VideoViewer_OneImage;
        public static bool VideoViewer_SameSize;
        public static bool VideoViewer_MoveTogether;

        #endregion

        #region --- Load ---

        public static void Load()
        {
            int iCount = m_pConfig.ReadInt("CompareFolders", "Count", 0);
            for (int i = 0; i < iCount; i++)
            {
                string s = m_pConfig.Read("CompareFolders", $"Item_{i}", "");
                if (!string.IsNullOrWhiteSpace(s))
                    CompareFolders.Add(s);
            }

            SearchFileTypes.Clear();
            int nCount = m_pConfig.ReadInt("SearchFileTypes", "Count", 0);
            for (int i = 0; i < nCount; i++)
                SearchFileTypes.Add(m_pConfig.Read("SearchFileTypes", $"Item{i}", ""));
            if (SearchFileTypes.Count == 0)
                SearchFileTypes.AddRange(["mkv", "mp4", "avi", "wmv", "mpg", "flv", "m4v", "webm"]);

            SearchRecursive = m_pConfig.ReadBool("SearchRecursive", true);
            SaveAndLoadCompareHashesOnDisk = m_pConfig.ReadBool("SaveAndLoadCompareHashesOnDisk", true);

            PreviewBitmapCount = m_pConfig.ReadInt("PreviewBitmapCount", 4);
            PreviewBitmapSize = m_pConfig.ReadInt("PreviewBitmapSize", 75);

            MaxHammingDistance = m_pConfig.ReadInt("MaxHammingDistance", 8);
            MinMatchRatio = m_pConfig.ReadDouble("MinMatchRatio", 0.75);

            VideoViewer_OneImage = m_pConfig.ReadBool("VideoViewer_OneImage", true);
            VideoViewer_SameSize = m_pConfig.ReadBool("VideoViewer_SameSize", true);
            VideoViewer_MoveTogether = m_pConfig.ReadBool("VideoViewer_MoveTogether", true);
        }

        public static void LoadWindow(Form f_)
        {
            m_pConfig.LoadWindow(f_, "WINDOWS", true, true);
        }

        public static void LoadWindow(Form f_, SplitContainer[] scs_)
        {
            m_pConfig.LoadWindow(f_, "WINDOWS", true, true, scs_);
        }

        #endregion

        #region --- Save ---

        public static void Save()
        {
            m_pConfig.Write("CompareFolders", "Count", CompareFolders.Count.ToString());
            for (int i = 0; i < CompareFolders.Count; i++)
                m_pConfig.Write("CompareFolders",$"Item_{i}", CompareFolders[i]);

            m_pConfig.Write("SearchFileTypes", "Count", SearchFileTypes.Count.ToString());
            for (int i = 0; i < SearchFileTypes.Count; i++)
                m_pConfig.Write("SearchFileTypes", $"Item{i}", SearchFileTypes[i]);

            m_pConfig.Write("SearchRecursive", SearchRecursive.ToString());
            m_pConfig.Write("SaveAndLoadCompareHashesOnDisk", SaveAndLoadCompareHashesOnDisk.ToString());

            m_pConfig.Write("PreviewBitmapCount", PreviewBitmapCount.ToString());
            m_pConfig.Write("PreviewBitmapSize", PreviewBitmapSize.ToString());

            m_pConfig.Write("MaxHammingDistance", MaxHammingDistance.ToString());
            m_pConfig.Write("MinMatchRatio", MinMatchRatio.ToString());

            m_pConfig.Write("VideoViewer_OneImage", VideoViewer_OneImage.ToString());
            m_pConfig.Write("VideoViewer_SameSize", VideoViewer_SameSize.ToString());
            m_pConfig.Write("VideoViewer_MoveTogether", VideoViewer_MoveTogether.ToString());
        }

        public static void SaveWindow(Form f_)
        {
            m_pConfig.SaveWindow(f_, "WINDOWS");
        }
        public static void SaveWindow(Form f_, SplitContainer[] scs_)
        {
            m_pConfig.SaveWindow(f_, "WINDOWS", scs_);
        }

        #endregion
    }
}
