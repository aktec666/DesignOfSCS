using DesignOfSCS.math;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesignOfSCS.graph
{
    class Node : GraphObject
    {
        public const int NODE_SIZE = 60;
        public const int FONT_SIZE = 20;

        public int Id { get; set; }

        public Point Position { get; set; }

        public string Name { get; set; }

        public Point TopLeft
        {
            get
            {
                return new Point(Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2);
            }
        }

        public Node(int id, int x, int y)
        {
            Id = id;
            Name = id.ToString();
            Position = new Point(x, y);
        }

        public Node(int id)
        {
            Id = id;
            Name = id.ToString();
        }


        public override void Draw(Graphics e, int num = 0)
        {
            Brush b = new SolidBrush((State == State.Normal) ? Color.LightGray : Color.Lime);
            e.FillEllipse(b, Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2, NODE_SIZE, NODE_SIZE);
            e.DrawEllipse(new Pen(Color.Black), Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2, NODE_SIZE, NODE_SIZE);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Point center = Position;
            e.DrawString(Name, new Font("Consolas", FONT_SIZE, FontStyle.Regular), Brushes.Blue, center, sf);
        }

        public override bool IsOnHover(MouseEventArgs e)
        {
            return MathHelper.Distance(e.Location, Position) < NODE_SIZE / 2;
        }

        public override void OnMouseHover(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnMouseLeave(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnMove(Point to)
        {
            Position = to;
        }
    }
}
