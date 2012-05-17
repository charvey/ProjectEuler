using System;
using System.Linq;

namespace PE.Problems
{
    class Problem059:Problem
    {
        public override int Number
        {
            get { return 059; }
        }

        public override ValueType Solve()
        {
            byte[] cipher = GetFileContents("http://projecteuler.net/project/cipher1.txt").Split(',').Select(c => Convert.ToByte(c)).ToArray();

            for (byte a = (int)'a'; a <= 'z'; a++)
                for (byte b = (int)'a'; b <= 'z'; b++)
                    for (byte c = (int)'a'; c <= 'z'; c++)
                    {
                        var key = new[] {a, b, c};

                        var r = Result(cipher, key);

                        if(r.All(l=>l>31 && l<123))
                        {
                            if(r.ToLower().Contains("the"))
                            {
                                return r.Sum(l=>(int)l);
                            }
                        }
                    }

            throw new NotImplementedException();
        }

        public string Result(byte[] cipher, byte[] key)
        {
            char[] text = new char[cipher.Length];

            for(int i=0;i<text.Length;i++)
            {
                text[i] = (char)(cipher[i] ^ key[i%key.Length]);
            }

            return new string(text);
        }
    }
}
