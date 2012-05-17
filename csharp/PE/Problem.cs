using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PE
{
    public abstract class Problem
    {
        public abstract int Number { get; }

        public abstract ValueType Solve();

        public override string ToString()
        {
            return string.Format("Problem {0,3}: {1}", Number, Solve());
        }

        protected string GetFileContents(string path)
        {
            var client = new WebClient();
            var reader = new StreamReader(client.OpenRead(path));
            return reader.ReadToEnd();
        }

        protected string[] GetFileLines(string path)
        {
            var client = new WebClient();
            var reader = new StreamReader(client.OpenRead(path));
            return reader.ReadToEnd().Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
        }

        private static IDictionary<int, Problem> _problems;
        public static IDictionary<int, Problem> Problems
        {
            get
            {
                if (_problems != null)
                    return _problems;

                var asm = System.Reflection.Assembly.GetExecutingAssembly();
                var types = asm.GetTypes().Where(t => t.IsSubclassOf(typeof(Problem)) && t.IsClass);
                _problems = types.Select(t => (Problem)t.GetConstructor(Type.EmptyTypes).Invoke(new object[] { })).ToDictionary(p=>p.Number);

                return _problems;
            }
        }

        public static Problem GetProblem(int i)
        {
            return Problems[i];
        }
    }
}
