namespace EasyMultiVideoCompare
{
    public class CResultCompare
    {
        #region --- Variables and Properties ---

        public CVideoFile File { get; private set; }
        public double HammingDistance { get; private set; }

        #endregion

        #region --- Constructor ---

        public CResultCompare(CVideoFile file, double hammingDistance)
        {
            File = file;
            HammingDistance = hammingDistance;
        }

        #endregion
    }
}
