using System;
using System.Drawing;

namespace DesignOfSCS.math
{
    class MathHelper
    {
        public const float SCALE_FACTOR = 0.1f;

        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static Point MiddlePoint(Point p1, Point p2, double r)
        {
            double dis = Distance(p1, p2);
            double k = r / dis;
            Point ret = new Point(
                (int)(k * (p1.X - p2.X) + p2.X), (int)(k * (p1.Y - p2.Y) + p2.Y)
            );
            return ret;
        }

        public static Point[] ArrowPoints(Point p1, Point p2)
        {
            double l = 7.0;
            double k = l / Math.Sqrt(3.0);
            Point p = MiddlePoint(p1, p2, l);
            Point temp = new Point(p2.Y - p.Y + p.X, p.X - p2.X + p.Y);
            Point[] ret = new Point[3];
            ret[0] = MiddlePoint(temp, p, k);
            temp = new Point(p.Y - p2.Y + p.X, p2.X - p.X + p.Y);
            ret[1] = MiddlePoint(temp, p, k);
            ret[2] = p2;
            return ret;
        }

        public static bool IsMiddle(Point p1, Point p2, Point p3)
        {
            double dis1 = Distance(p1, p2);
            double dis2 = Distance(p1, p3);
            double dis3 = Distance(p2, p3);
            return Math.Abs(dis1 + dis2 - dis3) <= 1;
        }
    }
}
