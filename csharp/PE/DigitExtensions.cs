using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE
{
    public static class DigitExtensions
    {
        public static int DigitCount(this int n)
        {
            return (int)Math.Ceiling(Math.Log10(n + 0.1));
        }

        public static IEnumerable<int> Digits(this int n)
        {
            var v = n;
            while(v>0)
            {
                yield return v%10;
                v /= 10;
            }
        }

        public static IEnumerable<int> Digits(this long n)
        {
            var v = n;
            while (v > 0)
            {
                yield return (int)(v % 10);
                v /= 10;
            }
        }

        public static IEnumerable<int> Digits(this ulong n)
        {
            var v = n;
            while (v > 0)
            {
                yield return (int)(v % 10);
                v /= 10;
            }
        }

        public static uint DigitSum(this ulong n)
        {
            var v = n;
            uint s = 0;
            while (v > 0)
            {
                s += (uint)(v%10);
                v /= 10;
            }
            return s;
        }

        public static int DigitalRoot(this int n)
        {
            return n.Digits().Sum();
        }

        public static IEnumerable<int> DigitalRootStream(this int n)
        {
            int ndr = n;
            do
            {
                n = ndr;
                yield return n;
                ndr = n.DigitalRoot();
            } while (n != ndr);
        }
    }
}
