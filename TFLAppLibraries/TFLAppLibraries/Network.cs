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

        //added GETLINES METHOD TO PRINT LINE NAMES
        public void GetLines()
        {
            try
            {
                if (lines.Count <= 0)
                {
                    throw new ArgumentException("No valid Data to Show");
                }

                foreach (var key in lines.Keys)
                {
                    Console.WriteLine($"Line : {key}");
                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            }
            
          public void GetAllStation( string line){
            if (!lines.ContainsKey(line)){
                Console.log("Line Not Found");
            }
            else{

                 List<Station> stations = lines[line];
                foreach (Station station in stations)
                {
                    Console.WriteLine(station);
                }
                
            }}


    public void AddTimeDelay(string line ,string stationFrom, string stationTo,double time, bool bothDirections){

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

                var trackFrom = network.OutEdges(stationFrom + "," + line);

              
                if (trackFrom.Any())
                {
                    
                    foreach (var track in trackFrom)
                    {
                        if (track.Target==stationTo +" , " + line)
                        {
                            
                            track.SetDelay(time);


                            //storing delayed tracks in Delayed tracks
                            if (!delayedTracks.ContainsKey(stationFrom))
                            {
                                delayedTracks[stationFrom] = new List<Track>();
                            }
                                
                            
                            delayedTracks[stationFrom].Add(track);
                                
                        }
                        if (bothDirections)
                        {
                            // Find the outgoing track from stationTo to stationFrom
                            var trackTo = network.OutEdges(stationTo + " , " + line);

                            // Update delay time for the found track 
                            foreach (var reverseTrack in trackTo)
                            {
                                if (reverseTrack.Target == stationFrom + " , " + line)
                                {
                                    reverseTrack.SetDelay(time);
                                    break;
                                }

                            if (!delayedTracks.ContainsKey(stationTo))
                            {
                                delayedTracks[stationTo] = new List<Track>();
                            }
                                
                        delayedTracks[stationTo].Add(track);
                            }
                        }
                    }
                }
             }}


            public void DeleteTimeDelay(string line ,string stationFrom, string stationTo,double time, bool bothDirections){
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

                var trackFrom = network.OutEdges(stationFrom + "," + line);if (trackFrom.Any())
                {
                    
                    foreach (var track in trackFrom)
                    {
                        if (track.Target==stationTo +" , " + line)
                        {
                            
                            track.SetDelay(0.0);


                            //storing delayed tracks in Delayed tracks
                        if (delayedTracks.ContainsKey(stationFrom))
                        {
                            delayedTracks[stationFrom].Remove(track);
                        }}
                        if (bothDirections)
                        {
                            // Find the outgoing track from stationTo to stationFrom
                            var trackTo = network.OutEdges(stationTo + " , " + line);

                            // Update delay time for the found track 
                            foreach (var reverseTrack in trackTo)
                            {
                            if (delayedTracks.ContainsKey(stationTo))
                                {
                                    delayedTracks[stationTo].Remove(reverseTrack);
                                }

                                // Reset delay time for the found track
                                reverseTrack.SetDelay(0);
                                }
                        }
                    }
                }}


            public void CloseTrack(string line,  string stationFrom,  string stationTo, double time,bool bothDirections){

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

                var trackFrom = network.OutEdges(stationFrom + "," + line);

                foreach (var track in trackFrom)
                {
                    if (track.Target == stationTo + "," + line)
                    {
                        // Set IsOpen attribute of the track to false
                        track.SetIsOpen(false);
                        
                        // Add the closed track to closedTracks dictionary using stationFrom as key
                        if (!closedTracks.ContainsKey(stationFrom))
                        {
                            closedTracks[stationFrom] = new List<Track>();
                        }
                        closedTracks[stationFrom].Add(track);

                        // If bothDirections is true, also closing track from stationTo to stationFrom
                        if (bothDirections)
                        {
                            // Finding the outgoing track from stationTo to stationFrom
                            var trackTo = network.OutEdges(stationTo + " , " + line);

                            // Close the track for the found track 
                            foreach (var reverseTrack in trackTo)
                            {
                                if (reverseTrack.Target == stationFrom + "," + line)
                                {
                                    // Set IsOpen attribute of the track to false
                                    reverseTrack.SetIsOpen(false);

                                    // Add the closed track to closedTracks dictionary using stationTo as key
                                    if (!closedTracks.ContainsKey(stationTo))
                                    {
                                        closedTracks[stationTo] = new List<Track>();
                                    }
                                    closedTracks[stationTo].Add(reverseTrack);
                                }
                            }
                        }
                    }
                
                }}
           public void OpenTrack(string line,  string stationFrom,  string stationTo, double time,bool bothDirections){

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

                var trackFrom = network.OutEdges(stationFrom + "," + line);

                foreach (var track in trackFrom)
                {
                    if (track.Target == stationTo + "," + line)
                    {
                        // Set IsOpen attribute of the track to false
                        track.SetIsOpen(true);

                        closedTracks[stationFrom].remove(track);
                        
                     

                        // If bothDirections is true, also closing track from stationTo to stationFrom
                        if (bothDirections)
                        {
                            // Finding the outgoing track from stationTo to stationFrom
                            var trackTo = network.OutEdges(stationTo + " , " + line);

                            // Close the track for the found track 
                            foreach (var reverseTrack in trackTo)
                            {
                                if (reverseTrack.Target == stationFrom + "," + line)
                                {
                                    // Set IsOpen attribute of the track to false
                                    reverseTrack.SetIsOpen(true);

                                    // Add the closed track to closedTracks dictionary using stationTo as key
                                   closedTracks[stationFrom].remove(track);
                                }
                            }
                        }
                    }
                
                }}


        public List<Edge> FindShortestPath(string startStation, string startLine, string destinationStation, string destinationLine)
        {
            var start = startStation + ", " + startLine;
            var destination = destinationStation + ", " + destinationLine;
            //return FastestPathAlgorithm.GetFastestPath(this.network, start, destination);
            return FastestPathAlgorithm.QuickGraphLibraryMethod(this.network, start, destination);
        }
    }
}