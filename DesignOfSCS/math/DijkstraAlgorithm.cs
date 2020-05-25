using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignOfSCS.math
{
	/// <summary>
	/// Алгоритм Дейкстры
	/// </summary>
    class DijkstraAlgorithm
    {
		private static int MinimumDistance(double[] distance, bool[] shortestPathTreeSet, int verticesCount)
		{
			double min = int.MaxValue;
			int minIndex = 0;

			for (int v = 0; v < verticesCount; ++v)
			{
				if (shortestPathTreeSet[v] == false && distance[v] <= min)
				{
					min = distance[v];
					minIndex = v;
				}
			}

			return minIndex;
		}

		/// <summary>
		/// Метод реализующий алгоритм Дейкстры
		/// </summary>
		/// <param name="graph">граф</param>
		/// <param name="source">для какой вершины ищем путь</param>
		/// <param name="verticesCount">количество вершин</param>
		/// <returns></returns>
		public static double[] Dijkstra(double[,] graph, int source, int verticesCount)
		{
			double[] distance = new double[verticesCount];
			bool[] shortestPathTreeSet = new bool[verticesCount];

			for (int i = 0; i < verticesCount; ++i)
			{
				distance[i] = int.MaxValue;
				shortestPathTreeSet[i] = false;
			}

			distance[source] = 0;

			for (int count = 0; count < verticesCount - 1; ++count)
			{
				int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
				shortestPathTreeSet[u] = true;

				for (int v = 0; v < verticesCount; ++v)
					if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
						distance[v] = distance[u] + graph[u, v];
			}

			return distance;
		}
	}
}
