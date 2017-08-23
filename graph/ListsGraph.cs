using System;
using System.Collections.Generic;

namespace Algorithms
{
    class ListsGraph
    {
        private List<List<int>> AdjacencyLists { get; }

        private ListsGraph(int count)
        {
            AdjacencyLists = new List<List<int>>();

            for (int i = 0; i < count; i++)
            {
                AdjacencyLists.Add(new List<int>());
            }
        }

        private void AddEdge(int v1, int v2)
        {
            AdjacencyLists[v1].Add(v2);
        }

        private SearchInfo[] InitializeSearchInfo()
        {
            SearchInfo[] searchInfo = new SearchInfo[AdjacencyLists.Count];

            for (int i = 0; i < searchInfo.Length; i++)
            {
                searchInfo[i] = new SearchInfo(i);
            }

            return searchInfo;
        }

        private static ListsGraph SampleGraph()
        {
            ListsGraph graph = new ListsGraph(10);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 7);
            graph.AddEdge(3, 8);
            graph.AddEdge(4, 4);
            graph.AddEdge(5, 6);
            graph.AddEdge(7, 9);

            return graph;
        }        

        public static void TestBFS()
        {
            ListsGraph graph = SampleGraph();

            Queue<SearchInfo> traversal = graph.BreadthFirstSearch(0);

            PrintTraversal("Breadth First Search", traversal);
        }

        public static void TestDFS()
        {
            ListsGraph graph = SampleGraph();

            Queue<SearchInfo> traversal = graph.DepthFirstSearch(0);

            PrintTraversal("Depth First Search", traversal);
        }

        public static void TestRecursiveDFS()
        {
            ListsGraph graph = SampleGraph();
            Queue<SearchInfo> traversal = new Queue<SearchInfo>();

            SearchInfo[] searchInfo = graph.InitializeSearchInfo();

            graph.RecursiveDFS(0, null, traversal, searchInfo);

            PrintTraversal("Recursive Depth First Search", traversal);
        }

        private static void PrintTraversal(string name, Queue<SearchInfo> traversal)
        {
            Console.WriteLine(name);
            Console.WriteLine();

            while (traversal.Count > 0)
            {
                SearchInfo searchInfo = traversal.Dequeue();
                Console.WriteLine("vertex {0} distance = {1}", searchInfo.Vertex, searchInfo.Distance);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private Queue<SearchInfo> BreadthFirstSearch(int source)
        {
            Queue<int> queue = new Queue<int>();
            Queue<SearchInfo> traversal = new Queue<SearchInfo>();

            SearchInfo[] searchInfo = InitializeSearchInfo();

            queue.Enqueue(source);

            searchInfo[source].SetParent(null);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                traversal.Enqueue(searchInfo[current]);

                foreach (int vertex in AdjacencyLists[current])
                {
                    if (!searchInfo[vertex].Visited)
                    {
                        queue.Enqueue(vertex);

                        searchInfo[vertex].SetParent(searchInfo[current]);
                    }
                }
            }

            return traversal;
        }

        private Queue<SearchInfo> DepthFirstSearch(int source)
        {
            Stack<int> stack = new Stack<int>();
            Queue<SearchInfo> traversal = new Queue<SearchInfo>();

            SearchInfo[] searchInfo = InitializeSearchInfo();

            stack.Push(source);

            searchInfo[source].SetParent(null);

            while (stack.Count > 0)
            {
                int current = stack.Pop();

                traversal.Enqueue(searchInfo[current]);

                foreach (int vertex in AdjacencyLists[current])
                {
                    if (!searchInfo[vertex].Visited)
                    {
                        stack.Push(vertex);

                        searchInfo[vertex].SetParent(searchInfo[current]);
                    }
                }
            }

            return traversal;
        }

        private void RecursiveDFS(int current, SearchInfo parent, Queue<SearchInfo> traversal, SearchInfo[] searchInfo)
        {
            searchInfo[current].SetParent(parent);

            traversal.Enqueue(searchInfo[current]);

            foreach (int vertex in AdjacencyLists[current])
            {
                if (!searchInfo[vertex].Visited)
                {
                    RecursiveDFS(vertex, searchInfo[current], traversal, searchInfo);
                }
            }
        }

        private class SearchInfo
        {
            public int Vertex { get; }
            public int? Parent { get; private set; }
            public int? Distance { get; private set; }
            public bool Visited { get { return Distance.HasValue; } }

            public SearchInfo(int vertex)
            {
                Vertex = vertex;
                Parent = null;
                Distance = null;
            }

            public void SetParent(SearchInfo parentSearchInfo)
            {
                if (parentSearchInfo != null)
                {
                    Parent = parentSearchInfo.Vertex;
                    Distance = parentSearchInfo.Distance + 1;
                }
                else
                {
                    Distance = 0;
                }
            }
        }
    }
}
