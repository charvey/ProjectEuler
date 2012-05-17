using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem103:Problem
    {
        public override int Number
        {
            get { return 103; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(Evalutate(NearOptimal(1)));
            Debug.Assert(Evalutate(NearOptimal(2)));
            Debug.Assert(Evalutate(NearOptimal(3)));
            Debug.Assert(Evalutate(NearOptimal(4)));
            Debug.Assert(Evalutate(NearOptimal(5)));
            Debug.Assert(Evalutate(NearOptimal(6)));
            Debug.Assert(Evalutate(new [] { 11, 18, 19, 20, 22, 25 }));
            Debug.Assert(SetString(MinS(3)) == SetString(NearOptimal(3)));
            Debug.Assert(SetString(MinS(6)) == "111819202225");

            return ulong.Parse(SetString(MinS(7)));
        }

        public int[] MinS(int n)
        {
            var no = NearOptimal(n);
            
            var possible = GenerateCandidates(n, no[0], S(no)).AsParallel().Where(Evalutate).Select(c=>new Tuple<int[],int>(c,S(c))).OrderBy(c=>c.Item2);

            return possible.First().Item1;
        }

        public IEnumerable<int[]> GenerateCandidates(int size, int s, int e)
        {
            var c = new int[size];
            
            for(var i=0;i<size;i++)
            {
                c[i] = s + i;
            }

            while(c[0]<=(e-size+1))
            {
                yield return c.ToArray();

                for(var p=size-1;size>=0;p--)
                {
                    if(c[p]<e)
                    {
                        c[p]++;
                        break;
                    }
                    else
                    {
                        c[p] = c[p-1]+1;
                    }
                }
            }
        }

        public int S(int[] set)
        {
            return set.Sum();
        }

        public int[] NearOptimal(int n)
        {
            if (n == 1)
                return new[] {1};

            var p = NearOptimal(n - 1);
            var no = new int[n];
            var b = p[p.Length/2];
            no[0]=b;

            for (var i = 1; i <= p.Length; i++)
                no[i] = p[i - 1]+b;

            return no;
        }

        public string SetString(int[] s)
        {
            return s.Aggregate(string.Empty, (curr, n) => curr + n);
        }

        public bool Evalutate(int[] s)
        {
            var subsets =
                Subsets(s).Where(subset => subset.Length > 0).Select(subset => new Tuple<int, int>(subset.Length, S(subset)))
                    .OrderBy(subset => subset.Item2).OrderBy(subset => subset.Item1).ToArray();

            for (var i = 1; i < subsets.Length; i++)
                if(subsets[i].Item2<=subsets[i-1].Item2)
                    return false;

            return true;
        }

        public int[][] Subsets(int[] s)
        {
            var count = TwoToThe(s.Length);
            var subsets = new int[count][];

            for(var subset=0;subset<count;subset++)
            {
                var bits = subset;
                var elements = new List<int>();

                foreach(var element in s)
                {
                    if((bits&1) ==1)
                        elements.Add(element);

                    bits >>= 1;
                }

                subsets[subset] = elements.ToArray();
            }

            return subsets;
        }

        public int TwoToThe(int n)
        {
            if(n==0)
                return 1;

            var n2 = TwoToThe(n / 2);

            return n%2 == 0 ? n2*n2 : 2*n2*n2;
        }
    }
}
