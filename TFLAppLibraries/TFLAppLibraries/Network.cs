using System;
using QuickGraph;

namespace TFLAppLibraries
{
	public class Network
    {
		private Dictionary<string, List<string>> lines;
        private AdjacencyGraph<string, Edge> network;
        private Dictionary<string, List<Track>> closedTracks;
        private Dictionary<string, List<Track>> delayedTracks;

        public Network()
		{
            // Declaring storing structures in a constructor
            lines = new Dictionary<string, List<string>>();
            network = new AdjacencyGraph<string, Edge>();
            closedTracks = new Dictionary<string, List<Track>>();
            delayedTracks = new Dictionary<string, List<Track>>();

            // Add tube data
            var data = new NetworkData();
            lines = data.lines;
            network = data.network;
        }


        public List<Edge> FindShortestPath(string startStation, string startLine, string destinationStation, string destinationLine)
        {
            var start = startStation + ", " + startLine;
            var destination = destinationStation + ", " + destinationLine;
            //return FastestPathAlgorithm.GetFastestPath(this.network, start, destination);
            return FastestPathAlgorithm.QuickGraphLibraryMethod(this.network, start, destination);
        }
    }
}

