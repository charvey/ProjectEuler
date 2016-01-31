using System;
using System.Linq;

namespace PE
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void SolveOne(int n)
        {
            Console.WriteLine(Problem.GetProblem(n));

            Console.ReadLine();
        }

        public static void SolveAll()
        {
            foreach (var key in Problem.Problems.Keys.OrderBy(k => k))
            {
                Console.WriteLine(Problem.GetProblem(key));
            }

            Console.ReadLine();
        }
    }
}
