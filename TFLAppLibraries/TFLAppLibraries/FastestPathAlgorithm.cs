using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using QuickGraph;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;
using static System.Collections.Specialized.BitVector32;

namespace TFLAppLibraries
{
    public static class FastestPathAlgorithm
    {
        // This private class represents a node in the algorithm,
        // containing information about the node, its cost, and the path to reach it.
        private class AlgorithmNode
        {
            public string node { get; set; }            // The name of the node
            public double cost { get; set; }            // The cost (time) to reach this node
            public List<Edge> nodePath { get; set; }    // The path to reach this node

            // Class constructor
            public AlgorithmNode(string node, double cost, List<Edge>? nodePath)
            {
                this.node = node;
                this.cost = cost;
                this.nodePath = nodePath;
            }

            // Method used for testing - represents the node as a string
            public override string ToString()
            {
                return $"\t{this.node.ToString()},\t{this.cost},\t{this.nodePath.ToString()}";
            }
        }

        // The method finds the fastest path from one station to another in a transportation network represented by a graph
        // Handcoded, but using System.Collections.Generic library
        public static List<Edge> GetFastestPath(AdjacencyGraph<string, Edge> network, string start, string destination)
        {
            // 0. Set up structures for the algorithm
            var knownVertices = new List<AlgorithmNode>();      // List of vertices whose shortest paths are known
            var unknownVertices = new List<AlgorithmNode>();    // List of vertices whose shortest paths are not yet known

            // 1. Put start station node to unknown stations
            // 2. Set start station node cost = 0 and previous nodes list = empty list
            var firstNode = new AlgorithmNode 
            (
                start,
                0.0,                                            
                new List<Edge>()
            );
            unknownVertices.Add(firstNode);

            // 3. Check if there stations in unknown stations
            while (unknownVertices.Count > 0)                   // Start the algorithm loop over unknown vertices
            {
                // 4. Find the station in unknown stations with the smallest cost
                var selectedVertex = FindSmallestCostNode(unknownVertices);     // Used private method for that

                // 5. Check if the found station = destination
                var selectedVertexItem = selectedVertex.node;
                if (selectedVertexItem.Equals(destination))
                    return selectedVertex.nodePath;             // >>>>> EXIT from th algorithm if it is

                // 6. Move it from unknown stations
                unknownVertices.Remove(selectedVertex);         // from unknown
                knownVertices.Add(selectedVertex);              // to known

                // 7. Find to which stations it is connected and put them in connected vertices
                var selectedVertexEdges = network.OutEdges(selectedVertexItem);

                // start a loop over them (alternative for #8)
                // as the library structure allows foreach-loop
                foreach (var edge in selectedVertexEdges)   
                {
                   // 10. Check if it is in known stations
                    if (!knownVertices.Any(node => node.node == edge.Target) && edge.GetTravelTime() != null)
                    {
                        var travelTime = edge.GetTravelTime() != null ? Convert.ToDouble(edge.GetTravelTime()) : 0.0;

                        // 11. Check if it is in unknown stations
                        var isUnknown = unknownVertices.Find(node => node.node == edge.Target);

                        // 12. If it is - check if its cost + selected station cost
                        // < the cost of the in the unknown stations
                        if (isUnknown == null ||       
                            isUnknown.cost > selectedVertex.cost + travelTime) 
                        {
                            // 13. Delete old record from unknown stations - if found
                            if (isUnknown != null) 
                                unknownVertices.Remove(isUnknown);

                            // 14. Create path list for the connected station,
                            // starting with the connected node, and add the selected node path to it
                            var newPath = new List<Edge>(selectedVertex.nodePath) { edge };

                            // 15. Set connected station cost = track travel time + cost of the selected station
                            var newNode = new AlgorithmNode(edge.Target, selectedVertex.cost + travelTime, newPath);

                            // 16. Put connected station to unknown stations
                            unknownVertices.Add(newNode);
                        }
                    }
                }
                
            }

            return null;         // If no path is found, return null
        }

        // Private method to find the node with the smallest cost among a list of nodes
        private static AlgorithmNode FindSmallestCostNode(List<AlgorithmNode> nodeList)
        {
            var minCost = double.PositiveInfinity;
            var minPath = int.MaxValue;
            AlgorithmNode smallestCostNode = null;

            foreach (AlgorithmNode node in nodeList)
            {
                // 4a. Find the node with the smallest cost
                // and (if more than one found) the shortest path
                if (node.cost < minCost ||
                    (node.cost == minCost && node.nodePath.Count < minPath))
                {
                    minCost = node.cost;
                    minPath = node.nodePath.Count;
                    smallestCostNode = node;
                }
            }

            return smallestCostNode;
        }


        // This method finds the shortest path using the QuickGraph library method for Dijkstra algorithm
        public static List<Edge> QuickGraphLibraryMethod(AdjacencyGraph<string, Edge> network, string start, string destination)
        {
            var shortestPath = new List<Edge>();        // Initialize a list to store the shortest path

            // Initialize Dijkstra's algorithm  
            var dijkstra = new DijkstraShortestPathAlgorithm<string, Edge>
            (
                network,                                // with the graph
                edge =>
                {
                    var travelTime = edge.GetTravelTime();
                    return travelTime != null ? Convert.ToDouble(travelTime) : double.PositiveInfinity;
                }                                       // and a function to get the edge weights (travel times)
            );

            // Initialize an observer to record predecessors during Dijkstra's
            // computation as we'll need to give the path back
            var predecessorObserver = new VertexPredecessorRecorderObserver<string, Edge>(); 

            using (predecessorObserver.Attach(dijkstra))    // Attach the predecessor observer to the algorithm
                dijkstra.Compute(start);                    // Run Dijkstra's algorithm with the observer

            // Extract shortest path
            var predecessorDict =                           // the attribute is a dictionary of the 
                predecessorObserver.VertexPredecessors;     // vertices visited by the algorithm

            // Now loop over the result
            var currentVertex = destination;                // Start from the destination vertex back to the start
            while (predecessorDict.TryGetValue(currentVertex, out Edge incomingEdge))
            {
                shortestPath.Add(incomingEdge);             // Add the incoming edge to the shortest path
                currentVertex = incomingEdge.Source;        // Move to the source vertex of the incoming edge to continue the loop
            }

            shortestPath.Reverse();     // Reverse the list to get the correct order as we started from the end

            return shortestPath;
        }
    }
}

