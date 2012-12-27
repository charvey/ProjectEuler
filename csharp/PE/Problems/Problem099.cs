using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PE.Problems
{
    class Problem099:Problem
    {
        public override int Number
        {
            get { return 099; }
        }

        public override ValueType Solve()
        {
            var b_e =
                GetFileLines("http://projecteuler.net/project/base_exp.txt")
                .Select(l => l.Split(',').Select(n => Convert.ToInt32(n)))
                .Select(l => new { B = l.First(), E = l.Last() }).Take(10).ToArray();

            var max = 0;

            for (int l = 1; l < b_e.Length;l++ )
            {
                Console.Out.WriteLine((l+1)+"/"+b_e.Length+" #"+(max+1));
                var a = b_e[l];
                var b = b_e[max];

                Console.Out.WriteLine("\t"+a.B + "^" + a.E + " vs " + b.B + "^" + b.E);
                if (b.E < a.E)
                {
                    var t = a;
                    a = b;
                    b = t;                
                }
                Console.Out.WriteLine("\t" + a.B + "^" + a.E + " vs " + b.B + "^" + b.E);

                Console.Out.WriteLine("(" + b.B + "/" + a.B + ")^" + a.E + " * " + b.B + "^" + "(" + b.E + "-" + a.E + ")");
                Console.Out.WriteLine("(" + ((1.0*b.B)/(1.0*a.B)) + ")^" + a.E + " * " + b.B + "^" + "(" + (b.E-a.E) + ")");
                Console.Out.WriteLine("(" + ((1.0 * b.B * b.B) / (1.0 * a.B)) + ")^" + "(" + b.E + "-" + a.E + ")" + " * " + "(" + ((1.0 * b.B) / (1.0 * a.B)) + ")" + "^" + "(" + (a.E - (b.E - a.E)) + ")");
                Console.Out.WriteLine("(" + ((1.0 * b.B * b.B) / (1.0 * a.B)) + ")^" + (b.E - a.E) + " * " + "(" + ((1.0 * b.B) / (1.0 * a.B)) + ")" + "^" + "(" + (a.E - (b.E - a.E)) + ")");

                if (b.B > a.B)
                {
                    max = l;
                    continue;
                }

                double x = 1;
                for (int i=0; i < a.E; i++)
                {
                    x *= 1.0*b.B / a.B;
                }
                //Console.Out.WriteLine(x + "\t" + (1.0 * b.B) / a.B);
                if (x > 1)
                {
                    max = l;
                    continue;
                }

                for (int i=0; i < b.E - a.E; i++)
                {
                    x *= 1.0 * b.B;
                }
                //Console.Out.WriteLine(x + "\t" + a.B + "^" + a.E + " vs " + b.B + "^" + b.E);


                if (x>1)
                {
                    max = l;
                    continue;
                }
            }

            return max + 1;
        }
    }
}
