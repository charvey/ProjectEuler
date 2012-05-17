using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem087:Problem
    {
        public override int Number
        {
            get { return 087; }
        }

        private const int LIMIT = 50000000;

        public override ValueType Solve()
        {
            var collection = GenerateCollection();

            var set = new HashSet<int>();

            for (var p2 = 0; p2 < collection[0].Count; p2++)
                for (var p3 = 0; p3 < collection[1].Count; p3++)
                    for (var p4 = 0; p4 < collection[2].Count; p4++)
                        if (collection[0][p2] + collection[1][p3] + collection[2][p4] < LIMIT)
                            set.Add(collection[0][p2] + collection[1][p3] + collection[2][p4]);

            return set.Count;
        }

        protected List<int>[] GenerateCollection()
        {
            var c = new[] {new List<int>{2*2}, new List<int>{2*2*2}, new List<int>{2*2*2*2}};

            bool p2 = true, p3 = true, p4 = true;

            int i = 3;
            while(p2||p3||p4)
            {
                int x = i;
                if (p2)
                {
                    x = x*i;

                    if (x < LIMIT)
                        c[0].Add(x);
                    else
                        p2 = false;
                }
                if (p3)
                {
                    x = x * i;

                    if (x < LIMIT)
                        c[1].Add(x);
                    else
                        p3 = false;
                }
                if (p4)
                {
                    x = x * i;

                    if (x < LIMIT)
                        c[2].Add(x);
                    else
                        p4 = false;
                }

                do
                {
                    i += 2;
                } while (!i.IsPrime());
            }

            return c;
        }

    }
}
