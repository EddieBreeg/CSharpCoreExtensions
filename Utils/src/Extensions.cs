using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace System.Linq
{
    /// <name>ListExtensions</name>
    /// <summary>
    /// A collection of extension methods for List objects
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <name>Split</name>
        /// <code>Split(List lst, int count)</code>
        /// <summary>
        /// Splits the list into `count` sublists
        /// </summary>
        /// <param name="count">The number of sublists to create</param>
        /// <param name="lst">The list object to split</param>
        /// <returns></returns>
        public static List<List<T>> Split<T>(this List<T> lst, int count)
        {
            var result = new List<List<T>>();
            for (int i = 0; i < count; i++)
                result.Add(lst.GetRange(i * lst.Count / count, lst.Count / count));
            if (!result[^1].Contains(lst[^1])) result[^1].Add(lst[^1]);
            return result;
        }
        /// <name>WithoutIndex</name>
        /// <code>
        /// WithoutIndex(this List lst, int index)
        /// </code>
        /// <summary>
        /// Generates a version of the list without item at `index` 
        /// </summary>
        /// <typeparam name="T">The type of List object</typeparam>
        /// <param name="lst">The List to remove the item from</param>
        /// <param name="index">The index of the item to remove</param>
        /// <returns>`lst` in which item at `index` has been removed</returns>
        public static List<T> WithoutIndex<T>(this List<T> lst, int index)
        {
            if (index > lst.Count) throw new IndexOutOfRangeException($"Index {index} doesn't exist in the list");
            var result = new List<T>();
            for (int i = 0; i < lst.Count; i++)
                if (i != index) result.Add(lst[i]);
            return result;
        }
        /// <name>Sorted</name>
        /// <code>Sorted(this List lst, IComparer comparer=null)</code>
        /// <summary>
        /// Returns the sorted version of `lst` using either the default comparer, or the comparer passed as an argument
        /// </summary>
        /// <param name="lst">The List to sort</param>
        /// <param name="comparer">IComparer object for the sort algorithm to use</param>
        /// <returns>The sorted version of `lst`</returns>
        public static List<T> Sorted<T>(this List<T> lst, IComparer<T> comparer=null)
        {
            var result = lst.DeepCopy();
            result.Sort();
            return result;
        }
        /// <name>IsPermutation</name>
        /// <code>IsPermutation(this List lst)</code>
        /// <summary>
        /// Tests if `lst` represents a mathematical permutation of the integers from 0 to `lst.Count-1`
        /// </summary>
        /// <param name="lst">The List of integers to test</param>
        /// <example>{1, 2, 0, 4, 3} is a permutation, but {2,3,1} and {1,2,4} are not</example>
        /// <returns>The boolean result of the test</returns>
        public static bool IsPermutation(this List<int> lst)
        {
            var copy = lst.Sorted();
            for (int i = 0; i < copy.Count; i++)
                if (copy[i] != i) return false;
            return true;
        }
        /// <name>Permute</name>
        /// <code>List Permute(this List lst, List lut)</code>
        /// <summary>
        /// Applies the permutation represented by `lut` to `lst`
        /// </summary>
        /// <typeparam name="T">The type of the List to permute</typeparam>
        /// <param name="lst">The List to permute</param>
        /// <param name="lut">The lookup table to use for the permutation</param>
        /// <returns>The permuted version of the list</returns>
        /// <remarks>If `lut.IsPermutation!=true || lut.Count != lst.Count`, a FormatException will be thrown</remarks>
        public static List<T> Permute<T>(this List<T> lst, List<int> lut)
        {
            if (lst.Count != lut.Count || !lut.IsPermutation()) throw new FormatException();
            return lut.Select(x => lst[x]).ToList();
        }
        /// <name>FlipPermutation</name>
        /// <code>FlipPermutation(this List lut)</code>
        /// <summary>
        /// Flips the permutation represented by `lut` 
        /// (which corresponds to doing `lut.Permute(lut)`
        /// </summary>
        /// <param name="lut">The List object representing the permutation</param>
        /// <returns>The flipped version of `lut`</returns>
        /// <remarks>If `lut.IsPermutation == false`, a FormatException will be thrown</remarks>
        public static List<int> FlipPermutation(this List<int> lut)
        {
            if (!lut.IsPermutation()) throw new FormatException("List is not a permutation");
            return lut.Select(x => lut[x]).ToList();
        }
        /// <name>CompareTo</name>
        /// <code>CompareTo(this int[] a, int[] b)</code>
        /// <summary>
        /// Compares to int[] value by value
        /// </summary>
        /// <param name="a">This instance</param>
        /// <param name="b">The other int[] to compare `this` to</param>
        /// <returns>An integer indicating the relative values of `a` and `b`:
        /// -1 if ais less than b, 1 if a is greater than b, 0 if a is equal to b</returns>
        public static int CompareTo(this int[] a, int[] b)
        {
            var range = a.Length < b.Length ? a.Length : b.Length;
            for (int i = 0; i < range; i++)
                if (a[i] != b[i]) return a[i].CompareTo(b[i]);
            return a.Length.CompareTo(b.Length);
        }
        public static T[] GetRange<T>(this T[] array, int index, int count)
        {
            var result = new T[count];
            for (int i = 0; i < count; i++)
                result[i] = array[index + i];
            return result;
        }
    }
    /// <name>StringExtensions</name>
    /// <summary>
    /// A collection of extension methods for string objects
    /// </summary>
    public static class StringExtensions
    {
        /// <name>FindNumbers</name>
        /// <code>FindNumbers(this string str)</code>
        /// <summary>
        /// Searches all the numrical values in `str`
        /// </summary>
        /// <param name="str">The string to search in</param>
        /// <returns>An int[] containing all the values</returns>
        public static int[] FindNumbers(this string str)
        {
            var copy = "";
            var digits = "0123456789";
            foreach (char c in str)
                copy += digits.Contains(c) ? c : ' ';
            while (copy.Contains("  "))
                copy = copy.Replace("  ", " ");
            return copy.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        }
        /// <name>ToIntEnumerable</name>
        /// <code>ToIntEnumerable(this string s)</code>
        /// <summary>
        /// Converts the string to a set of integers by converting each char to its numerical value 
        /// and evaluating any potential number
        /// </summary>
        /// <example>"foo1".ToIntEnumerable() = {102, 111, 111, 1}</example>
        /// <param name="s">The string to iterate through</param>
        /// <returns>An IEnumerable object generating the values</returns>
        /// <remarks>This method is internal and shouldn't be used directly. It is only there to be used by the 
        /// CompareNumerically method</remarks>
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
        /// <name>Indent</name>
        /// <code>Indent(this string str, int level = 4)</code>
        /// <summary>
        /// Pads each line of `str` by adding `level` spaces to its left
        /// </summary>
        /// <param name="str">The string to indent</param>
        /// <param name="level">The number of spaces to add</param>
        /// <returns>The indented version of `str`</returns>
        public static string Indent(this string str, int level = 4)
        {
            var indent = "";
            for (int i = 0; i< level; i++) indent += ' ';
            return string.Join('\n', str.Split('\n').Select(x => indent + x));
        }
        /// <name>CompareNumerically</name>
        /// <code>CompareNumerically(this string str, string other)</code>
        /// <summary>
        /// Compares strings which might contain numbers and returns an indication of their relative values
        /// </summary>
        /// <param name="str">This instance</param>
        /// <param name="other">The string to compare to</param>
        /// <returns>A signed integer indicating the relative values of `this` and `other`:
        /// -1 if `this` is smaller than `other`, 1 if `this` is greater than `other`, 0 if they're equal</returns>
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
   
    /// <name>ObjectExtensions</name>
    /// <summary>
    /// A collection of extension methods for any type of object
    /// </summary>
    public static class ObjectExtensions
    {
        /// <name>DeepCopy(this T obj)</name>
        /// <summary>
        /// Creates a copy of `obj`
        /// </summary>
        /// <typeparam name="T">The actual type of `obj`</typeparam>
        /// <param name="obj">The object to be copied</param>
        /// <returns>A `T` object copy of `obj`</returns>
        /// <remarks>The `T` class has to be marked as [Serializable] for this function to work</remarks>
        public static T DeepCopy<T>(this T obj)
        {
            using(var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
