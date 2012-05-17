using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PE.Problems
{
    class Problem065:Problem
    {
        public override int Number
        {
            get { return 065; }
        }

        public override ValueType Solve()
        {
            const uint N = 100;
            //Console.WriteLine(SumDigits(f(N)));
            //Console.WriteLine(Enumerable.Range(1, 100).First(i => n((uint)i) < n((uint)i - 1)));
            Debug.Assert(SumDigits(n_u(10))==17);
            Debug.Assert(SumDigits(n_d(10)) == 17);
            Debug.Assert(SumDigits(n_b(10)) == 17);
            return SumDigits(n_b(N));
        }

        private BigInteger gcd(BigInteger a, BigInteger b)
        {
            return BigInteger.GreatestCommonDivisor(a, b);
        }

        private ulong gcd(ulong a, ulong b)
        {
            return gcd_r(a > b ? a : b, a < b ? a : b);
        }

        private decimal gcd(decimal a, decimal b)
        {
            return gcd_r(a > b ? a : b, a < b ? a : b);
        }

        private decimal gcd_r(decimal a, decimal b)
        {
            return b == 0 ? a : gcd_r(b, a % b);
        }

        private ulong gcd_r(ulong a, ulong b)
        {
            return b == 0 ? a : gcd_r(b, a % b);
        }

        private ulong f(uint i)
        {
            ulong n = t(i), d = 1;
            i--;

            while (i >= 1)
            {
                var temp = n;
                n = n * t(i) + d;
                d = temp;

                i--;

                temp = gcd(n, d);

                n /= temp;
                d /= temp;
            }

            return n;
        }

        private ulong n_u(uint i)
        {
            ulong n2 = 1;
            ulong n1 = t(1);
            ulong n = 0;

            if (i == 0)
                n = n2;
            if (i == 1)
                n = n1;

            for (uint j = 2; j <= i; j++)
            {
                checked
                {
                    n = t(j)*n1 + n2;
                }
                n2 = n1;

                var g = gcd(n1, n);
                n = n / g;

                n1 = n;
            }

            return n;
        }

        private decimal n_d(uint i)
        {
            decimal n2 = 1;
            decimal n1 = t(1);
            decimal n = 0;

            if (i == 0)
                n = n2;
            if (i == 1)
                n = n1;

            for (uint j = 2; j <= i; j++)
            {
                checked
                {
                    n = t(j) * n1 + n2;
                }
                n2 = n1;

                var g = gcd(n1, n);
                n = n / g;

                n1 = n;
            }

            return n;
        }

        private BigInteger n_b(uint i)
        {
            BigInteger n2 = 1;
            BigInteger n1 = t(1);
            BigInteger n = 0;

            if (i == 0)
                n = n2;
            if (i == 1)
                n = n1;

            for (uint j = 2; j <= i; j++)
            {
                checked
                {
                    n = t(j) * n1 + n2;
                }
                n2 = n1;

                var g = gcd(n1, n);
                n = n / g;

                n1 = n;
            }

            return n;
        }

        private ulong n_u_r(uint i)
        {
            if (i == 0)
                return 1;
            if (i == 1)
                return t(1);

            return t(i) * n_u_r(i - 1) + n_u_r(i - 2);
        }

        private uint t(uint i)
        {
            if (i == 1)
                return 2;
            if (i % 3 == 0)
                return (i / 3) * 2;

            return 1;
        }

        private uint SumDigits(ulong n)
        {
            uint s = 0;

            while (n > 0)
            {
                s += ((uint)(n % 10));
                n /= 10;
            }

            return s;
        }

        private uint SumDigits(decimal n)
        {
            Debug.Assert(n%1==0);

            uint s = 0;

            while (n > 0)
            {
                s += ((uint)(n % 10));
                n /= 10;
            }

            return s;
        }

        private uint SumDigits(BigInteger n)
        {
            Debug.Assert(n % 1 == 0);

            uint s = 0;

            while (n > 0)
            {
                s += ((uint)(n % 10));
                n /= 10;
            }

            return s;
        }
    }
}
