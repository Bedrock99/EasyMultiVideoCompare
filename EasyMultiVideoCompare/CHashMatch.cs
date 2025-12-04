using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMultiVideoCompare
{
    public class CHashMatch
    {
        public int StartHashNumber { get; private set; }
        public int HashCount { get; private set; }
        public double HammingDistance { get; private set; }

        public CHashMatch(int startHashNumber_, int hashCount_, double hammingDistance_)
        {
            StartHashNumber = startHashNumber_;
            HashCount = hashCount_;
            HammingDistance = hammingDistance_;
        }
    }
}
