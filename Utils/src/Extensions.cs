﻿using System.Collections.Generic;

namespace System.Linq
{
    /// <name>ListExtensions</name>
    /// <summary>
    /// A collection of extension methods for List objects
    /// </summary>
    public static class ListExtensions
    {
        /// <name>SplitList</name>
        /// <code>SplitList(List lst, int count)</code>
        /// <summary>
        /// Splits the list into `count` sublists
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<List<T>> Split<T>(this List<T> lst, int count)
        {
            var result = new List<List<T>>();
            for (int i = 0; i < count; i++)
                result.Add(lst.GetRange(i * lst.Count / count, lst.Count / count));
            if (!result[^1].Contains(lst[^1])) result[^1].Add(lst[^1]);
            return result;
        }
        public static List<T> DeepCopy<T>(this List<T> lst)
        {
            var result = new List<T>();
            lst.ForEach(x => result.Add(x));
            return result;
        }
        public static List<T> WithoutIndex<T>(this List<T> lst, int index)
        {
            var result = new List<T>();
            for (int i = 0; i < lst.Count; i++)
                if (i != index)
                    result.Add(lst[i]);
            return result;
        }
        public static List<T> Sorted<T>(this List<T> lst)
        {
            var result = DeepCopy(lst);
            result.Sort();
            return result;
        }
        public static bool IsPermutation(this List<int> lst)
        {
            var copy = lst.Sorted();
            for (int i = 0; i < copy.Count; i++)
                if (copy[i] != i) return false;
            return true;
        }
        public static List<T> Permute<T>(this List<T> lst, List<int> lut)
        {
            if (lst.Count != lut.Count || !lut.IsPermutation()) throw new ArgumentException();
            return lut.Select(x => lst[x]).ToList();
        }
        public static List<int> FlipPermutation(this List<int> lut)
        {
            if (!lut.IsPermutation()) throw new FormatException("List is not a permutation");
            return lut.Select(x => lut[x]).ToList();
        }
        public static int CompareTo(this int[] a, int[] b)
        {
            var range = a.Length < b.Length ? a.Length : b.Length;
            for (int i = 0; i < range; i++)
                if (a[i] != b[i]) return a[i].CompareTo(b[i]);
            return a.Length.CompareTo(b.Length);
        }
    }
    public static class StringExtensions
    {
        public static List<int> FindNumbers(this string str)
        {
            var copy = "";
            var digits = "0123456789";
            foreach (char c in str)
                copy += digits.Contains(c) ? c : ' ';
            var result = new List<int>();
            return copy.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
        }
        internal static IEnumerable<int> ToIntEnumerable(this string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!"0123456789".Contains(s[i]))
                    yield return ((int) s[i]);
                else
                {
                    string n = "";
                    while (i < s.Length && "0123456789".Contains(s[i]))
                    {
                        n += s[i];
                        i++;
                    }
                    yield return Convert.ToInt32(n);
                }
            }
        }
        public static int CompareNumerically(this string str, string other)
        {
            var a = str.ToIntEnumerable();
            var b = other.ToIntEnumerable();
            var range = a.Count() < b.Count() ? a.Count() : b.Count();
            for (int i = 0; i < range; i++)
                if (a.ElementAt(i) != b.ElementAt(i)) return a.ElementAt(i).CompareTo(b.ElementAt(i));
            return a.Count().CompareTo(b.Count());
        }
    }
    public static class IntExtensions
    {
        public static int Sign(this int x) => Math.Sign(x);
        public static int? Sign(this int? x) => x!=null?Math.Sign((int)x) : 0;
    }
}
