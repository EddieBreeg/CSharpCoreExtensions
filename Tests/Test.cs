using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    //public static class Program
    //{ 
    //    static void Main()
    //    {
    //        Console.WriteLine(InputHandler.IntInput("x: "));
    //    }
    //}
    public class CoreTests
    {
        [Fact]
        static void Range1()
        {
            Assert.Equal(new List<int>() { 0, 1, 2, 3, 4 }, Core.Range(5).ToList());
        }
        [Fact]
        static void Range2()
        {
            Assert.Equal(Core.Range(1, 5),
                new List<int>() { 1, 2, 3, 4 });
        }
        [Fact]
        static void Range3()
        {
            Assert.Equal(Core.Range(1, 5, 2),
                new List<int>() { 1, 3 });
        }
        [Fact]
        static void Range4()
        {
            Assert.Equal(Core.Range(2, -3), new List<int>() { 2, 1, 0, -1, -2 });
        }

        [Fact]
        static void Range5()
        {
            Assert.Equal(Core.Range(2, 0, 1), new List<int>() { });
        }
        [Fact]
        static void SplitRange1()
        {
            Assert.Equal(new int[] { 0, 32, 33, 65, 66, 99 }, Core.SplitRange(0, 99, 3));
        }
        [Fact]
        static void SplitRange2()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Core.SplitRange(0, 0, 3));
        }
    }
    public class NumericalStringComparerTests
    {
        [Fact]
        static void Test1()
        {
            Assert.True("foo2".CompareNumerically("foo12") == -1);
        }
        [Fact]
        static void Test2()
        {
            List<string> lst = new List<string>() { "foo23", "foo10" };
            Assert.Equal(lst.Sorted(new NumericalStringComparer()), new List<string>() { "foo10", "foo23" });
        }
    }
    public class ListExtensionsTests
    {
        [Fact]
        static void Split1()
        {
            var expected = new List<List<int>>()
            {
                new List<int>(){0,1,2},
                new List<int>(){3,4,5},
                new List<int>(){6,7,8}
            };
            Assert.Equal(Core.Range(9).ToList().Split(3), expected);
        }
        [Fact]
        static void Split2()
        {
            var expected = new List<List<int>>()
            {
                new List<int>(){0,1,2},
                new List<int>(){3,4,5},
                new List<int>(){6,7,8, 9}
            };
            Assert.Equal(Core.Range(10).ToList().Split(3), expected);
        }
        [Fact]
        static void WithoutIndex1()
        {
            var lst = new List<string>() { "foo", "epico", "yeet" };
            Assert.Equal(lst.WithoutIndex(1), new List<string>() { "foo", "yeet" });
        }
        [Fact]
        static void WithoutIndex2()
        {
            var lst = new List<string>() { "foo", "epico", "yeet" };
            Assert.Throws<IndexOutOfRangeException>(()=>lst.WithoutIndex(10));
        }
        [Fact]
        static void Sorted()
        {
            var lst = new List<int>() { 3, 2, 1 };
            Assert.Equal(lst.Sorted(), Core.Range(1, 4));
        }
        [Fact]
        static void IsPermutation()
        {
            var lst = new List<int>() { 0, 2, 1, 4, 3 };
            Assert.True(lst.IsPermutation());
        }
        [Fact]
        static void IsPermutation2()
        {
            Assert.True(!(new List<int>(new int[] { 1, 2, 4 }).IsPermutation()));
        }
        [Fact]
        static void Permute()
        {
            Assert.Equal(
                (new List<int>(new int[] { 0, 2, 4 })).Permute(new List<int>() { 2, 1, 0 }),
                new List<int>() { 4, 2, 0 });
        }
        [Fact]
        static void Permute2()
        {
            var lut = new List<int>() { 1, 2, 3 }; //isn't a permutation
            var lst = new List<char>() { 'a', 'b', 'c' };
            Assert.Throws<FormatException>(() => lst.Permute(lut));
        }
        [Fact]
        static void Permute3()
        {
            var lst = new List<char>() { 'a', 'b', 'c' };
            var lut = new List<int>() { 0, 1, 2, 3 }; //lut isn't the same length as lst
            Assert.Throws<FormatException>(() => lst.Permute(lut));
        }
        [Fact]
        static void FlipPermutation()
        {
            var lut = new List<int>() { 0, 4, 5 };
            Assert.Throws<FormatException>(()=>lut.FlipPermutation());
        }
        [Fact]
        static void FlipPermutation2()
        {
            var lut = new List<int>() { 0, 2, 1, 3 };
            Assert.Equal(lut.FlipPermutation(), new List<int>() { 0, 1, 2, 3 });
        }
        [Fact]
        static void CompareArrays1()
        {
            int[] a = new int[] { 0, 1, 2 };
            Assert.Equal(a.CompareTo(new int[] { 0, 1, 3 }), -1);
        }
        [Fact]
        static void CompareArrays2()
        {
            var a = new int[] { 0, 1, 2, 3 };
            Assert.Equal(a.CompareTo(new int[] { 0, 1, 2, 3, 4 }), -1);
        }
        [Fact]
        static void FindNumbers() => Assert.Equal("25foo1".FindNumbers(), new int[] { 25, 1 });
    }
    public class DeepCopyTest
    {
        [Fact]
        static void Test()
        {
            var lst = Core.Range(10).ToList();
            Assert.True(lst != lst.DeepCopy());
        }
    }
}
