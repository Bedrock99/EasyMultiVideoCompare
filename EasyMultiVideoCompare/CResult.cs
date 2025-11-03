namespace EasyMultiVideoCompare
{  public class CResult
    {
        #region --- Variables and Properties ---

        public CVideoFile File { get; private set; }
        public List<CResultCompare> ComparableFiles { get; private set; } = new List<CResultCompare>();
        public double HammingDistance 
        { 
            get
            {
                return GetAvgHammingDistance();
            }
        }
  

        #endregion

        #region --- Constructor ---

        public CResult(CVideoFile mainFile)
        {
            File = mainFile;
        }

        #endregion

        #region --- Functions ---

        public void AddCompareFile(CVideoFile file, double distance, List<(int startIndex, double avgHammingDistance)> matches_)
        {
            ComparableFiles.Add(new CResultCompare(file, distance, matches_));
        }

        public double GetAvgHammingDistance()
        {
            double avg = 0;
            foreach (CResultCompare compare in ComparableFiles) 
                avg += compare.HammingDistance;

            return avg / ComparableFiles.Count;
        }

        #endregion
    }
}
