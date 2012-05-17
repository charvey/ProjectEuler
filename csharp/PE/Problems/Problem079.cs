using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PE.Problems
{
    class Problem079:Problem
    {
        public override int Number
        {
            get { return 079; }
        }

        public override ValueType Solve()
        {
            var keylogs = GetFileLines("http://projecteuler.net/project/keylog.txt");

            for (int key = 0; key < int.MaxValue; key++)
            {
                var digits = Digits(key);
                for (int keylog = 0; keylog <= keylogs.Length; keylog++)
                {
                    if (keylog == keylogs.Length)
                        return key;

                    int j = 0;
                    for (int i = 0; j < 3 && i < digits.Length; i++)
                        if (keylogs[keylog][j] == digits[i])
                            j++;
                    if(j!=3)
                        break;
                }
            }

            throw new NotImplementedException();
        }

        protected char[] Digits(int n)
        {
            return ("" + n).ToArray();
        }
    }
}
