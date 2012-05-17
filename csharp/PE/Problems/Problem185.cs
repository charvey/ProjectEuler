using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    internal class Problem185 : Problem
    {
        public override int Number
        {
            get { return 185; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(new Dictionary<ulong, int>
                               {
                                   {90342, 2},
                                   {70794, 0},
                                   {39458, 2},
                                   {34109, 1},
                                   {51545, 2},
                                   {12531, 1}
                               }) == 39542);

            return S(new Dictionary<ulong, int>
                         {
                             {5616185650518293, 2},
                             {3847439647293047, 1},
                             {5855462940810587, 3},
                             {9742855507068353, 3},
                             {4296849643607543, 3},
                             {3174248439465858, 1},
                             {4513559094146117, 2},
                             {7890971548908067, 3},
                             {8157356344118483, 1},
                             {2615250744386899, 2},
                             {8690095851526254, 3},
                             {6375711915077050, 1},
                             {6913859173121360, 1},
                             {6442889055042768, 2},
                             {2321386104303845, 0},
                             {2326509471271448, 2},
                             {5251583379644322, 2},
                             {1748270476758276, 3},
                             {4895722652190306, 1},
                             {3041631117224635, 3},
                             {1841236454324589, 3},
                             {2659862637316867, 2}
                         }
                );
        }

        public ulong S(Dictionary<ulong,int > g)
        {
            return S_3(g);
        }

        public ulong S_3(Dictionary<ulong, int> g)
        {
            var guesses = g.OrderBy(i => i.Value);

            throw new NotImplementedException();
        }

        public int CorrectCount(ulong n, ulong guess)
        {
            int count = 0;
            while(n>0)
            {
                if (n % 10 == guess % 10)
                    count++;
            }
            return count;
        }

        public ulong S_2(Dictionary<ulong, int> g)
        {
            ulong start = 1;
            ulong stop = 10;
            int digitCount =1;

            while (stop<g.First().Key)
            {
                start *= 10;
                stop *= 10;
                digitCount++;
            }

            int guessCount = g.Count;
            ulong[] guesses = g.Keys.ToArray();
            int[] corrects = g.Values.ToArray();
            ulong[] diffs = new ulong[g.Count];
            int[] matches = new int[g.Count];

            for(ulong i=start;i<stop;i++)
            {
                for (int d = 0; d < guessCount; d++)
                {
                    diffs[d] = i > guesses[d] ? i - guesses[d] : guesses[d] - i;
                    matches[d] = 0;
                }

                for (int d = 0; d < digitCount; d++)
                {
                    if (diffs[d] % 10 == 0)
                        matches[d]++;
                    diffs[d] /= 10;
                }

                for (int d = 0; d <= guessCount; d++)
                {
                    if (d == guessCount)
                        return i;

                    if(matches[d]!=corrects[d])
                        break;
                }
            }

            throw new NotImplementedException();
        }

        public ulong S_1(Dictionary<ulong, int> guesses)
        {
            ulong start = 1;
            ulong stop = 10;
            while(stop<guesses.First().Key)
            {
                start *= 10;
                stop *= 10;
            }

            var poss = new List<ulong>();

            foreach (var g in guesses.Take(1))
            {
                ulong guess = g.Key;
                int correct = g.Value;

                for (ulong i = start; i < guess; i++)
                {
                    ulong diff = guess - i;
                    int count = 0;

                    while (diff > 0)
                    {
                        if (diff%10 == 0)
                        {
                            count++;
                            if (count > correct)
                            {
                                //continue to for loop
                                diff = 0;
                            }
                        }

                        diff /= 10;
                    }

                    if (count == correct)
                        poss.Add(i);

                }
                for (ulong i = guess + 1; i < stop; i++)
                {
                    ulong diff = i - guess;
                    int count = 0;

                    while (diff > 0)
                    {
                        if (diff%10 == 0)
                        {
                            count++;
                            if (count > correct)
                            {
                                //continue to for loop
                                diff = 0;
                            }
                        }

                        diff /= 10;
                    }

                    if (count == correct)
                        poss.Add(i);
                }
            }

            foreach (var g in guesses.Skip(1))
            {
                ulong guess = g.Key;
                int correct = g.Value;

                foreach (var p in poss)
                {
                    ulong diff = p > guess ? p - guess : guess - p;
                    int count = 0;

                    while (diff > 0)
                    {
                        if (diff%10 == 0)
                        {
                            count++;
                            if (count > correct)
                            {
                                //continue to for loop
                                diff = 0;
                            }
                        }

                        diff /= 10;
                    }

                    if (count != correct)
                        poss.Remove(p);
                }
            }

            Debug.Assert(poss.Count==1);

            return poss.Single();
        }

        
    }
}
