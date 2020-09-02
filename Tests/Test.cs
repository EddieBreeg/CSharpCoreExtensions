using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Test
    {
        static void Main()
        {
            string s = "foo12";
            string s2 = "foo2";
            Console.WriteLine(s.CompareNumerically(s2));
        }
    }
}
