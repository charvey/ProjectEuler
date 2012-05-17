using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    internal class Problem178 : Problem
    {
        public override int Number
        {
            get { return 178; }
        }

        public override ValueType Solve()
        {
            var p = Pandigitals().ToList();

            throw new NotImplementedException();
        }

        public IEnumerable<string> Pandigitals()
        {
            return Permutations("0123456789".ToCharArray()).Select(c => new string(c.ToArray()));
        }

        public List<T[]> Permutations<T>(T[] collection)
        {
            return Permutations_r(new T[] { }, collection);
        }

        public List<T[]> Permutations_r<T>(T[] seed, T[] collection)
        {
            if (!collection.Any())
                return new List<T[]> { seed };

            var results = new List<T[]>();

            for (int i = 0; i < collection.Length; i++)
            {
                results.AddRange(Permutations_r<T>(seed.Concat(collection.Skip(i).Take(1)).ToArray(), collection.Where((n, s) => s != i).ToArray()));
            }

            return results;
        }
    }
}
