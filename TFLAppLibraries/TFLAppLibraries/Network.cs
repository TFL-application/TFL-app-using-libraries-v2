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


        public List<string>? GetAllStation(string line)
        {
            if (!lines.ContainsKey(line))
            {
                Console.WriteLine("Line Not Found");
                return null;
            }
            else
            {
                return lines[line];
            }
        }

        public void AddTimeDelay(string line, string stationFrom, string stationTo, double time, bool bothDirections)
        {
            if (!lines.ContainsKey(line))
            {
                Console.WriteLine("Line Not Found");
            }

            if (!lines[line].Contains(stationFrom) || !lines[line].Contains(stationTo))
            {
                Console.WriteLine("Station Not Found in Line");
            }

            var trackFrom = network.OutEdges(stationFrom + ", " + line)
                .Where(edge => edge.GetType() == typeof(Track));

            if (trackFrom.Any())
            {
                foreach (Track track in trackFrom)
                {
                    if (track.Target == stationTo + ", " + line)
                    {
                        track.SetDelay(time);

                        //storing delayed tracks in Delayed tracks
                        if (!delayedTracks.ContainsKey(line))
                        {
                            delayedTracks[line] = new List<Track>();
                        }

                        delayedTracks[line].Add(track);


                        if (bothDirections)
                        {
                            // Find the outgoing track from stationTo to stationFrom
                            var trackTo = network.OutEdges(stationTo + ", " + line)
                                .Where(edge => edge.GetType() == typeof(Track));

                            // Update delay time for the found track 
                            foreach (Track reverseTrack in trackTo)
                            {
                                if (reverseTrack.Target == stationFrom + ", " + line)
                                {
                                    reverseTrack.SetDelay(time);
                                }

                                if (!delayedTracks.ContainsKey(line))
                                {
                                    delayedTracks[line] = new List<Track>();
                                }

                                delayedTracks[line].Add(track);
                            }
                        }
                    }
                }
            }
        }


        public void DeleteTimeDelay(string line, string stationFrom, string stationTo, bool bothDirections)
        {
            if (!lines.ContainsKey(line))
            {
                Console.WriteLine("Line Not Found");
                return;
            }

            if (!lines[line].Contains(stationFrom) || !lines[line].Contains(stationTo))
            {
                Console.WriteLine("Station Not Found in Line");
                return;
            }

            var trackFrom = network.OutEdges(stationFrom + ", " + line)
                .Where(edge => edge.GetType() == typeof(Track));

            if (trackFrom.Any())
            {
                foreach (Track track in trackFrom)
                {
                    if (track.Target == stationTo + ", " + line)
                    {
                        track.SetDelay(0.0);

                        //storing delayed tracks in Delayed tracks
                        if (delayedTracks.ContainsKey(line))
                        {
                            delayedTracks[line].Remove(track);
                        }

                        if (bothDirections)
                        {
                            // Find the outgoing track from stationTo to stationFrom
                            var trackTo = network.OutEdges(stationTo + ", " + line)
                                .Where(edge => edge.GetType() == typeof(Track));

                            // Update delay time for the found track 
                            foreach (Track reverseTrack in trackTo)
                            {
                                if (reverseTrack.GetType() == typeof(Track))
                                {
                                    // Reset delay time for the found track
                                    reverseTrack.SetDelay(0);

                                    if (delayedTracks.ContainsKey(line))
                                    {
                                        delayedTracks[line].Remove(reverseTrack);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public void CloseTrack(string line, string stationFrom, string stationTo, bool bothDirections)
        {
            if (!lines.ContainsKey(line))
            {
                Console.WriteLine("Line Not Found");
                return;
            }

            if (!lines[line].Contains(stationFrom) || !lines[line].Contains(stationTo))
            {
                Console.WriteLine("Station Not Found in Line");
                return;
            }

            var trackFrom = network.OutEdges(stationFrom + ", " + line)
                .Where(edge => edge.GetType() == typeof(Track));

            foreach (Track track in trackFrom)
            {
                if (track.Target == stationTo + ", " + line)
                {
                    // Set IsOpen attribute of the track to false
                    track.SetIsOpen(false);

                    // Add the closed track to closedTracks dictionary using stationFrom as key
                    if (!closedTracks.ContainsKey(line))
                    {
                        closedTracks[line] = new List<Track>();
                    }
                    closedTracks[line].Add(track);

                    // If bothDirections is true, also closing track from stationTo to stationFrom
                    if (bothDirections)
                    {
                        // Finding the outgoing track from stationTo to stationFrom
                        var trackTo = network.OutEdges(stationTo + ", " + line)
                            .Where(edge => edge.GetType() == typeof(Track));

                        // Close the track for the found track 
                        foreach (Track reverseTrack in trackTo)
                        {
                            if (reverseTrack.Target == stationFrom + ", " + line)
                            {
                                // Set IsOpen attribute of the track to false
                                reverseTrack.SetIsOpen(false);

                                // Add the closed track to closedTracks dictionary using stationTo as key
                                if (!closedTracks.ContainsKey(line))
                                {
                                    closedTracks[line] = new List<Track>();
                                }
                                closedTracks[line].Add(reverseTrack);
                            }
                        }
                    }
                }

            }
        }


        public void OpenTrack(string line, string stationFrom, string stationTo, bool bothDirections)
        {
            if (!lines.ContainsKey(line))
            {
                Console.WriteLine("Line Not Found");
                return;
            }

            if (!lines[line].Contains(stationFrom) || !lines[line].Contains(stationTo))
            {
                Console.WriteLine("Station Not Found in Line");
                return;
            }

            var trackFrom = network.OutEdges(stationFrom + ", " + line)
                .Where(edge => edge.GetType() == typeof(Track));

            foreach (Track track in trackFrom)
            {
                if (track.Target == stationTo + ", " + line)
                {
                    // Set IsOpen attribute of the track to false
                    track.SetIsOpen(true);

                    if (closedTracks.ContainsKey(line))
                    {
                        closedTracks[line].Remove(track);
                    }

                    // If bothDirections is true, also closing track from stationTo to stationFrom
                    if (bothDirections)
                    {
                        // Finding the outgoing track from stationTo to stationFrom
                        var trackTo = network.OutEdges(stationTo + ", " + line)
                            .Where(edge => edge.GetType() == typeof(Track));

                        // Close the track for the found track 
                        foreach (Track reverseTrack in trackTo)
                        {
                            if (reverseTrack.Target == stationFrom + ", " + line)
                            {
                                // Set IsOpen attribute of the track to false
                                reverseTrack.SetIsOpen(true);

                                // Add the closed track to closedTracks dictionary using stationTo as key
                                if (closedTracks.ContainsKey(line))
                                {
                                    closedTracks[stationFrom].Remove(reverseTrack);
                                }
                            }
                        }
                    }
                }
            }
        }


        public List<Edge> FindShortestPath(string startStation, string startLine, string destinationStation, string destinationLine)
        {
            var start = startStation + ", " + startLine;
            var destination = destinationStation + ", " + destinationLine;
            return FastestPathAlgorithm.GetFastestPath(this.network, start, destination);
            // return FastestPathAlgorithm.QuickGraphLibraryMethod(this.network, start, destination);
        }
    }
}