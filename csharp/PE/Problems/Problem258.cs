﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem258:Problem
    {
        public override int Number
        {
            get { return 258; }
        }

        public override ValueType Solve()
        {
            var q = new Queue<ulong>();
            
            ulong i = 0;
            ulong f = 0;

            while (i < 2000)
            {
                q.Enqueue(1);
                i++;
            }

            while (i < 1000000000000000000)
            {
                f = q.Dequeue();
                f += q.Peek();

                f %= 20092010;                

                q.Enqueue(f);

                i++;
            }

            return f;
        }
    }
}
