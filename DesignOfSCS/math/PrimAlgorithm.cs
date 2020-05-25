﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignOfSCS.math
{

	/// <summary>
	/// Алгоритм Прима
	/// </summary>
    class PrimAlgorithm
    {
		/// <summary>
		/// Поиск ребра минимального веса
		/// </summary>
		/// <param name="key">массив текущих наименьших весов</param>
		/// <param name="set">метки вершин</param>
		/// <param name="verticesCount">количество вершин</param>
		/// <returns></returns>
		public static int MinKey(double[] key, bool[] set, int verticesCount)
		{
			double min = 1000000000;
			int minIndex = 0;
			for (int v = 0; v < verticesCount; ++v)
			{
				if (set[v] == false && key[v] < min)
				{
					min = key[v];
					minIndex = v;
				}
			}
			return minIndex;
		}

		/// <summary>
		/// Метод строищиц MST
		/// </summary>
		/// <param name="graph">матрица весов</param>
		/// <param name="verticesCount">количество вершин</param>
		/// <returns></returns>
		public static double[] Prim(double[,] graph, int verticesCount)
		{
			double[] parent = new double[verticesCount];
			double[] key = new double[verticesCount];
			bool[] mstSet = new bool[verticesCount];

			for (int i = 0; i < verticesCount; ++i)
			{
				key[i] = 1000000000;
				mstSet[i] = false;
			}

			key[0] = 0;
			parent[0] = -1;

			for (int count = 0; count < verticesCount - 1; ++count)
			{
				int u = MinKey(key, mstSet, verticesCount);
				mstSet[u] = true;

				for (int v = 0; v < verticesCount; ++v)
				{
					if (Convert.ToBoolean(graph[u, v]) && mstSet[v] == false && graph[u, v] < key[v])
					{
						parent[v] = u;
						key[v] = graph[u, v];
					}
				}
			}
			return parent;

		}

	}
}
