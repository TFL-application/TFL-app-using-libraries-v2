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

        Console.WriteLine("");
        Console.WriteLine("-------");
        Console.WriteLine("");

        net.CloseTrack(startLine, startStation, "Westminster", false);

        var path2 = net.FindShortestPath(startStation, startLine, endStation, endLine);
        if (path2 != null && path2.Count > 0)
            foreach (var edge in path2)
                Console.WriteLine(edge.Source + "\tto " + edge.Target + "\t,\t" + edge.GetTravelTime() + "min");
        else
            Console.WriteLine("Path not found");

        Console.WriteLine("");
        Console.WriteLine("-------");
        Console.WriteLine("");

        net.OpenTrack(startLine, startStation, "Westminster", false);
        var path3 = net.FindShortestPath(startStation, startLine, endStation, endLine);

        if (path3 != null && path3.Count > 0)
            foreach (var edge in path3)
                Console.WriteLine(edge.Source + "\tto " + edge.Target + "\t,\t" + edge.GetTravelTime() + "min");
        else
            Console.WriteLine("Path not found");

        Console.WriteLine("");
        Console.WriteLine("-------");
        Console.WriteLine("");

        net.AddTimeDelay(startLine, startStation, "Westminster", 0.2, false);
        var path4 = net.FindShortestPath(startStation, startLine, endStation, endLine);

        if (path4 != null && path4.Count > 0)
            foreach (var edge in path4)
                Console.WriteLine(edge.Source + "\tto " + edge.Target + "\t,\t" + edge.GetTravelTime() + "min");
        else
            Console.WriteLine("Path not found");

        Console.WriteLine("");
        Console.WriteLine("-------");
        Console.WriteLine("");


        net.DeleteTimeDelay(startLine, startStation, "Westminster", false);
        var path5 = net.FindShortestPath(startStation, startLine, endStation, endLine);

        if (path5 != null && path5.Count > 0)
            foreach (var edge in path5)
                Console.WriteLine(edge.Source + "\tto " + edge.Target + "\t,\t" + edge.GetTravelTime() + "min");
        else
            Console.WriteLine("Path not found");
    }
}
