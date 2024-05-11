using System;
using QuickGraph;

namespace TFLAppLibraries
{
	public class NetworkData
	{
        public Dictionary<string, List<string>> lines { get; private set; }
        public AdjacencyGraph<string, Edge> network { get; private set; }

        public NetworkData()
        {
            lines = new Dictionary<string, List<string>>();
            network = new AdjacencyGraph<string, Edge>();

            // TEST DATA
            // Victoria
            // 1. Declare line
            var victoriaName = "Victoria";

            // 2. Create stations and distances for the line
            var victoriaLineStations = new List<string>()
            {
                "Green Park",
                "Victoria"
            };

            var victoriaLineDistances = new List<double>()
            {
                2.0     // Green Park   to Victoria
            };

            // 3. Add line
            this.AddLine(victoriaName, victoriaLineStations, victoriaLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            // Nothing for the first line

            // Jubilee
            // 1. Declare line
            var jubileeName = "Jubilee";

            // 2. Create stations and distances for the line
            var jubileeLineStations = new List<string>()
            {
                "Green Park",
                "Westminster",
                "Waterloo"
            };

            var jubileeLineDistances = new List<double>()
            {
                3.0,    // Green Park   to Westminster
                3.0     // Westminster  to Waterloo
            };

            // 3. Add line
            this.AddLine(jubileeName, jubileeLineStations, jubileeLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var greenParkChange1 = new Change("Green Park, Victoria", "Green Park, Jubilee");
            var greenParkChange2 = new Change("Green Park, Jubilee", "Green Park, Victoria");
            network.AddEdge(greenParkChange1);
            network.AddEdge(greenParkChange2);

            // Circle
            // 1. Declare line
            var circleName = "Circle";

            // 2. Create stations and distances for the line
            var circleLineStations = new List<string>()
            {
                "Victoria",
                "St James Park",
                "Westminster",
                "Embankment"
            };

            var circleLineDistances = new List<double>()
            {
                1.0,    // Victoria         to St James Park
                2.0,    // St James Park    to Westminster
                2.0     // Westminster      to Enbankment
            };

            // 3. Add line
            this.AddLine(circleName, circleLineStations, circleLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var westminsterChange1 = new Change("Westminster, Circle", "Westminster, Jubilee");
            var westminsterChange2 = new Change("Westminster, Jubilee", "Westminster, Circle");
            var victoriaChange1 = new Change("Victoria, Circle", "Victoria, Victoria");
            var victoriaChange2 = new Change("Victoria, Victoria", "Victoria, Circle");
            network.AddEdge(westminsterChange1);
            network.AddEdge(westminsterChange2);
            network.AddEdge(victoriaChange1);
            network.AddEdge(victoriaChange2);
        }

		public void AddLine(string lineName, List<string> stationNames, List<double> distances)
		{
            lines.Add(lineName, stationNames);

            for (int i = 0; i < stationNames.Count; i++)
            {
                // Add stations to the graph
                var selectedStation = stationNames[i] + ", " + lineName;
                network.AddVertex(selectedStation);

                if (i != 0)
                {
                    // Create tracks betweeen stations both ways
                    var previousStation = stationNames[i - 1] + ", " + lineName;
                    var track1 = new Track(distances[i - 1], selectedStation, previousStation);
                    var track2 = new Track(distances[i - 1], previousStation, selectedStation);
                    network.AddEdge(track1);
                    network.AddEdge(track2);
                }
            }
        }
	}
}

