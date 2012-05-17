using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem043:Problem
    {
        public override int Number
        {
            get { return 043; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(Valid(1406357289));
            return Pandigitals().Where(Valid).Sum();
        }

        public bool Valid(long n)
        {
            return 
            (((n/0000001)%1000)%17 == 0) &&
            (((n/0000010)%1000)%13 == 0) &&
            (((n/0000100)%1000)%11 == 0) &&
            (((n/0001000)%1000)%07 == 0) &&
            (((n/0010000)%1000)%05 == 0) &&
            (((n/0100000)%1000)%03 == 0) &&
            (((n/1000000)%1000)%02 == 0);
        }

        public IEnumerable<long> Pandigitals()
        {
            return Permutations("0123456789".ToCharArray()).Select(c=>Convert.ToInt64(new string(c.ToArray())));
        }

        public List<T[]> Permutations<T>(T[] collection)
        {
            return Permutations_r(new T[] {}, collection);
        }

        public List<T[]> Permutations_r<T>(T[] seed, T[] collection)
        {
            if (!collection.Any())
                return new List<T[]> {seed};

            var results = new List<T[]>();

            for (int i = 0; i < collection.Length;i++)
            {
                results.AddRange(Permutations_r<T>(seed.Concat(collection.Skip(i).Take(1)).ToArray(), collection.Where((n, s) => s != i).ToArray()));
            }

            return results;
        }
    }
}
