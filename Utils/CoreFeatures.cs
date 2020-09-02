using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    static public class Core
    {
        public static int[] SplitRange(int min, int max, int divider)
        {
            var result = new int[divider * 2];
            var range = max - min + 1;
            for(int i=0; i<divider;i++)
                result[2 * i] = min + range / divider * i + 1;
            for (int i = 0; i < divider - 1; i++)
                result[2 * i + 1] = result[2 * i + 2] - 1;
            result[0] = min;
            result[^1] = max;
            return result;
        }
        public static List<int> Range(int limit)
        {
            var seq = new List<int>();
            for (int i = 0; i != limit; i += limit.Sign()) seq.Add(i);
            return seq;
        }
        public static List<int> Range(int start, int limit)
        {
            var seq = new List<int>();
            for (int i = start; i != limit; i += limit.Sign()) seq.Add(i);
            return seq;
        }
        public static List<int> Range(int start, int limit, int step)
        {
            var seq = new List<int>();
            if (step.Sign() == (limit - start).Sign())
            {
                for (int i = start; i != limit && (limit - i).Sign() == (limit - start).Sign(); i += step)
                    seq.Add(i);
            }
            return seq;
        }
    }
    public class NumericalStringComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return a.CompareNumerically(b);
        }
    }
}
