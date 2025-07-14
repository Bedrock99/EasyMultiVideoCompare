namespace EasyMultiVideoCompare
{
    public static  class CExtensions
    {
        #region --- ResizeKeepAspect (Size) ---

        public static Size ResizeKeepAspect(this Size src, int maxWidth, int maxHeight, bool enlarge = false)
        {
            maxWidth = enlarge ? maxWidth : Math.Min(maxWidth, src.Width);
            maxHeight = enlarge ? maxHeight : Math.Min(maxHeight, src.Height);

            decimal rnd = Math.Min(maxWidth / (decimal)src.Width, maxHeight / (decimal)src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }

        #endregion

        #region --- Contains2 (Video in Result) ---

        public static bool Contains2(this List<CResult> lst_, CVideoFile pSearch1_)
        {
            foreach (CResult s in lst_)
            {
                if (s.File.GeneralInfo.FullName == pSearch1_.GeneralInfo.FullName)
                {
                   return true;
                }
            }

            return false;
        }

        #endregion
    }
}
