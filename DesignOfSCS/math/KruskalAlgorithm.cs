using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignOfSCS.math
{
    class KruskalAlgorithm
    {
		/// <summary>
		/// Структура ребро
		/// </summary>
		public struct Edge // структура ребро
		{
			public int Source; // вершина 1
			public int Destination; // вершина 2
			public double Weight; // вес между вершинами 1 и 2
		}

		/// <summary>
		/// Структура граф
		/// </summary>
		public struct Graph // структура граф
		{
			public int VerticesCount; // количество вершин
			public int EdgesCount; // количество ребер
			public Edge[] edge; // список ребер из структуры Edge
		}

		/// <summary>
		/// Компонента связности
		/// </summary>
		public struct Subset // структура компонента связности
		{
			public int Parent; // ссылка на родителя
			public int Rank; // ранг - глубина дерева
		}

		/// <summary>
		/// Метод создания графа
		/// </summary>
		/// <param name="verticesCount">количество вершин</param>
		/// <param name="edgesCoun">количество ребер</param>
		/// <returns></returns>
		public static Graph CreateGraph(int verticesCount, int edgesCoun)
		{
			Graph graph = new Graph(); // конструтор графа
			graph.VerticesCount = verticesCount; // записываем количество вершин
			graph.EdgesCount = edgesCoun; // записываем количетсво ребер
			graph.edge = new Edge[graph.EdgesCount]; // инициализируем список из ребер

			return graph; // возращаем полученный граф
		}

		/// <summary>
		/// Поиск элемента в множестве
		/// </summary>
		/// <param name="subsets">список множеств</param>
		/// <param name="i">номер компоненты</param>
		/// <returns></returns>
		private static int Find(Subset[] subsets, int i) // рекурсивная функция по поиску конечного родителя
		{
			if (subsets[i].Parent != i) // база рекурсии
				subsets[i].Parent = Find(subsets, subsets[i].Parent);

			return subsets[i].Parent;
		}

		/// <summary>
		/// Объединение компонент связности
		/// </summary>
		/// <param name="subsets">список множеств</param>
		/// <param name="x">Компонента 1</param>
		/// <param name="y">Компонента 2</param>
		private static void Union(Subset[] subsets, int x, int y) // объединяем 2 компоненты x и y
		{
			int xroot = Find(subsets, x); // находим корни деревьев
			int yroot = Find(subsets, y);

			if (subsets[xroot].Rank < subsets[yroot].Rank) // используем эвристику проверки на ранг, выбираем с меньшим рангом
				subsets[xroot].Parent = yroot;
			else if (subsets[xroot].Rank > subsets[yroot].Rank)
				subsets[yroot].Parent = xroot;
			else
			{
				subsets[yroot].Parent = xroot; // создаем ребро
				++subsets[xroot].Rank; // увеличиваем ранг
			}
		}

		/// <summary>
		/// Метод строищий MST по алгоритму Краскала
		/// </summary>
		/// <param name="_graph">граф</param>
		/// <returns></returns>
		public static int[,] Kruskal(DesignOfSCS.graph.Graph _graph) // на вход подается граф DesignOfSCS.graph.Graph
		{

			// конвертируем граф в удобный формат для алгоритма Краскала
			Graph graph = KruskalAlgorithm.CreateGraph(_graph.Nodes.Count, _graph.Edges.Count); // передаем параметры в конструтор 
			for (int j = 0; j < graph.EdgesCount; j++)// Заполняем массив ребер
			{
				graph.edge[j].Source = _graph.Edges[j].From.Id; // записываем вершину 1
				graph.edge[j].Destination = _graph.Edges[j].To.Id; // записываем вершину 2
				graph.edge[j].Weight = _graph.Edges[j].Weight; // записываем вес между вершинами 1 и 2
			}


			int verticesCount = graph.VerticesCount; // записываем количество вершин
			Edge[] result = new Edge[verticesCount]; // создаем массив result - в нем будет хранится минимальный остов
			int i = 0; // счетчик ребер
			int e = 0; // счетчик добавленных ребер

			// сортируем список ребер по возрастанию
			Array.Sort(graph.edge, delegate (Edge a, Edge b) // вызываем встроенную сортировку и сортируем по возрастанию ребра на основании веса
			{
				return a.Weight.CompareTo(b.Weight);
			});

			// множество компонент связсности
			Subset[] subsets = new Subset[verticesCount];

			for (int v = 0; v < verticesCount; ++v) // заполняем компоненты связности, изначально их столько же сколько и вершин, у нас n деревьев
			{
				subsets[v].Parent = v; // изначально ссылка на самого себя, ребер пока нет
				subsets[v].Rank = 0; // глубина дерева изначально 0
			}

			while (e < verticesCount - 1) // перебираем все ребра
			{
				Edge nextEdge = graph.edge[i++]; // достаем ребро со списка
				int x = Find(subsets, nextEdge.Source); // находим компоненты
				int y = Find(subsets, nextEdge.Destination);

				if (x != y) // если они не связаны, объединяем
				{
					result[e++] = nextEdge;
					Union(subsets, x, y);
				}
			}

			int[,] p = new int[e,2]; // формируем ответ

			for(int j = 0; j < e; j++)
			{
				p[j, 0] = result[j].Source;
				p[j, 1] = result[j].Destination;
			}

			return p;
		}


	}
}
