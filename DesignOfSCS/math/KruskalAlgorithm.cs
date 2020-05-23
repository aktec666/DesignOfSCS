using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignOfSCS.math
{
    class KruskalAlgorithm
    {
		public struct Edge
		{
			public int Source;
			public int Destination;
			public int Weight;
		}

		public struct Graph
		{
			public int VerticesCount;
			public int EdgesCount;
			public Edge[] edge;
		}

		public struct Subset
		{
			public int Parent;
			public int Rank;
		}

		public static Graph CreateGraph(int verticesCount, int edgesCoun)
		{
			Graph graph = new Graph();
			graph.VerticesCount = verticesCount;
			graph.EdgesCount = edgesCoun;
			graph.edge = new Edge[graph.EdgesCount];

			return graph;
		}

		private static int Find(Subset[] subsets, int i)
		{
			if (subsets[i].Parent != i)
				subsets[i].Parent = Find(subsets, subsets[i].Parent);

			return subsets[i].Parent;
		}

		private static void Union(Subset[] subsets, int x, int y)
		{
			int xroot = Find(subsets, x);
			int yroot = Find(subsets, y);

			if (subsets[xroot].Rank < subsets[yroot].Rank)
				subsets[xroot].Parent = yroot;
			else if (subsets[xroot].Rank > subsets[yroot].Rank)
				subsets[yroot].Parent = xroot;
			else
			{
				subsets[yroot].Parent = xroot;
				++subsets[xroot].Rank;
			}
		}

		public static int[,] Kruskal(DesignOfSCS.graph.Graph _graph)
		{
			Graph graph = KruskalAlgorithm.CreateGraph(_graph.Nodes.Count, _graph.Edges.Count);
			for (int j = 0; j < graph.EdgesCount; j++)
			{
				graph.edge[j].Source = _graph.Edges[j].From.Id;
				graph.edge[j].Destination = _graph.Edges[j].To.Id;
				graph.edge[j].Weight = _graph.Edges[j].Weight;
			}


			int verticesCount = graph.VerticesCount;
			Edge[] result = new Edge[verticesCount];
			int i = 0;
			int e = 0;

			Array.Sort(graph.edge, delegate (Edge a, Edge b)
			{
				return a.Weight.CompareTo(b.Weight);
			});

			Subset[] subsets = new Subset[verticesCount];

			for (int v = 0; v < verticesCount; ++v)
			{
				subsets[v].Parent = v;
				subsets[v].Rank = 0;
			}

			while (e < verticesCount - 1)
			{
				Edge nextEdge = graph.edge[i++];
				int x = Find(subsets, nextEdge.Source);
				int y = Find(subsets, nextEdge.Destination);

				if (x != y)
				{
					result[e++] = nextEdge;
					Union(subsets, x, y);
				}
			}

			int[,] p = new int[e,2];

			for(int j = 0; j < e; j++)
			{
				p[j, 0] = result[j].Source;
				p[j, 1] = result[j].Destination;
			}

			return p;
		}


	}
}
