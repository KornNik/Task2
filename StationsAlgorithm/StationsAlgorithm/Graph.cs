using System;
using System.Collections.Generic;

namespace StationsAlgorithm
{
    class Graph
    {
        private readonly List<Station> points;
        private readonly Dictionary<Station, List<Tuple<Station, Line>>> edges;
        public const int MAX = int.MaxValue;

        public Graph(List<Station> points, Dictionary<Station, List<Tuple<Station, Line>>> edges)
        {
            this.points = points;
            this.edges = edges;
        }

        public (List<Tuple<Station, Line>>, int) Find(Station start, Station finish)
        {
            Queue<Station> queue = new Queue<Station>();
            Dictionary<Station, List<Tuple<Station, Line>>> paths = new Dictionary<Station, List<Tuple<Station, Line>>>();
            int minTransfers = MAX;
            Station current = start;

            queue.Enqueue(current);
            paths[current] = new List<Tuple<Station, Line>>();

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                if (paths.ContainsKey(finish))
                {
                    if (paths[finish].Count == paths[current].Count)
                    {
                        return (paths[finish], minTransfers);
                    }
                }

                foreach (var edge in edges[current])
                {
                    var path = new List<Tuple<Station, Line>>(paths[current]); 
                    path.Add(edge);
                    if (edge.Item1 == finish)
                    {
                        if (!paths.ContainsKey(finish))
                        {
                            paths.Add(edge.Item1, path);
                            minTransfers = CountTransfers(path);
                            continue;
                        }
                        else
                        {
                            if (minTransfers > CountTransfers(path))
                            {
                                paths[edge.Item1] = path;
                                minTransfers = CountTransfers(path);
                                continue;
                            }
                        }
                    }
                    if (!paths.ContainsKey(edge.Item1))
                    {
                        paths.Add(edge.Item1, path);
                        queue.Enqueue(edge.Item1);
                    }
                }
            }

            return (paths[finish], minTransfers);
        }
        public static int CountTransfers(List<Tuple<Station, Line>> path)
        {
            if (path.Count < 2)
                return 0;

            int number = 0;
            for (int i = 1; i < path.Count; i++)
            {
                if (path[i - 1].Item2 != path[i].Item2)
                {
                    number++;
                }
            }
            return number;
        }
    }
}
