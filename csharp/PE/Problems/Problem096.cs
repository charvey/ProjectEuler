using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem096 : Problem
    {
        public override int Number
        {
            get { return 096; }
        }

        private struct Cell
        {
            public int Value;
            public List<int> Possibilities;
        }

        private class Puzzle
        {
            public Cell[,] Cells;

            public Puzzle(string[] d)
            {
                Cells = new Cell[9, 9];

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var c = d[i + 1][j];

                        if (c == '0')
                        {
                            Cells[i, j] = new Cell
                                {
                                    Value = 0,
                                    Possibilities = Enumerable.Range(1, 9).ToList()
                                };
                        }
                        else
                        {
                            Cells[i, j] = new Cell
                                {
                                    Value = c - '0',
                                    Possibilities = new List<int>()
                                };
                        }
                    }
                }
            }

            public override string ToString()
            {
                var str = string.Empty;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        str += Cells[i, j].Value;
                    }
                    str += "\n";
                }

                return str;
            }

            public void Solve()
            {
                bool changed;
                do
                {
                    changed = false;

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            var v = Cells[i, j].Value;
                            if (v != 0)
                            {
                                Cells[i, j].Possibilities.Clear();
                                for (int k = 0; k < 9; k++)
                                {
                                    //Console.Out.WriteLine(k + ": (" + i + "," + j + ") (" + (3 * (i / 3) + k / 3) + "," + (3 * (j / 3) + k % 3) + ")");
                                    foreach (var spot in new[]
                                        {
                                            new Tuple<int, int>(i, k),
                                            new Tuple<int, int>(k, j),
                                            new Tuple<int, int>(3*(i/3) + k/3, 3*(j/3) + k%3)
                                        })
                                    {
                                        Cells[spot.Item1, spot.Item2].Possibilities.Remove(v);

                                        if (Cells[spot.Item1, spot.Item2].Possibilities.Count == 1)
                                        {
                                            changed = true;
                                            Cells[spot.Item1, spot.Item2].Value = Cells[spot.Item1, spot.Item2].Possibilities[0];
                                        }
                                    }
                                }
                            }
                        }
                    }

                } while (changed);
            }
        }

        public override ValueType Solve()
        {
            var lines = GetFileLines("http://projecteuler.net/project/sudoku.txt").Take(05 * 10).ToList();
            var puzzles = new Puzzle[lines.Count / 10];
            for (var i = 0; i < lines.Count; i += 10)
            {
                puzzles[i / 10] = new Puzzle(lines.Skip(i).Take(10).ToArray());
            }

            int sum = 0;
            foreach (var puzzle in puzzles)
            {
                Console.Out.WriteLine("Puzzle:\n" + puzzle);
                puzzle.Solve();
                Console.Out.WriteLine("Answer:\n" + puzzle);
                Console.In.ReadLine();
                sum += 100 * puzzle.Cells[0, 0].Value + 10 * puzzle.Cells[0, 1].Value + 1 * puzzle.Cells[0, 2].Value;
            }

            return sum;
        }
    }
}
