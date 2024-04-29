using System.Data;
using Microsoft.VisualStudio.GraphModel;
using QuickGraph;
using QuickGraph.Algorithms.ShortestPath;

namespace TFLAppLibraries;

class Program
{
    static void Main(string[] args)
    {
        // Create a graph
        var graph = new AdjacencyGraph<string, Edge<string>>();

        // Add vertices
        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");

        // Add edges (uncomment for weighted edges)
        graph.AddEdge(new Edge<string>("A", "B"));
        graph.AddEdge(new Edge<string>("B", "C"));
        graph.AddEdge(new Edge<string>("C", "A"));

        // Perform depth-first search
        var dfs = new DijkstraShortestPathAlgorithm<string, Edge<string>>(graph, edge => 1);

        Console.WriteLine(dfs.Distances);

        dfs.Compute("A");

        //Console.WriteLine(dfs.ToString());
    }
}
