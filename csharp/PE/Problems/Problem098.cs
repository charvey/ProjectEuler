using System;
using System.Collections.Generic;
using System.Linq;

namespace PE.Problems
{
    class Problem098:Problem
    {
        public override int Number
        {
            get { return 098; }
        }

        public override ValueType Solve()
        {
            var words = GetFileContents("http://projecteuler.net/project/words.txt").Split(',').Select(w => w.Trim('"'));
            var anagrams = words.GroupBy(w => new string(w.OrderBy(c => c).ToArray())).Where(g => g.Count() > 1).Select(g => g.ToArray());
            
            var anagramPairs = new List<Tuple<string, string>>();
            foreach (var anagram in anagrams)
            {
                for (int i = 0; i < anagram.Length-1;i++ )
                {
                    for (int j = i + 1; j < anagram.Length; j++)
                    {
                        anagramPairs.Add(new Tuple<string, string>(anagram[i],anagram[j]));
                    }
                }
            }

            int max = int.MinValue;
            foreach (var anagramPair in anagramPairs)
            {
                int l = (int)Math.Ceiling(Math.Sqrt(Math.Pow(10, anagramPair.Item1.Length - 1)));
                int h = (int) Math.Floor(Math.Sqrt(Math.Pow(10, anagramPair.Item1.Length) - 1));
                for (int s = l; s <= h; s++)
                {
                    string s1 = ""+s*s;

                    var x = new[] {'\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0'};

                    bool unique = true;
                    for(int i=0;i<s1.Length;i++)
                    {
                        if (x[s1[i]-'0'] != '\0')
                        {
                            unique = false;
                        }
                        x[s1[i] - '0'] = anagramPair.Item1[i];
                    }
                    if (!unique)
                    {
                        continue;
                    }

                    string s2 = "";
                    for (int i = 0; i < s1.Length; i++)
                    {
                        s2 += s1[anagramPair.Item1.IndexOf(anagramPair.Item2[i])];
                    }

                    if (s2[0] == '0')
                    {
                        continue;
                    }

                    if (Math.Sqrt(int.Parse(s2))%1 == 0)
                    {
                        max = Math.Max(max, Math.Max(int.Parse(s1), int.Parse(s2)));
                    }
                }
            }

            return max;
        }
    }
}
