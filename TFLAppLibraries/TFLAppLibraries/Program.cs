using System.Data;
using QuickGraph;

namespace TFLAppLibraries;

class Program
{
    static void Main(string[] args)
    {
        // Test shortest path algorithm
        var startStation = "Embankment";
        var startLine = "Circle";
        var endStation = "Green Park";
        var endLine = "Victoria";
        var net = new Network();
        var path = net.FindShortestPath(startStation, startLine, endStation, endLine);

        if (path != null && path.Count > 0)
            foreach (var edge in path)
                Console.WriteLine(edge.Source + "\tto " + edge.Target + "\t,\t" + edge.GetTravelTime() + "min");
        else
            Console.WriteLine("Path not found");
    }
}
