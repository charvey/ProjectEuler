using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem277:Problem
    {
        public override int Number
        {
            get { return 277; }
        }

        private char[] TestSequence = "UDDDUdddDDUDDddDdDddDDUDDdUUDd".ToCharArray();
        //private char[] TestSequence = "DdDddUUdDD".ToCharArray();

        public override ValueType Solve()
        {
            const ulong start = 1000000000000000;
            //const ulong start = 1000000;

            ulong startIndex = start + (3 - start % 3) % 3;
            startIndex += (uint)(new List<char> { 'D', 'U', 'd' }).IndexOf(TestSequence[0]);
            for (ulong i = startIndex; i < ulong.MaxValue; i += 3)
                if (Valid(i))
                    return i;

            throw new NotImplementedException();
        }

        public bool Valid(ulong a)
        {
            int l = TestSequence.Length;
            char d = ' ';
            for (int i = 0; i < l; i++)
            {
                switch (a%3)
                {
                    case 0:
                        d = 'D';
                        a /= 3;
                        break;
                    case 1:
                        d= 'U';
                        a = (4*a + 2)/3;
                        break;
                    case 2:
                        d = 'd';
                        a = (2*a - 1)/3;
                        break;
                }
                if(d!=TestSequence[i])
                    return false;
            }

            return true;
        }

        public IEnumerable<char> Sequence(int a)
        {
            while (a != 1)
            {
                switch (a%3)
                {
                    case 0:
                        yield return 'D';
                        a /= 3;
                        break;
                    case 1:
                        yield return 'U';
                        a = (4*a + 2)/3;
                        break;
                    case 2:
                        yield return 'd';
                        a = (2*a - 1)/3;
                        break;
                }
            }
        }
    }
}
