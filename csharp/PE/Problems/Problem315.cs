using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem315 :Problem
    {
        public override int Number
        {
            get { return 315; }
        }

        private enum Segment
        {
            TopCenter,
            MiddleCenter,
            BottomCenter,
            TopLeft,
            BottomLeft,
            TopRight,
            BottomRight
        };

        protected BitArray[] DigitSegments = {
                                            //Top Center, Middle Center, Bottom Center, Top Left, Bottom Left, Top Right, Bottom Right
                                          new BitArray(new [] {true, false, true, true, true, true, true}), //0
                                          new BitArray(new [] {false, false, false, false, false, true, true}), //1
                                          new BitArray(new [] {true, true, true, false, true, true, false}), //2
                                          new BitArray(new [] {true, true, true, false, false, true, true}), //3
                                          new BitArray(new [] {false, true, false, true, false, true, true}), //4
                                          new BitArray(new [] {true, true, true, true, false, false, true}), //5
                                          new BitArray(new [] {true, true, true, true, true, false, true}), //6
                                          new BitArray(new [] {true, false, false, true, false, true, true}), //7
                                          new BitArray(new [] {true, true, true, true, true, true, true}), //8
                                          new BitArray(new [] {true, true, true, true, true, true, true})  //9
                                      };

        protected BitArray BlankSegments = new BitArray(new[] {false, false, false, false, false, false, false});

        public override ValueType Solve()
        {
            int d = 0;

            foreach (var startNumber in StartingNumbers())
            {
                var rootStream = startNumber.DigitalRootStream().ToArray();

                d += (Sam_Transitions(rootStream) - Max_Transitions(rootStream));
            }

            return d;
        }

        protected int Max_Transitions(int[] stream)
        {
            var t = Transitions(stream[0]);
            for (int i = 1; i < stream.Length; i++)
                t += Transitions(stream[i],stream[i-1]);
            t += Transitions(stream[stream.Length - 1]);
            return t;
        }

        protected int Sam_Transitions(int[] stream)
        {
            var t = 0;
            for (int i = 0; i < stream.Length; i++)
                t += 2*Transitions(stream[i]);
            return t;
        }

        protected int Transitions(int to, int? from = null)
        {
            if (!from.HasValue)
            {
                return to.Digits().Select(d => Transitions(DigitSegments[d])).Sum();
            }

            var toDigits = new Queue<int>(to.Digits());
            var fromDigits = new Queue<int>(from.Value.Digits());

            var t = 0;

            while(toDigits.Any()&&fromDigits.Any())
            {
                t += Transitions(DigitSegments[toDigits.Dequeue()], DigitSegments[fromDigits.Dequeue()]);
            }

            while(toDigits.Any())
            {
                t += Transitions(toDigits.Dequeue());
            }

            while (fromDigits.Any())
            {
                t += Transitions(fromDigits.Dequeue());
            }

            return t;
        }

        protected int Transitions(BitArray to = null, BitArray from = null)
        {
            if (to == null)
                to = BlankSegments;
            if (from == null)
                from = BlankSegments;

            var cloneTo = (BitArray) to.Clone();
            var cloneFrom = (BitArray)from.Clone();

            var diff = cloneTo.Xor(cloneFrom);

            return diff.Cast<bool>().Count(b => b);
        }

        protected IEnumerable<int> StartingNumbers()
        {
            const int A = 10000000;
            const int B = 20000000;

            for (var i = A; i <= B; i++)
                if (i.IsPrime())
                    yield return i;
        }
    }
}
