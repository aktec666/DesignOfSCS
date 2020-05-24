using System;
using System.Drawing;

namespace DesignOfSCS.math
{
    /// <summary>
    /// Дополнительная биьлиотека для расчета элементов отрисовки
    /// </summary>
    class MathHelper
    {
        public const float SCALE_FACTOR = 0.1f;

        /// <summary>
        /// Расстояние между 2 точками
        /// </summary>
        /// <param name="p1">1 координата</param>
        /// <param name="p2">2 координата</param>
        /// <returns></returns>
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }


        /// <summary>
        /// Определение средней точки между 2 вершина с известным радиусом
        /// </summary>
        /// <param name="p1">1 координата</param>
        /// <param name="p2">2 координата</param>
        /// <param name="r">Радиус объектов</param>
        /// <returns></returns>
        public static Point MiddlePoint(Point p1, Point p2, double r)
        {
            double dis = Distance(p1, p2);
            double k = r / dis;
            Point ret = new Point(
                (int)(k * (p1.X - p2.X) + p2.X), (int)(k * (p1.Y - p2.Y) + p2.Y)
            );
            return ret;
        }

        /// <summary>
        /// Для расчета при наведении курсора
        /// </summary>
        /// <param name="p1">1 координата</param>
        /// <param name="p2">2 координата</param>
        /// <param name="p3">3 координата</param>
        /// <returns></returns>
        public static bool IsMiddle(Point p1, Point p2, Point p3)
        {
            double dis1 = Distance(p1, p2);
            double dis2 = Distance(p1, p3);
            double dis3 = Distance(p2, p3);
            return Math.Abs(dis1 + dis2 - dis3) <= 1;
        }
    }
}
