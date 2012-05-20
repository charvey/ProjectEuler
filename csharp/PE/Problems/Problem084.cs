using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem084 : Problem
    {
        public override int Number
        {
            get { return 084; }
        }

        public override ValueType Solve()
        {
            const int TRIALS = 1000000;
            const int DICE_SIZE = 4;
            const int BOARD_SIZE = 40;
            const int JAIL = 10;
            const int G2J = 30;
            const int CC1 = 2, CC2 = 17, CC3 = 33;
            const int CH1 = 7, CH2 = 22, CH3 = 36;
            const int U1 = 12, U2 = 28;

            int?[] CC = new int?[]{0,10,null,null,null,null,null,null,null,null,null,null,null,null,null,null};
            int?[] CH = new int?[] { 0, 10, 11, 24, 39, 5, -1, -1, -2, -3, null, null, null, null, null, null };
            int ccPos= 0;
            int chPos = 0;
            int[] landing = new int[BOARD_SIZE];
            Random rand = new Random();
            
            int pos = 0;
            int doubleCount = 0;
            for (int i = 0; i < TRIALS; i++)
            {
                int d1 = rand.Next(1, DICE_SIZE + 1);
                int d2 = rand.Next(1, DICE_SIZE + 1);

                if (d1 == d2)
                    doubleCount++;
                else
                    doubleCount = 0;

                pos = (pos + d1 + d2) % BOARD_SIZE;

                if (pos == G2J || (d1 == d2 && doubleCount == 3))
                {
                    pos = JAIL;
                    doubleCount = 0;
                }
                else if(pos==CC1||pos==CC2 || pos==CC3)
                {
                    int? m = CC[ccPos];

                    if (m.HasValue)
                    {
                        pos = m.Value;
                    }

                    ccPos = (ccPos + 1) % CC.Length;
                }
                else if (pos == CH1 || pos == CH2 || pos == CH3)
                {
                    int? m = CH[chPos];

                    if (m.HasValue)
                    {
                        if (m.Value >= 0)
                            pos = m.Value;
                        else
                        {
                            if (m.Value == -1)
                                pos = (pos / 10) * 10 + 5;
                            else if (m.Value == -2)
                                if (pos == CH2)
                                    pos = U2;
                                else
                                    pos = U1;
                            else if (m.Value == -3)
                                pos -= 3;
                        }
                    }

                    chPos = (chPos + 1) % CH.Length;
                }

                pos = (pos+BOARD_SIZE)%BOARD_SIZE;
                landing[pos]++;
            }

            int m1=0, m2=0, m3=0;

            for (int mi = 0; mi < BOARD_SIZE; mi++)
            {
                if (landing[mi] > landing[m1])
                {
                    m3 = m2;
                    m2 = m1;
                    m1 = mi;
                }
                else if (landing[mi] > landing[m2])
                {
                    m3 = m2;
                    m2 = mi;
                }
                else if (landing[mi] > landing[m3])
                {
                    m3 = mi;
                }
            }

            return m1 * 10000 + m2 * 100 + m3;
        }
    }
}
