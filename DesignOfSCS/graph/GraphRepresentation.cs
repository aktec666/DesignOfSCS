using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignOfSCS.graph
{
    class GraphRepresentation
    {
        public static int[,] toAdjacencyMatrix(Graph g)
        {
            int[,] ret = new int[g.Nodes.Count, g.Nodes.Count];
            foreach (Edge e in g.Edges)
            {
                int u = g.Index(e.From);
                int v = g.Index(e.To);
                ret[u, v] = 1;
            }
            return ret;
        }

        public static Graph fromAdjacencyMatrix(int[,] matrix)
        {
            Graph g = new Graph();
            for (int i = 0; i < matrix.GetLength(0); i++)
                g.AddNode(new Node(i + 1));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        Edge e = new Edge(g.Nodes[i], g.Nodes[j]);
                        g.AddEdge(e);
                    }
                }
            }
            return g;
        }

        public static int[,] toIncidenceMatrix(Graph g)
        {
            int[,] ret = new int[g.Nodes.Count, g.Edges.Count];
            for (int i = 0; i < g.Edges.Count; i++)
            {
                ret[g.Index(g.Edges[i].From), i] = 1;
                ret[g.Index(g.Edges[i].To), i] = -1;
            }
            return ret;
        }

        public static Graph fromIncidenceMatrix(int[,] matrix)
        {
            Graph g = new Graph();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                g.AddNode(new Node(i + 1));
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                Node from = null;
                Node to = null;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == 1)
                    {
                        from = g.Nodes[j];
                    }
                    if (matrix[j, i] == -1)
                    {
                        to = g.Nodes[j];
                    }
                }
                if (from != null && to != null)
                {
                    g.AddEdge(new Edge(from, to));
                }
            }
            return g;
        }

        public static int[,] toWeightMatrix(Graph g)
        {
            int[,] ret = new int[g.Nodes.Count, g.Nodes.Count];
            for (int i = 0; i < ret.GetLength(0); i++)
                for (int j = 0; j < ret.GetLength(1); j++)
                    ret[i, j] = 1000000000;
            foreach (Edge e in g.Edges)
            {
                int u = g.Index(e.From);
                int v = g.Index(e.To);
                ret[u, v] = e.Weight;
                ret[v, u] = e.Weight;
            }
            return ret;
        }

        public static Graph fromWeightMatrix(int[,] matrix)
        {
            Graph g = new Graph();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                g.AddNode(new Node(i + 1));
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        Edge e = new Edge(g.Nodes[i], g.Nodes[j], matrix[i, j]);
                        g.AddEdge(e);
                    }
                }
            }
            return g;
        }

        public static int[,] toEdgeList(Graph g)
        {
            int[,] ret = new int[3, g.Edges.Count];
            int n = 0;
            foreach (Edge e in g.Edges)
            {
                ret[0, n] = e.From.Id;
                ret[1, n] = e.To.Id;
                ret[2, n] = e.Weight;
                n++;
            }
            return ret;
        }

        public static Graph fromEdgeList(int[,] list)
        {
            Graph g = new Graph();
            int maxId = 0;
            for (int i = 0; i < list.GetLength(1); i++)
            {
                maxId = Math.Max(maxId, list[0, i]);
                maxId = Math.Max(maxId, list[1, i]);
            }
            for (int i = 0; i < maxId; i++)
                g.AddNode(new Node(i + 1));
            for (int i = 0; i < list.GetLength(1); i++)
            {
                if (list.GetLength(0) == 2)
                    g.AddEdge(new Edge(g.Nodes[list[0, i] - 1], g.Nodes[list[1, i] - 1]));
                else
                    g.AddEdge(new Edge(g.Nodes[list[0, i] - 1], g.Nodes[list[1, i] - 1], list[2, i]));
            }
            g.MaxId = maxId;
            return g;
        }

        public static int[,] toAdjacencyList(Graph g)
        {
            List<List<int>> m = new List<List<int>>();
            for (int i = 0; i < g.Nodes.Count; i++)
                m.Add(new List<int>());
            Console.WriteLine(m.Count);
            Console.WriteLine(g.Nodes.Count);
            foreach (Edge e in g.Edges)
            {
                m[g.Index(e.From)].Add(e.To.Id);
                m[g.Index(e.To)].Add(e.From.Id);
            }
            int k = 0;
            for (int i = 0; i < m.Count; i++)
                k = Math.Max(k, m[i].Count);
            int[,] ret = new int[g.Nodes.Count, k + 1];
            for (int i = 0; i < m.Count; i++)
            {
                ret[i, 0] = g.Nodes[i].Id;
                for (int j = 0; j < m[i].Count; j++)
                {
                    ret[i, j + 1] = m[i][j];
                }
            }
            return ret;
        }
    }
}

