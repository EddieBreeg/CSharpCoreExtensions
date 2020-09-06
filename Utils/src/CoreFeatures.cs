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
            var subs = Range(min, max + 1).ToList().Split(divider);
            foreach(int i in Range(divider))
            {
                result[2 * i] = subs[i][0];
                result[2 * i + 1] = subs[i][^1];
            }
            return result;
        }
        /// <name>Range</name>
        /// <code>Range(int limit)</code>
        /// <param name="limit">The extreme value at which the sequence stops</param>
        /// <summary>Generates a sequence from 0 to limit (excluded)</summary>
        /// <returns>The sequence into a IEnumerable object</returns>
        public static IEnumerable<int> Range(int limit) => Range(0, limit, Math.Sign(limit));
        /// <name>Range</name>
        /// <code>Range(int start, int limit)</code>
        /// <param name="start">The integer from which the sequence starts</param>
        /// <param name="limit">The extreme value at which the sequence stops</param>
        /// <summary>Generates a sequence from start to limit (excluded)</summary>
        /// <returns>The sequence into a IEnumerable object</returns>
        public static IEnumerable<int> Range(int start, int limit) => Range(start, limit, Math.Sign(limit - start));
        /// <name>Range</name>
        /// <code>Range(int start, int limit, int step)</code>
        /// <param name="start">The integer from which the sequence starts</param>
        /// <param name="limit">The extreme value at which the sequence stops</param>
        /// <param name="step">The increment</param>
        /// <summary>Generates a sequence from start to limit (excluded), incrementng by step</summary>
        /// <returns>The sequence into a IEnumerable object</returns>
        public static IEnumerable<int> Range(int start, int limit, int step)
        {
            //var seq = new List<int>();
            if (Math.Sign(step) == Math.Sign(limit - start))
            {
                for (int i = start; Math.Sign(limit - i) == Math.Sign(limit - start); i += step)
                    yield return i;
            }
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
