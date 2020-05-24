using System;
using System.Collections.Generic;
using System.Drawing;

namespace DesignOfSCS.graph
{
    /// <summary>
    /// Основной класс граф
    /// </summary>
    class Graph
    {
        /// <summary>
        /// Список вершин
        /// </summary>
        public List<Node> Nodes {get; set;}

        /// <summary>
        /// Список ребер
        /// </summary>
        public List<Edge> Edges { get; set;}

        public int MaxId { get; set; }

        /// <summary>
        /// Конструктор графа
        /// </summary>
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            MaxId = 0;
        }

        /// <summary>
        /// Добавление вершины в граф
        /// </summary>
        /// <param name="node">вершина</param>
        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        /// <summary>
        /// Добавление ребра в граф
        /// </summary>
        /// <param name="edge">ребро</param>
        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        /// <summary>
        /// Создание новой вершины
        /// </summary>
        /// <param name="position">Координаты</param>
        /// <param name="IS">true - если главный сервер</param>
        /// <param name="id">номер вершины</param>
        /// <returns></returns>
        public Node CreateNewNode(Point position, bool IS, int id = 0)
        {
            Node node;
            if (IS)
                node = new Node(0, IS);
            else
            {
                if (id == 0)
                    node = new Node(++MaxId, IS);
                else
                    node = new Node(id, IS, position.X, position.Y);
            }
            node.Position = position;
            AddNode(node);
            return node;
        }

        /// <summary>
        /// Создание нового ребра
        /// </summary>
        /// <param name="from">1 вершина</param>
        /// <param name="to">2 вершина</param>
        /// <param name="weight">3 вершина</param>
        /// <returns></returns>
        public Edge CreateNewEdge(Node from, Node to, int weight = 0)
        {
            Edge edge = new Edge(from, to, weight);
            AddEdge(edge);
            return edge;
        }

        /// <summary>
        /// Метод отрисовки графа
        /// </summary>
        /// <param name="g">Объект graphics для отрисовки</param>
        public void Draw(Graphics g)
        {
            foreach (Node n in Nodes)
            {
                n.Draw(g);
            }
            foreach (Edge e in Edges)
            {
                e.Draw(g, CountEdge(e));
            }
        }

        /// <summary>
        /// Удаление ребра
        /// </summary>
        /// <param name="e">ребро</param>
        public void DeleteEdge(Edge e)
        {
            Edges.Remove(e);
        }

        /// <summary>
        /// Удаление вершины
        /// </summary>
        /// <param name="n">Вершина</param>
        public void DeleteNode(Node n)
        {
            Nodes.Remove(n);
            for (int i = Edges.Count - 1; i >= 0; i--)
                if (Edges[i].From == n || Edges[i].To == n)
                    Edges.RemoveAt(i);
        }

        /// <summary>
        /// Есть ли вершина в графе
        /// </summary>
        /// <param name="n">вершина</param>
        /// <returns></returns>
        public bool Contains(Node n)
        {
            return Nodes.Contains(n);
        }

        /// <summary>
        /// Поиск вершины по ID
        /// </summary>
        /// <param name="id">номер вершины</param>
        /// <returns></returns>
        public Node FindNodeWithId(int id)
        {
            foreach (Node n in Nodes)
                if (n.Id == id) return n;
            return null;
        }

        /// <summary>
        /// Поиск индекса вершины в массиве вершин
        /// </summary>
        /// <param name="n">вершина</param>
        /// <returns></returns>
        public int Index(Node n)
        {
            return Nodes.IndexOf(n);
        }

        /// <summary>
        /// Количестве ребер
        /// </summary>
        /// <param name="edge">ребро</param>
        /// <returns></returns>
        public int CountEdge(Edge edge)
        {
            int ret = 0;
            foreach (Edge e in Edges)
            {
                if (e == edge) break;
                if (e.From == edge.From && e.To == edge.To || e.From == edge.To && e.To == edge.From)
                    ret++;
            }
            return ret;
        }
    }
}
