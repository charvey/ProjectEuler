using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem303:Problem
    {
        public override int Number
        {
            get { return 303; }
        }

        const int X = 10000;
        public override ValueType Solve()
        {
            var v = Values();


            return Enumerable.Range(1, X).Select(i => (uint) i).Select(i => (long)(v.First(n => n >= i && n%i == 0)/i)).Sum();

            Console.WriteLine(Enumerable.Range(1,X).AsParallel().Count(Test));
            throw new NotImplementedException();


            const int N = 10000;

            return Enumerable.Range(1, N).Sum(i=>f(i));
        }

        public IEnumerable<ulong> Values()
        {
            //const int DIGIT_LIMIT = 19;

            //ulong max = 1;

            //for(int i=0;i<DIGIT_LIMIT;i++)
            //{
            //    max *=10;
            //}

            ulong n = 0;

            while(true)
            {
                yield return n;

                for(ulong p=1;;p*=10)
                {
                    //if(p==max)
                        //yield break;

                    if(((n%(10*p)/p)<2))
                    {
                        n += p;
                        break;
                    }
                    else
                    {
                        n -= 2*p;
                        continue;
                    }
                }
            }
        }

        private bool Test(int n)
        {
            for (ulong i = (ulong)n; i <= ulong.MaxValue; i+=X)
            {
                var d = i*999;

                while (d > 0)
                {
                    if (d % 10 > 2)
                        break;

                    d /= 10;
                }

                if (d == 0)
                {
                    Console.WriteLine(i);
                    return true;
                }
            }

            return false;
        }

        private long f(int n)
        {
            foreach (uint c in Enumerable.Range(1, int.MaxValue))
            {
                ulong d = c*((ulong)n);

                while(d>0)
                {
                    if (d % 10 > 2)
                        break;
                    
                    d /= 10;
                }

                if (d == 0)
                    return c;
            }

            throw new NotImplementedException();
        }
    }
}
