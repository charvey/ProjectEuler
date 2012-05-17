using System;
using System.Diagnostics;
using System.Linq;

namespace PE.Problems
{
    class Problem055:Problem
    {
        public override int Number
        {
            get { return 055; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(!IsLychrel(47));
            Debug.Assert(IsLychrel(196));
            Debug.Assert(IsLychrel(4994));

            return Enumerable.Range(1, 9999).Count(n=>IsLychrel((ulong)n));
        }

        private bool IsLychrel(ulong i)
        {
            int iterations = 0;

            do
            {
                i += Reverse(i);
                iterations++;

                if (IsPalindrome(i))
                    return false;

            } while (iterations < 50);

            return true;
        }

        private ulong Reverse(ulong n)
        {
            ulong r = 0;

            while(n>0)
            {
                r = r*10 + n%10;
                n /= 10;
            }

            return r;
        }

        private bool IsPalindrome(ulong n)
        {
            return n == Reverse(n);
        }
    }
}
