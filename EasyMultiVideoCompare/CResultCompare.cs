namespace EasyMultiVideoCompare
{
    public class CResultCompare
    {
        #region --- Variables and Properties ---

        public CVideoFile File { get; private set; }
        public double HammingDistance { get; private set; }
        public List<(int startIndex, double avgHammingDistance)> Matches { get; private set; }

        #endregion

        #region --- Constructor ---

        public CResultCompare(CVideoFile file, double hammingDistance, List<(int startIndex, double avgHammingDistance)> matches_)
        {
            File = file;
            HammingDistance = hammingDistance;
            Matches = matches_;
        }

        #endregion
    }
}
