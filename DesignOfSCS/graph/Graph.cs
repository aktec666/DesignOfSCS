using System;
using System.Collections.Generic;
using System.Drawing;

namespace DesignOfSCS.graph
{
    class Graph
    {
        public List<Node> Nodes {get; set;}

        public List<Edge> Edges { get; set;}

        public int MaxId { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            MaxId = 0;
        }
        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }
        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public Node CreateNewNode(Point position, int id = 0)
        {
            Node node;
            if (id == 0)
                node = new Node(++MaxId);
            else
                node = new Node(id, position.X, position.Y);
            node.Position = position;
            AddNode(node);
            return node;
        }

        public Edge CreateNewEdge(Node from, Node to, int weight = 0)
        {
            Edge edge = new Edge(from, to, weight);
            AddEdge(edge);
            return edge;
        }

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

        public void DeleteEdge(Edge e)
        {
            Edges.Remove(e);
        }

        public void DeleteNode(Node n)
        {
            Nodes.Remove(n);
            for (int i = Edges.Count - 1; i >= 0; i--)
                if (Edges[i].From == n || Edges[i].To == n)
                    Edges.RemoveAt(i);
        }

        public bool Contains(Node n)
        {
            return Nodes.Contains(n);
        }

        public Node FindNodeWithId(int id)
        {
            foreach (Node n in Nodes)
                if (n.Id == id) return n;
            return null;
        }

        public int Index(Node n)
        {
            return Nodes.IndexOf(n);
        }

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
