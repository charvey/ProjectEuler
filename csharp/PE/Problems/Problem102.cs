using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem102:Problem
    {
        public override int Number
        {
            get { return 102; }
        }

        public override ValueType Solve()
        {
            return GetFileLines("http://projecteuler.net/project/triangles.txt").AsParallel().Count();
        }

        public bool ContainsOrigin(string line)
        {
            var vals = line.Split(',').Select(v => Convert.ToInt32(v)).ToArray();

            int Ax, Ay, Bx, By, Cx, Cy, mABx, mABy, mACx, mACy, mBCx, mBCy;

            Ax = vals[0];
            Ay = vals[1];
            Bx = vals[2];
            By = vals[3];
            Cx = vals[4];
            Cy = vals[5];

            mABx = (Ax + Bx)/2;
            mABy = (Ay + By)/2;
            mACx = (Ax + Cx)/2;
            mACy = (Ay + Cy)/2;
            mBCx = (Bx + Cx)/2;
            mBCy = (By + Cy)/2;



            throw new NotImplementedException();
        }

        public int max(int a,int b)
        {
            return a > b ? a : b;
        }

        public int min(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
