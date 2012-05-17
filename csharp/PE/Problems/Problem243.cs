using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    internal class Problem243 : Problem
    {
        public override int Number
        {
            get { return 243; }
        }

        public override ValueType Solve()
        {
            //Debug.Assert(R(12) == 4);
            Debug.Assert(ResilientCount(12)==4);
            Debug.Assert(S(4, 10) == 12);

            return S(15499, 94744);//892371480
        }

        protected int S(ulong nom, ulong denom)
        {
            return Enumerable.Range(2, int.MaxValue - 2).AsParallel().First(d => Valid(d, nom, denom));

            for (int d = 2; d < int.MaxValue; d++)
            {
                if (Valid(d, nom, denom))
                    return d;
                //if (R(d)*denom < ((ulong) (d - 1))*nom)
                //if ((ResilientCount(d) * denom) < ((d - 1) * nom))
                    //return d;
            }

            return 0;
        }

        protected bool Valid(int d, ulong nom, ulong denom)
        {
            ulong limit = ((ulong)(d - 1))*nom;
            var sieve = new bool[d];
            ulong count = 1;

            for (int i = 2; i < d; i++)
            {
                if (!sieve[i])
                {
                    if (gcd_r(d, i) == 1)
                    {
                        count++;
                        if (count * denom >= limit)
                            return false;
                    }
                    else
                    {
                        for(int j=i+i;j<d;j+=i)
                        {
                            sieve[j] = true;
                        }
                    }
                }
            }

            return count*denom < limit;
        }

        protected ulong ResilientCount(int d)
        {
            bool[] sieve = new bool[d];
            ulong count = 1;

            for (int i = 2; i < d; i++)
            {
                if (!sieve[i])
                {
                    if (gcd_r(d, i) == 1)
                    {
                        count++;
                    }
                    else
                    {
                        for(int j=i+i;j<d;j+=i)
                        {
                            sieve[j] = true;
                        }
                    }
                }
            }

            return count;
        }

        private int gcd(int a, int b)
        {
            return gcd_r(a > b ? a : b, a < b ? a : b);
        }

        private int gcd_r(int a, int b)
        {
            return b == 0 ? a : gcd_r(b, a % b);
        }

        #region Old Code
        #if false

        protected int S(ulong nom, ulong denom)
        {
            for (int d = 2; d < int.MaxValue; d++)
            {
                //if (R(d)*denom < ((ulong) (d - 1))*nom)
                if (((ulong)Resilients(d).Count())*denom < ((ulong) (d - 1))*nom)
                    return d;
            }

            return 0;
        }

        protected ulong R(int d)
        {
            //return (ulong)Enumerable.Range(1, d - 1).AsParallel().Count(n => gcd(n, d) == 1);

            uint r = 1;

            try
            {

                bool[] sieve = new bool[d];
                
                for (int i = 2; i < d; i++)
                {
                    if (!sieve[i])
                    {
                        var g = gcd_r(d, i);

                        if (g == 1)
                            r++;
                        else
                            for (var j = i; j < d; j += g)
                                sieve[j] = true;
                    }
                }
            }
            catch(OutOfMemoryException)
            {
                for (int i = 2; i < d; i++)
                {
                    if(gcd(d,i)==1)
                    {
                        r++;
                    }
                }
            }

            return r;
        }

        protected Dictionary<int,int> ResilientCalls = new Dictionary<int, int>();
        protected Dictionary<int, long> ResilientCallTimes = new Dictionary<int, long>();
        protected const int Resilient_Cache_Limit = 5;

        protected Dictionary<int, List<int>> ReslientsRepo = new Dictionary<int, List<int>>()
                                                                 {
                                                                     {1, new List<int> {1}},
                                                                     {2, new List<int> {1}},
                                                                     {3, new List<int> {1, 2}},
                                                                     {4, new List<int> {1, 3}}
                                                                 };

        protected List<int> Resilients(int d)
        {
            //if (!ResilientCalls.ContainsKey(d))
            //    ResilientCalls[d] = 0;
            //ResilientCalls[d]++;

            //Stopwatch s = new Stopwatch();
            //s.Start();

            if (ReslientsRepo.ContainsKey(d))
                return ReslientsRepo[d];

            var result = new List<int>();
            
            List<int> a = new List<int>(),b=new List<int>();

            int m = 0;
            int i = Isqrt(d);
            while(i>1){
                if (d%i == 0)
                {
                    a = ReslientsRepo[i];
                    b = ReslientsRepo[d/i];
                    //a = Resilients(i);
                    //b = Resilients(d/i);

                    m = i;

                    break;
                }

                i--;
            }

            int ai = 0, bi = 0;
            while(ai<a.Count && bi<b.Count)
            {
                if (a[ai] == b[bi])
                {
                    result.Add(a[ai]);
                    ai++;
                    bi++;
                }
                else if(a[ai]<b[bi])
                {
                    ai++;
                }
                else
                {
                    bi++;
                }
            }

            for (i = m + 1; i < d; i++)
                if (gcd_r(d, i) == 1)
                    result.Add(i);

            //s.Stop();
            //if (!ResilientCallTimes.ContainsKey(d))
            //    ResilientCallTimes[d] = 0;
            //ResilientCallTimes[d] += s.ElapsedTicks;

            return ReslientsRepo[d] = result;
        }

        public int Isqrt(int num)
        {
            if (0 == num) { return 0; }
            int n = (num / 2) + 1;
            int n1 = (n + (num / n)) / 2;
            while (n1 < n)
            {
                n = n1;
                n1 = (n + (num / n)) / 2;
            }
            return n;
        }

        private int gcd(int a, int b)
        {
            return gcd_r(a > b ? a : b, a < b ? a : b);
        }

        private const int GCD_CACHE_LIMIT = 50;
        protected int[][] GCD = BootstrapGCD(GCD_CACHE_LIMIT);
        private static int[][] BootstrapGCD(int limit)
        {
            var gcd = new int[limit][];

            for(var a=1;a<limit;a++)
            {
                gcd[a] = new int[a];
                for (var b = 0; b<a;b++)
                {
                    int t;

                    int ta = a;
                    int tb = b;

                    while (tb != 0)
                    {
                        t = ta % tb;
                        ta = tb;
                        tb = t;
                    }

                    gcd[a][b] = ta;
                }
            }

            return gcd;
        }

        protected Dictionary<Tuple<int,int>,int> calls =new Dictionary<Tuple<int, int>, int>();
        private int gcd_r(int a, int b)
        {
            //var key = new Tuple<int, int>(a, b);
            //if (calls.ContainsKey(key))
            //    calls[key]++;
            //else
            //    calls[key] = 1;

            if (a < GCD_CACHE_LIMIT)
            {
                return GCD[a][b];
            }

            return b == 0 ? a : gcd_r(b, a%b);
        }

        private int gcd_l(int a, int b)
        {
            int t;

            if (a < b)
            {
                t = a;
                a = b;
                b = t;
            }

            while (b != 0)
            {
                t = a%b;
                a = b;
                b = t;
            }

            return a;
        }

        #endif
        #endregion
    }
}
