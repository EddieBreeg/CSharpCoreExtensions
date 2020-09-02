using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <name>Core</name>
    /// <summary> A class containing basic core features</summary>
    static public class Core
    {
        ///<name>SplitRange</name>
        ///<code>SplitRange(int min, int max, int divider)</code>
        ///<param name="min">The inferiour boundry of the interval to split</param>
        ///<param name="max">The superior boundry of the interval to split</param>
        ///<param name="divider">The number of subintervals to compute</param>
        ///<summary>Creates an even subdivision of the interval [min;max]</summary>
        ///<returns>An array containing the boundries of the subdivision</returns>
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
        /// <name>Range</name>
        /// <code>Range(int limit)</code>
        /// <param name="limit">The extreme value at which the sequence stops</param>
        /// <summary>Generates a sequence from 0 to limit (excluded)</summary>
        /// <returns>The sequence into a List object</returns>
        public static List<int> Range(int limit)
        {
            var seq = new List<int>();
            for (int i = 0; i != limit; i += limit.Sign()) seq.Add(i);
            return seq;
        }
        /// <name>Range</name>
        /// <code>Range(int start, int limit)</code>
        /// <param name="start">The integer from which the sequence starts</param>
        /// <param name="limit">The extreme value at which the sequence stops</param>
        /// <summary>Generates a sequence from start to limit (excluded)</summary>
        /// <returns>The sequence into a List object</returns>
        public static List<int> Range(int start, int limit)
        {
            var seq = new List<int>();
            for (int i = start; i != limit; i += limit.Sign()) seq.Add(i);
            return seq;
        }
        /// <name>Range</name>
        /// <code>Range(int start, int limit, int step)</code>
        /// <param name="start">The integer from which the sequence starts</param>
        /// <param name="limit">The extreme value at which the sequence stops</param>
        /// <param name="step">The increment</param>
        /// <summary>Generates a sequence from start to limit (excluded), incrementng by step</summary>
        /// <returns>The sequence into a List object</returns>
        public static List<int> Range(int start, int limit, int step)
        {
            var seq = new List<int>();
            if (step.Sign() == (limit - start).Sign())
            {
                for (int i = start; (limit - i).Sign() == (limit - start).Sign(); i += step)
                    seq.Add(i);
            }
            return seq;
        }
    }
    ///<name>NumericalStringComparer</name>
    ///<summary>An IComparer class to compare to numerical strings</summary>
    public class NumericalStringComparer : IComparer<string>
    {
        /// <name>Compare</name>
        /// <returns><c>a.CompareNumerically(b);</c></returns>
        /// <remarks>See the doc of the CompareNumerically
        /// extension method for more details</remarks>
        public int Compare(string a, string b)
        {
            return a.CompareNumerically(b);
        }
    }
}
