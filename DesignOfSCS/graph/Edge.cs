using DesignOfSCS.math;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesignOfSCS.graph
{
    /// <summary>
    /// Класс описывающий ребро графа
    /// </summary>
    class Edge : GraphObject
    {
        public bool IsMinE { get; set; }
        public const int FONT_SIZE = 14;
        public Node From { get; set; }
        public Node To { get; set; }
        public double Weight { get; set; }

        private Point MidPoint { get; set; }

        /// <summary>
        /// Конструктор класс
        /// </summary>
        /// <param name="_from">1 вершина</param>
        /// <param name="_to">2 вершина</param>
        /// <param name="_weight">вес</param>
        public Edge(Node _from, Node _to, int _weight = 0)
        {
            From = _from;
            To = _to;
            Weight = _weight;
            IsMinE = false;
        }

        /// <summary>
        /// Метод отрисовки ребра
        /// </summary>
        /// <param name="e">Объект Graphics для рисования</param>
        /// <param name="num">Количество ребер</param>
        public override void Draw(Graphics e, int num = 0)
        {
            int k = 50;
            Point startPoint = MathHelper.MiddlePoint(To.Position, From.Position, Node.NODE_SIZE / 2);
            Point endPoint = MathHelper.MiddlePoint(From.Position, To.Position, Node.NODE_SIZE / 2);

            Pen pen = new Pen(State == State.Normal ? Color.Black : Color.Lime, 2);
            if (IsMinE)
            {
                pen = new Pen(Color.Red,5);
                IsMinE = false;
            }
            Point temp = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Point midPoint;
            //     if (num % 2 == 0)
            //        {
            //          k = k * (num / 2);
                k = 0;
                Point x = new Point(startPoint.Y - temp.Y + temp.X, temp.X - startPoint.X + temp.Y);
                midPoint = MathHelper.MiddlePoint(x, temp, k);
                double angle = Math.Atan2(midPoint.Y - temp.Y, midPoint.X - temp.X) * 180.0 / Math.PI;
                if (angle <= 0 || angle > 180.0)
                {
                    x = new Point(temp.Y - startPoint.Y + temp.X, startPoint.X - temp.X + temp.Y);
                    midPoint = MathHelper.MiddlePoint(x, temp, k);
                }
     //       }
        //    else
       //     {
       //         k = k * ((num + 1) / 2);
        //        Point x = new Point(startPoint.Y - temp.Y + temp.X, temp.X - startPoint.X + temp.Y);
       //         midPoint = MathHelper.MiddlePoint(x, temp, k);
        //        double angle = Math.Atan2(midPoint.Y - temp.Y, midPoint.X - temp.X) * 180.0 / Math.PI;
          //      if (angle > 0 && angle <= 180.0)
         //       {
         //           x = new Point(temp.Y - startPoint.Y + temp.X, startPoint.X - temp.X + temp.Y);
      //            midPoint = MathHelper.MiddlePoint(x, temp, k);
        //        }
       //     }


            if (Weight != 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Font f = new Font("Consolas", FONT_SIZE, FontStyle.Regular);
                e.DrawString(Weight.ToString(), f, State == State.Normal ? Brushes.Black : Brushes.Lime, midPoint, sf);
                SizeF size = e.MeasureString(Weight.ToString(), f);
                float r = Math.Max(size.Width, size.Height);
                Point p1 = MathHelper.MiddlePoint(startPoint, midPoint, r);
                Point p2 = MathHelper.MiddlePoint(endPoint, midPoint, r);
                e.DrawLine(pen, startPoint, p1);
                e.DrawLine(pen, p2, endPoint);
            }
            else
            {
                e.DrawLine(pen, startPoint, midPoint);
                e.DrawLine(pen, midPoint, endPoint);
            }
          
            MidPoint = midPoint;
        }

        public Edge(){}


        public override bool IsOnHover(MouseEventArgs e)
        {
            Point startPoint = MathHelper.MiddlePoint(To.Position, From.Position, Node.NODE_SIZE / 2);
            Point endPoint = MathHelper.MiddlePoint(From.Position, To.Position, Node.NODE_SIZE / 2);
            return MathHelper.IsMiddle(e.Location, startPoint, MidPoint)
                || MathHelper.IsMiddle(e.Location, endPoint, MidPoint);
        }

        public override void OnMouseHover(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnMouseLeave(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
