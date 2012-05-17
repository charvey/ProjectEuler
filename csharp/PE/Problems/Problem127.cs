using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    internal class Problem127 : Problem
    {
        public override int Number
        {
            get { return 127; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(rad(504) == 42);
            Debug.Assert(Valid(5, 27, 32));
            Debug.Assert(Valid_(5, 27, 32));
            Debug.Assert(S(1000) == 12523);

            return S(120000);
        }

        public Problem127()
        {
            var primes = new List<uint> {2};
            for (uint i = 3; primes.Count < PrimeListSize || NextPrime == 0; i += 2)
            {
                if(i.IsPrime())
                {
                    if (primes.Count < PrimeListSize)
                        primes.Add(i);
                    else
                        NextPrime = i;
                }
            }

            Primes = primes.ToArray();
        }

        private const int PrimeListSize = 10000;
        private readonly uint[] Primes;
        private readonly uint NextPrime;

        public uint S(int n)
        {
            uint s = 0;

            for (uint c = 0; c < n; c++)
            {
                for (uint b = 1; b < c/2; b++)
                {
                    uint a = c - b;

                    if (Valid(a, b, c))
                        s += c;
                }
            }

            return s;
        }

        public bool Valid_(uint a, uint b, uint c)
        {
            return (gcd(b, c) == 1 && gcd(a, b) == 1 && gcd(a, c) == 1 && rad(a*b*((ulong) c)) < c);
        }

        public bool Valid(uint a, uint b, uint c)
        {
            ulong p = a*b*((ulong) c);
            ulong r = 1;

            for (uint i = 0; i < PrimeListSize && p > 1 && r < c; i++)
            {
                uint prime = Primes[i];

                if (p % prime == 0)
                {
                    if (a % prime == 0 && b % prime == 0 && c % prime == 0)
                        return false;

                    do
                    {
                        p /= prime;
                    } while (p % prime == 0);

                    r *= prime;
                }
            }

            for (uint i = NextPrime; p > 1 && r < c; i += 2)
            {
                if (p%i == 0)
                {
                    if (a % i == 0 && b % i == 0 && c % i == 0)
                        return false;

                    do
                    {
                        p /= i;
                    } while (p%i == 0);

                    r *= i;
                }
            }

            return r < c;
        }

        public uint gcd(uint a, uint b)
        {
            return gcd_r(a > b ? a : b, a > b ? b : a);
        }

        public uint gcd_r(uint a, uint b)
        {
            return b == 0 ? a : gcd_r(b, a%b);
        }

        public uint rad(ulong n)
        {
            if (n%2 == 0)
            {
                do
                {
                    n /= 2;
                } while (n%2 == 0);

                return 2*rad_r(n);
            }

            return rad_r(n);
        }

        public uint rad_r(ulong n, uint s=3)
        {
            for (uint i = s; n > 1; i += 2)
            {
                if (n % i == 0)
                {
                    do
                    {
                        n /= i;
                    } while (n % i == 0);

                    return i*rad_r(n, s + 2);
                }
            }

            return 1;
        }
    }
}
