using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Test
    {
        static void Main()
        {
            foreach (int x in Core.SplitRange(0, 99, 3)) Console.WriteLine(x);
        }
    }
}
