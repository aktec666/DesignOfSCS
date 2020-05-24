using DesignOfSCS.math;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesignOfSCS.graph
{
    // класс вершины
    class Node : GraphObject
    {
        public const int NODE_SIZE = 60;
        public const int FONT_SIZE = 20;
        public bool IsServer { get; set; }

        public int Id { get; set; }

        public Point Position { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Верхняя левая точка отрисованного объекта
        /// </summary>
        public Point TopLeft
        {
            get
            {
                return new Point(Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2);
            }
        }
        /// <summary>
        /// Конструтор вершины
        /// </summary>
        /// <param name="id">идификатор вершины</param>
        /// <param name="IS">true - если главный сервер</param>
        /// <param name="x">координата X</param>
        /// <param name="y">координата Y</param>
        public Node(int id, bool IS, int x, int y)
        {
            IsServer = IS;
            Id = id;
            Name = id.ToString();
            Position = new Point(x, y);
        }

        /// <summary>
        /// Конструтор вершины
        /// </summary>
        /// <param name="id">идификатор вершины</param>
        /// <param name="IS">true - если главный сервер</param>
        public Node(int id, bool IS = false)
        {
            IsServer = IS;
            Id = id;
            Name = id.ToString();
        }

        /// <summary>
        /// метод отрисовки вершины
        /// </summary>
        /// <param name="e">Объект Graphics на котором происходит отрисовка</param>
        /// <param name="num">необязательный параметр унаследованный от базового класса</param>
        public override void Draw(Graphics e, int num = 0)
        {
            if (IsServer)
            {
                e.DrawImage(DesignOfSCS.Properties.Resources.main, Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2, NODE_SIZE, NODE_SIZE);
            }
            else
            {
                //Brush b = new SolidBrush((State == State.Normal) ? Color.LightGray : Color.Lime);
                //e.FillEllipse(b, Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2, NODE_SIZE, NODE_SIZE);
                //e.DrawEllipse(new Pen(Color.Black), Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2, NODE_SIZE, NODE_SIZE);
                e.DrawImage(DesignOfSCS.Properties.Resources.komutator, Position.X - NODE_SIZE / 2, Position.Y - NODE_SIZE / 2, NODE_SIZE, NODE_SIZE);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Point center = Position;
                center.Y -= 35;
                e.DrawString(Name, new Font("Consolas", FONT_SIZE, FontStyle.Regular), Brushes.Black, center, sf);
            }
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
        /// <summary>
        /// Изменение координаты вершины
        /// </summary>
        /// <param name="to">новая координата положения вершины</param>
        public void OnMove(Point to)
        {
            Position = to;
        }
    }

   

}
