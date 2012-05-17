using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem099:Problem
    {
        public override int Number
        {
            get { return 099; }
        }

        public override ValueType Solve()
        {
            var b_e =
                GetFileLines("http://projecteuler.net/project/base_exp.txt").Select(
                    l => l.Split(',').Select(n => Convert.ToInt32(n))).Select(
                        l => new Tuple<int, int>(l.First(), l.Last())).ToArray();

            var line = 0;

            for (int l = 1; l < b_e.Length;l++ )
            {
                int b1 = b_e[line].Item1,
                    b2 = b_e[l].Item1,
                    e1 = b_e[line].Item2,
                    e2 = b_e[l].Item2,
                    minE = Math.Min(e1, e2),
                    diff = b1 - b2;

                



                if (true/*COMPARE*/)
                {
                    line = l;
                }
            }

            return line + 1;
        }
    }
}
