using System;
using System.Collections.Generic;

namespace StationsAlgorithm
{
    class Program
    {
        List<Station> points = new List<Station>() { Station.A, Station.B, Station.C, Station.D,
            Station.E, Station.F, Station.G, Station.H, Station.J, Station.K, Station.L, Station.M,
            Station.N, Station.O};
        Dictionary<Station, List<Tuple<Station, Line>>> edges = new Dictionary<Station, List<Tuple<Station, Line>>>()
        {
            { Station.A,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.B, Line.Red)
                }
            },
            { Station.B,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.A, Line.Red),
                    Tuple.Create(Station.C, Line.Red),
                    Tuple.Create(Station.H, Line.Black),
                }
            },
            { Station.C,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.B, Line.Red),
                    Tuple.Create(Station.D, Line.Red),
                    Tuple.Create(Station.J, Line.Green),
                    Tuple.Create(Station.K, Line.Green),
                }
            },
            { Station.D,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.C, Line.Red),
                    Tuple.Create(Station.E, Line.Red),
                    Tuple.Create(Station.L, Line.Blue),
                    Tuple.Create(Station.J, Line.Blue),
                }
            },
            { Station.E,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.D, Line.Red),
                    Tuple.Create(Station.F, Line.Red),
                    Tuple.Create(Station.M, Line.Green),
                    Tuple.Create(Station.J, Line.Green),
                }
            },
            { Station.F,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.E, Line.Red),
                    Tuple.Create(Station.J, Line.Black),
                    Tuple.Create(Station.G, Line.Black),
                }
            },
            { Station.G,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.F, Line.Black),
                }
            },
            { Station.H,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.B, Line.Black),
                    Tuple.Create(Station.J, Line.Black),
                }
            },
            { Station.J,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.O, Line.Blue),
                    Tuple.Create(Station.F, Line.Black),
                    Tuple.Create(Station.E, Line.Green),
                    Tuple.Create(Station.D, Line.Blue),
                    Tuple.Create(Station.C, Line.Green),
                    Tuple.Create(Station.H, Line.Black),
                }
            },
            { Station.K,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.C, Line.Green),
                    Tuple.Create(Station.L, Line.Green),
                }
            },
            { Station.L,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.K, Line.Green),
                    Tuple.Create(Station.M, Line.Green),
                    Tuple.Create(Station.D, Line.Blue),
                    Tuple.Create(Station.N, Line.Blue),
                }
            },
            { Station.M,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.L, Line.Green),
                    Tuple.Create(Station.E, Line.Green),
                }
            },
            { Station.N,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.L, Line.Blue),
                }
            },
            { Station.O,
                new List<Tuple<Station, Line>>() 
                {
                    Tuple.Create(Station.J, Line.Blue),
                }
            },
        };

        private void Main_(string[] args)
        {
            Graph graph = new Graph(points, edges);
            var tempStations = graph.Find(Station.N, Station.O).Item1;
            var temp = graph.Find(Station.N, Station.O).Item2;
            Console.WriteLine(" transfers - "+ temp);
            foreach(var item in tempStations)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Main_(args);
        }

    }
}
