using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    internal class Problem072 : Problem
    {
        public override int Number
        {
            get { return 072; }
        }

        public ValueType Solve_1()
        {
            const int D = (int)1e6;
            var p = new List<int> {2, 3};
            var F = new int[D][];

            var c = 0;
            for (var d = 2; d <= D; d++)
            {
                var x = d;
                var fd = new List<int>();
                for (var i = 0; x != 1; i++)
                {
                    if (i == p.Count)
                    {
                        var j = p.Last();
                        bool found;
                        do
                        {
                            j += 2;
                            found = true;
                            var r = Math.Sqrt(j);
                            for (var f = 3; f <= r; f += 2)
                            {
                                if (j%f == 0)
                                {
                                    found = false;
                                    break;
                                }
                            }
                        } while (!found);
                        p.Add(j);
                    }

                    if (x%p[i] == 0)
                    {
                        fd.Add(p[i]);
                        do
                        {
                            x /= p[i];
                        } while (x%p[i] == 0);
                    }
                }
                F[d] = fd.ToArray();

                c++;
                var o = d%2 == 1;
                var s = o ? 1 : 2;
                for (var n = o ? 2 : 3; n < d; n += s)
                {
                    var v = true;
                    int a = 0, b = 0;
                    while (a < F[n].Length && b < F[d].Length)
                    {
                        if (F[n][a] == F[d][b])
                        {
                            v = false;
                            break;
                        }
                        else if (F[n][a] < F[d][b])
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                    if (v)
                    {
                        c++;
                    }
                }
            }
            return c;
        }

        public override ValueType Solve()
        {
            const int D = (int)1e6;
            var p = new List<int> { 2, 3 };
            var F = new int[D][];

            ulong c = 0;
            for (var d = 2; d <= D; d++)
            {
                var x = d;
                var fd = new bool[d];
                for (var i = 0; x != 1; i++)
                {
                    if (i == p.Count)
                    {
                        var j = p.Last();
                        bool found;
                        do
                        {
                            j += 2;
                            found = true;
                            var r = Math.Sqrt(j);
                            for (var f = 3; f <= r; f += 2)
                            {
                                if (j % f == 0)
                                {
                                    found = false;
                                    break;
                                }
                            }
                        } while (!found);
                        p.Add(j);
                    }

                    if (x%p[i] == 0)
                    {
                        for (int j = p[i]; j < d; j+=p[i])
                        {
                            fd[j] = true;
                        }
                        do
                        {
                            x /= p[i];
                        } while (x%p[i] == 0);
                    }
                }
                for (int n = 1; n < d; n++)
                {
                    if (!fd[n])
                    {
                        //Console.Out.WriteLine(n + "/" + d);
                        c++;
                    }
                }
            }

            return c;
        }
    }
}
