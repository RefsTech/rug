using System;

namespace Rug.Domain.Match.MatchReferees.MatchLimits
{
    public class RangeLimit : ILimit
    {
        public RangeLimit(int min, int max)
        {
            if (Min > Max)
            {
                throw new ArgumentOutOfRangeException("Range: Min is higher than Max");
            }
            Min = min;
            Max = max;
        }

        public int Min { get; }

        public int Max { get; }

        public bool IsInMaxRange(int number) {
            return number >= 0 && number <= Max;
        }

        public bool IsValid(int number)
        {
            return number >= Min && number <= Max;
        }
    }
}