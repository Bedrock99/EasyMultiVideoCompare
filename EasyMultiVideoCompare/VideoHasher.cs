#region Using...

using OpenCvSharp;
using System.Diagnostics;

#endregion

namespace EasyMultiVideoCompare
{
    public class VideoHasher
    {
        #region --- ComputeAHash ---

        /// <summary>
        /// Computes a simple AHash (Average Hash) for an image (frame).
        /// The hash is robust to scaling because the image is resized before computation.
        /// </summary>
        /// <param name="image">The image (frame) as a Mat object.</param>
        /// <param name="hashSize">The size of the hash (e.g., 8 for 8x8 pixels).</param>
        /// <returns>A 64-bit hash or 0 if the image is empty.</returns>
        public static ulong ComputeAHash(Mat image, int hashSize = 8)
        {
            if (image.Empty()) return 0;

            // 1. Convert image to grayscale and resize it
            using (Mat gray = new Mat())
            using (Mat resized = new Mat())
            {
                Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
                // Use INTER_AREA for downsampling (good for images)
                Cv2.Resize(gray, resized, new OpenCvSharp.Size(hashSize, hashSize), interpolation: InterpolationFlags.Area);

                // 2. Calculate the average pixel intensity
                double average = Cv2.Mean(resized).Val0;

                // 3. Compute the hash: 1 if pixel > average, else 0
                ulong hash = 0;
                byte[] pixels = new byte[hashSize * hashSize];
                resized.GetArray(out pixels); // Read pixel values into an array

                for (int i = 0; i < pixels.Length; i++)
                {
                    if (pixels[i] > average)
                    {
                        hash |= (1UL << (pixels.Length - 1 - i)); // Set the bit
                    }
                }
                return hash;
            }
        }

        #endregion

        #region --- GetVideoHashes ---

        /// <summary>
        /// Computes a sequence of AHashes for a video.
        /// </summary>
        /// <param name="videoPath">Path to the video file.</param>
        /// <param name="sampleRate">How often to compute a hash (e.g., 1 for every frame, 5 for every 5th frame).</param>
        /// <param name="hashSize">Size of the hash (e.g., 8).</param>
        /// <returns>A list of computed hashes.</returns>
        public static List<ulong> GetVideoHashes(string videoPath, int sampleRate = 5, int hashSize = 8)
        {
            List<ulong> hashes = new List<ulong>();
            using (VideoCapture capture = new VideoCapture(videoPath))
            {
                if (!capture.IsOpened())
                {
                    Console.WriteLine($"Error: Could not open video '{videoPath}'.");
                    return hashes;
                }

                using (Mat frame = new Mat())
                {
                    long currentFrame = 0;
                    while (capture.Read(frame) && !frame.Empty())
                    {
                        if (currentFrame % sampleRate == 0)
                        {
                            hashes.Add(ComputeAHash(frame, hashSize));
                        }
                        currentFrame++;
                    }
                }
            }
            return hashes;
        }

        #endregion

        #region --- GetHammingDistance ---

        /// <summary>
        /// Calculates the Hamming distance between two hashes.
        /// </summary>
        /// <param name="hash1"></param>
        /// <param name="hash2"></param>
        /// <returns>The number of differing bits.</returns>
        public static int GetHammingDistance(ulong hash1, ulong hash2)
        {
            ulong xorResult = hash1 ^ hash2;
            int distance = 0;
            while (xorResult > 0)
            {
                xorResult &= (xorResult - 1); // Clears the least significant set bit
                distance++;
            }
            return distance;
        }

        #endregion

        #region --- FindClipInVideo ---

        /// <summary>
        /// Searches for a subsequence of hashes (clip) within a larger hash sequence (main video).
        /// Returns a list of potential matches (start index in the main video, average Hamming distance).
        /// </summary>
        /// <param name="mainVideoHashes">Hashes of the longer video.</param>
        /// <param name="clipHashes">Hashes of the shorter clip/segment to find.</param>
        /// <param name="maxHammingDistanceThreshold">Maximum allowed Hamming distance per hash pair for a match.</param>
        /// <param name="minMatchRatio">Minimum ratio of matching hashes within the sliding window.</param>
        /// <returns>A list of tuples: (start index in main video hash sequence, average Hamming distance of the match).</returns>
        public static List<CHashMatch> FindClipInVideo(
            List<ulong> mainVideoHashes, List<ulong> clipHashes,
            int maxHammingDistanceThreshold = 8, double minMatchRatio = 0.75, int sampleRate = 5)
        {
            List<CHashMatch> matches = new List<CHashMatch>();

            if (clipHashes.Count == 0 || mainVideoHashes.Count < clipHashes.Count)
            {
                return matches;
            }

            // Sliding window comparison
            for (int i = 0; i <= mainVideoHashes.Count - clipHashes.Count; i++)
            {
                int currentMatchCount = 0;
                double currentHammingSum = 0;

                for (int j = 0; j < clipHashes.Count; j++)
                {
                    int hammingDist = GetHammingDistance(mainVideoHashes[i + j], clipHashes[j]);
                    if (hammingDist <= maxHammingDistanceThreshold)
                    {
                        currentMatchCount++;
                        currentHammingSum += hammingDist;
                    }
                }

                double matchRatio = (double)currentMatchCount / clipHashes.Count;
                if (matchRatio >= minMatchRatio)
                {
                    int iBegin = i * sampleRate;
                    //TODO Begin and end not right
                    //19 at begin, 17 at end in first video (Min1To2)
                    //48 at begin, 47 at end in second video (Min2To210)
                    matches.Add(new CHashMatch(
                        iBegin,
                        iBegin + clipHashes.Count * sampleRate, 
                        currentHammingSum / currentMatchCount));
                }
            }
            return matches;
        }

        #endregion
    }
}
