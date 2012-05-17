using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem169:Problem
    {
        public override int Number
        {
            get { return 169; }
        }

        public override ValueType Solve()
        {
            return f(10);
        }

        private long f(long n)
        {
            if(n==1)
                return 0;

            var s = Convert.ToString(n, 2);
            var l = s.Length-1;

            var num = s.Select(c => c == '1' ? 1 : 0).Select((v, i) => v*(int) Math.Pow(2, l - i)).Where(i=>i!=0).ToList();

            return Count(num);
        }

        private int Count(List<int> x)
        {
            int count = 1;

            for (var i = 0; i < x.Count;i++)
            {
                if(x[i]!=1 && !x.Contains(x[i]/2))
                {
                    var y = x.ToList();
                    y[i] /= 2;
                    y.Insert(i, y[i]);
                    count += Count(y);
                }
            }

            return count;
        }
    }
}
