using System;
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
		/// Поиск вершины с ребром минимального веса
		/// </summary>
		/// <param name="key">массив текущих наименьших весов</param>
		/// <param name="set">метки вершин</param>
		/// <param name="verticesCount">количество вершин</param>
		/// <returns></returns>
		public static int MinKey(double[] key, bool[] set, int verticesCount)
		{
			double min = 1000000000; // переменная для поиска минимамума
			int minIndex = 0;  // переменная в которой храним индекс минимума
			for (int v = 0; v < verticesCount; ++v) // перебираем все ребра, которые можно присоединить к остову и они еще не помечены
			{
				if (set[v] == false && key[v] < min) // если это новая вершина и ее ребро меньше
				{
					min = key[v]; // сохраняем минимальный вес
					minIndex = v; // сохраняем индекс вершины
				}
			}
			return minIndex; // возвращаем индекс вершины с минимальным ребром
		}

		/// <summary>
		/// Метод строищиц MST
		/// </summary>
		/// <param name="graph">матрица весов</param>
		/// <param name="verticesCount">количество вершин</param>
		/// <returns></returns>
		public static double[] Prim(double[,] graph, int verticesCount)
		{
			double[] parent = new double[verticesCount]; // массив ссылок на вершину родителя, к примеру если parent[2] = 5, это значит что есть ребро из вершины 2 в 5   
			double[] key = new double[verticesCount]; // массив весов, к примеру key[2] = 10, это значит что ребро 2-5 весит 10, из примеры выше сохранятеся ссылка
			bool[] mstSet = new bool[verticesCount]; // массив флажков вершин, true - вершина в остове, false - еще не добавлена в остов

			for (int i = 0; i < verticesCount; ++i) // инициализируем массивы значение 1000000000 - означает бесконечность
			{
				key[i] = 1000000000;
				mstSet[i] = false; // пока не доавлена ни онда вершина и поэтому все false
			}

			key[0] = 0; // начинаем обход к примеру с вершины 0, вершина 0 всегда главный коммутатор
			parent[0] = -1; // так как мы наинчаем с 0 вершины, то у нее нет родителя и записываем -1

			for (int count = 0; count < verticesCount - 1; ++count) // запускаем цикл n-1 раз, где n - количество вершин, а ребер будет на 1 меньше, цикл за каждую итерацию добавляет 1 ребро
			{
				int u = MinKey(key, mstSet, verticesCount); // вызываем метод выбора вершины с минимальным весом
				mstSet[u] = true; // помечаем что вершина добавлена в остов

				for (int v = 0; v < verticesCount; ++v) // обновляем массив ссылок и весов с новой вершиной
				{
					if (mstSet[v] == false && graph[u, v] < key[v]) // если вершина не помечена и вес меньше текущего в массиве весов
					{
						parent[v] = u; // обновляем родителя
						key[v] = graph[u, v]; // обновляем вес
					}
				}
			}
			return parent; // возвращаем минимальный остов

		}

	}
}
