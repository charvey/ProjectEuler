using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem029:Problem
    {
        public override int Number
        {
            get { return 029; }
        }

        public override ValueType Solve()
        {
            var set = new HashSet<ReducedNumber>(new Comparer());

            for (int a = 2; a <= 100; a++)
                for (int b = 2; b <= 100; b++)
                    set.Add(new ReducedNumber(a, b));

            return set.Count;
        }

        protected class ReducedNumber
        {
            public Dictionary<int, int> _data = new Dictionary<int, int>();

            public ReducedNumber(int a,int b)
            {
                _data[a] = b;

                Reduce();
            }

            private void Reduce()
            {
                while(true)
                {
                    var key = _data.Keys.FirstOrDefault(k => !k.IsPrime());
                    
                    if(key==default(int))
                        return;

                    for(int f=2;f*f<=key;f++)
                    {
                        if(key%f==0)
                        {
                            if (!_data.ContainsKey(f))
                                _data[f] = 0;
                            _data[f] += _data[key];
                            if (!_data.ContainsKey(key/f))
                                _data[key/f] = 0;
                            _data[key/f] += _data[key];

                            _data.Remove(key);
                            break;
                        }
                    }
                }
            }
        }

        protected class Comparer:IEqualityComparer<ReducedNumber>
        {
            public bool Equals(ReducedNumber x, ReducedNumber y)
            {
                if (x._data.Count != y._data.Count)
                    return false;

                foreach (var key in x._data.Keys)
                {
                    if(!(y._data.ContainsKey(key)&&x._data[key]==y._data[key]))
                        return false;
                }

                return true;
            }

            public int GetHashCode(ReducedNumber obj)
            {
                return obj._data.Keys.Sum()*obj._data.Values.Sum();
            }
        }
    }
}
