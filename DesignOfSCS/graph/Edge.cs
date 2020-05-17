using DesignOfSCS.math;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesignOfSCS.graph
{
    class Edge : GraphObject
    {
        public const int FONT_SIZE = 14;
        private Node from;
        public Node From { get { return from; } set { from = value; } }

        private Node to;
        public Node To { get { return to; } set { to = value; } }

        private int weight;
        public int Weight { get { return weight; } set { weight = value; } }

        private Point MidPoint { get; set; }

        public Edge(Node _from, Node _to, int _weight = 0)
        {
            from = _from;
            to = _to;
            weight = _weight;
        }

        public override void Draw(Graphics e, int num = 0)
        {
            int k = 50;
            Point startPoint = MathHelper.MiddlePoint(to.Position, from.Position, Node.NODE_SIZE / 2);
            Point endPoint = MathHelper.MiddlePoint(from.Position, to.Position, Node.NODE_SIZE / 2);

            Pen pen = new Pen(State == State.Normal ? Color.Black : Color.Lime, 2);
            Point temp = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Point midPoint;
            if (num % 2 == 0)
            {
                k = k * (num / 2);
                Point x = new Point(startPoint.Y - temp.Y + temp.X, temp.X - startPoint.X + temp.Y);
                midPoint = MathHelper.MiddlePoint(x, temp, k);
                double angle = Math.Atan2(midPoint.Y - temp.Y, midPoint.X - temp.X) * 180.0 / Math.PI;
                if (angle <= 0 || angle > 180.0)
                {
                    x = new Point(temp.Y - startPoint.Y + temp.X, startPoint.X - temp.X + temp.Y);
                    midPoint = MathHelper.MiddlePoint(x, temp, k);
                }
            }
            else
            {
                k = k * ((num + 1) / 2);
                Point x = new Point(startPoint.Y - temp.Y + temp.X, temp.X - startPoint.X + temp.Y);
                midPoint = MathHelper.MiddlePoint(x, temp, k);
                double angle = Math.Atan2(midPoint.Y - temp.Y, midPoint.X - temp.X) * 180.0 / Math.PI;
                if (angle > 0 && angle <= 180.0)
                {
                    x = new Point(temp.Y - startPoint.Y + temp.X, startPoint.X - temp.X + temp.Y);
                    midPoint = MathHelper.MiddlePoint(x, temp, k);
                }
            }


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
            Point[] arrowPoints = MathHelper.ArrowPoints(midPoint, endPoint);

           // e.FillClosedCurve(State == State.Normal ? Brushes.Black : Brushes.Lime, arrowPoints);
            MidPoint = midPoint;
        }

        public Edge(){}


        public override bool IsOnHover(MouseEventArgs e)
        {
            Point startPoint = MathHelper.MiddlePoint(to.Position, from.Position, Node.NODE_SIZE / 2);
            Point endPoint = MathHelper.MiddlePoint(from.Position, to.Position, Node.NODE_SIZE / 2);
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
