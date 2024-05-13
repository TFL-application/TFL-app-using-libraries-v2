using System;

namespace TFLAppLibraries
{
	public class Menu
	{
        private Network network;

        public Menu()
        {
            network = new Network();
        }

        public void Display_menu()
        {
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                            WELCOME                                   **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**                               TO                                     **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**                       Transport For London                           **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**************************************************************************");
        }

        public  int Tfl_menu()
        {
            Console.Clear();
            Display_menu();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**              Please choose from options below:                       **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    1. Customer                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    2. Engineer                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    3. Exit                                                           **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");

            int choice = 0;
            while (choice < 1 || choice > 3)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Exception: " + ex.Message + " Please try again.");
                }
            }

            return choice;
        }

        // THis method will return choice of operation Cutomer wants to perform
        public int Customer_Menu(string? name)
        {
            Console.Clear();
            Display_menu();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine($"           Hello {name} !How we May help you?                          **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** Enter Options from 1-2                                               **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("** 1. Choose Station by Line                                            **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 2. Exit to Main Menu                                                 **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int choice = 0;
            while (choice < 1 || choice > 2)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Exception: " + ex.Message + " Please try again.");
                }
            }

            return choice;
        }
         
        // This method will return choice of operation Engineer wants to perform
        public int Engineer_Menu()
        {
            Console.Clear();
            Display_menu();
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** Enter Options from 1-7                                               **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("** 1. Add Delay                                                         **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 2. Remove Delay                                                      **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 3. Close Track                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 4. Open  Track                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 5. See Closed Tracks                                                 **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 6. See Tracks with Delays                                            **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 7. Exit To Main Menu                                                 **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int choice = 0;
            while (choice < 1 || choice > 7)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Exception: " + ex.Message + " Please try again.");
                }
            }
            return choice;
        }

        public void Customer_Operation()
        {
            Console.Clear();
            Console.WriteLine("Welcome To TFL ");
            Console.WriteLine("Enter your Name Customer");
            string? name = Console.ReadLine();
            int option = 0;
            do
            {
                option = Customer_Menu(name);
                switch (option)
                {
                    // Case when customer chooses to decide Journey from choosing Line 
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Choose Start Line");
                        Console.WriteLine("-------------");

                        var lines = network.GetLines();
                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Start Line Name: ");
                        string? lineFrom = Console.ReadLine();
                        while (lineFrom == "" || lineFrom is null || !lines.Contains(lineFrom))
                        {
                            Console.Write("Enter Line Name again: ");
                            lineFrom = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Stations on the line");
                        Console.WriteLine("-------------");
                        var lineFromStations = network.GetAllStations(lineFrom);
                        foreach (string station in lineFromStations)
                        {
                            Console.WriteLine(station);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Start Station: ");
                        string stationFrom = Console.ReadLine();
                        while (stationFrom == "" || stationFrom is null
                            || !lineFromStations.Contains(stationFrom))
                        {
                            Console.Write("Enter Start Station again: ");
                            stationFrom = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Choose Destination Line");
                        Console.WriteLine("-------------");
                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Destination Line Name: ");
                        string? lineTo = Console.ReadLine();
                        while (lineTo == "" || lineTo is null || !lines.Contains(lineTo))
                        {
                            Console.Write("Enter linename again: ");
                            lineTo = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Stations on the line");
                        Console.WriteLine("-------------");
                        var lineToStations = network.GetAllStations(lineTo);
                        foreach (string station in lineToStations)
                        {
                            Console.WriteLine(station);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Destination Station: ");
                        string stationTo = Console.ReadLine();
                        while (stationTo == "" || stationTo is null
                            || !lineToStations.Contains(stationTo))
                        {
                            Console.Write("Enter Destination Station again: ");
                            stationTo = Console.ReadLine();
                        }

                        var path = network.FindShortestPath(stationFrom, lineFrom, stationTo, lineTo);
                        ShowPath(path);
                        break;

                    case 2:
                        break;

                    default:
                        Console.WriteLine("Invalid Option Entered! Please choose Valid Option");
                        break;
                }
            } while (option != 2);
            return;
        }


        //Engineer Options
        public void Engineer_Operation()
        {
            int choice = 0;
            do
            {
                choice = Engineer_Menu();
                switch (choice)
                {
                    case 1:
                        //Case When Engineer chooses to Add Delay
                        Console.Clear();
                        Console.WriteLine("Choose Line");
                        Console.WriteLine("-------------");

                        var lines = network.GetLines();
                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Line name to Add delay: ");
                        string? linename = Console.ReadLine();
                        while (linename == "" || linename is null || !lines.Contains(linename))
                        {
                            Console.Write("Enter Line Name again: ");
                            linename = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Stations on the line");
                        Console.WriteLine("-------------");
                        var lineStations = network.GetAllStations(linename);
                        foreach (string station in lineStations)
                        {
                            Console.WriteLine(station);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Station name to Add Delay From: ");
                        string StationStart = Console.ReadLine();
                        while (StationStart == "" || StationStart is null
                            || !lineStations.Contains(StationStart))
                        {
                            Console.Write("Enter Start Station again: ");
                            StationStart = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Station name to add Delay To: ");
                        string StationEnd = Console.ReadLine();
                        while (StationEnd == "" || StationEnd is null
                            || !lineStations.Contains(StationEnd))
                        {
                            Console.Write("Enter Destination Station again: ");
                            StationEnd = Console.ReadLine();
                        }

                        double TimeDelay = 0.0;
                        while (TimeDelay == 0.0)
                        {
                            try
                            {
                                Console.WriteLine("Enter Time Delay: ");
                                TimeDelay = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Format Exception: " + ex.Message + " Please try again.");
                            }
                        }

                        Console.WriteLine("Is the Delay in both Directions? choose between true or false");
                        //calling boolvalue function
                        bool direction = boolValue();
                        Console.Clear();
                        network.AddTimeDelay(linename, StationStart, StationEnd, TimeDelay, direction);
                        Continue();
                        break;


                    //Case When Engineer chooses to Remove Delay
                    case 2:
                        Console.Clear();
                        if (PrintDelayedTracks() > 0)
                        {
                            var lines1 = network.GetLines();

                            Console.WriteLine("");
                            Console.Write("Enter Line name to Remove delay: ");
                            string? linename1 = Console.ReadLine();
                            while (linename1 == "" || linename1 is null || !lines1.Contains(linename1))
                            {
                                Console.Write("Enter Line Name again: ");
                                linename1 = Console.ReadLine();
                            }

                            var lineStations1 = network.GetAllStations(linename1);

                            Console.WriteLine("");
                            Console.Write("Enter Station name to Remove Delay From: ");
                            string FromStation = Console.ReadLine();
                            while (FromStation == "" || FromStation is null
                                || !lineStations1.Contains(FromStation))
                            {
                                Console.Write("Enter Station again: ");
                                FromStation = Console.ReadLine();
                            }

                            Console.WriteLine("");
                            Console.Write("Enter Station name to Remove Delay To: ");
                            string ToStation = Console.ReadLine();
                            while (ToStation == "" || ToStation is null
                                || !lineStations1.Contains(ToStation))
                            {
                                Console.Write("Enter Station again: ");
                                ToStation = Console.ReadLine();
                            }

                            Console.WriteLine("Is the Delay in both Directions? choose between true or false");
                            //calling boolvalue function
                            bool directionVal = boolValue();
                            Console.Clear();
                            network.DeleteTimeDelay(linename1, FromStation, ToStation, directionVal);
                        }
                        Continue();
                        break;

                    //Case when Enginner chooses to close Track
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Choose Line");
                        Console.WriteLine("-------------");

                        var lines2 = network.GetLines();
                        foreach (string line in lines2)
                        {
                            Console.WriteLine(line);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Line name to close track: ");
                        string? linename2 = Console.ReadLine();
                        while (linename2 == "" || linename2 is null || !lines2.Contains(linename2))
                        {
                            Console.Write("Enter Line Name again: ");
                            linename2 = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Stations on the line");
                        Console.WriteLine("-------------");
                        var lineStations2 = network.GetAllStations(linename2);
                        foreach (string station in lineStations2)
                        {
                            Console.WriteLine(station);
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Station name to Close From: ");
                        string StationA = Console.ReadLine();
                        while (StationA == "" || StationA is null
                            || !lineStations2.Contains(StationA))
                        {
                            Console.Write("Enter Station again: ");
                            StationA = Console.ReadLine();
                        }

                        Console.WriteLine("");
                        Console.Write("Enter Station name to Close Track To: ");
                        string StationB = Console.ReadLine();
                        while (StationB == "" || StationB is null
                            || !lineStations2.Contains(StationB))
                        {
                            Console.Write("Enter Station again: ");
                            StationB = Console.ReadLine();
                        }

                        Console.WriteLine("Is the Track Close in both Directions? choose between true or false");
                        //calling boolvalue function
                        bool directionV = boolValue();
                        Console.Clear();
                        network.CloseTrack(linename2, StationA, StationB, directionV);
                        Continue();
                        break;


                    //Case when Enginner chooses to Open Track
                    case 4:
                        Console.Clear();
                        if (PrintClosedTracks() > 0)
                        {
                            var lines3 = network.GetLines();

                            Console.WriteLine("");
                            Console.Write("Enter Line name to Open track: ");
                            string? Linename = Console.ReadLine();
                            while (Linename == "" || Linename is null || !lines3.Contains(Linename))
                            {
                                Console.Write("Enter Line Name again: ");
                                Linename = Console.ReadLine();
                            }

                            var lineStations3 = network.GetAllStations(Linename);

                            Console.WriteLine("");
                            Console.Write("Enter Station name to Open From: ");
                            string stationA = Console.ReadLine();
                            while (stationA == "" || stationA is null
                                || !lineStations3.Contains(stationA))
                            {
                                Console.Write("Enter Station again: ");
                                stationA = Console.ReadLine();
                            }

                            Console.WriteLine("");
                            Console.Write("Enter Station name to Open Track To: ");
                            string stationB = Console.ReadLine();
                            while (stationB == "" || stationB is null
                                || !lineStations3.Contains(stationB))
                            {
                                Console.Write("Enter Station again: ");
                                stationB = Console.ReadLine();
                            }

                            Console.WriteLine("Is the Track Open in both Directions? choose between true or false");
                            //calling boolvalue function
                            bool dir = boolValue();
                            Console.Clear();
                            network.OpenTrack(Linename, stationA, stationB, dir);
                        }
                        Continue();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("CLOSED TRACKS");
                        Console.WriteLine("");
                        PrintClosedTracks();
                        Continue();
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("DELAYED TRACKS");
                        Console.WriteLine("");
                        PrintDelayedTracks();
                        Continue();
                        break;

                    case 7:
                        break;

                    default:
                        Console.WriteLine("Invalid Option Entered! Please choose Valid Option");
                        break;
                }
            } while (choice != 7);

        }


        public int PrintDelayedTracks()
        {
            var tracks = network.GetDelayedTracks();
            var dict = new Dictionary<string, List<string>>();
            foreach (var track in tracks)
            {
                string[] stationFrom = track.Source.Split(new string[] { ", " }, 2, StringSplitOptions.None);
                string[] stationto = track.Target.Split(new string[] { ", " }, 2, StringSplitOptions.None);
                if (!dict.ContainsKey(stationFrom[1]))
                {
                    var list = new List<string>()
                    {
                        $"{stationFrom[0]} to {stationto[0]}, {track.GetTime()}+{track.GetDelay()}min"
                    };
                    dict.Add(stationFrom[1], list);
                }
                else
                {
                    var list = dict[stationFrom[1]];
                    list.Add($"{stationFrom[0]} to {stationto[0]}, {track.GetTime()}+{track.GetDelay()}min");
                }
            }

            if (dict.Count > 0)
            {
                foreach (var pair in dict)
                {
                    Console.WriteLine($"{pair.Key}:");
                    Console.WriteLine("-------------");
                    foreach (var track in pair.Value)
                    {
                        Console.WriteLine(track);
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("No delayed tracks");
            }
            return dict.Count;
        }


        public int PrintClosedTracks()
        {
            var tracks = network.GetClosedTracks();
            var dict = new Dictionary<string, List<string>>();
            foreach (var track in tracks)
            {
                string[] stationFrom = track.Source.Split(new string[] { ", " }, 2, StringSplitOptions.None);
                string[] stationto = track.Target.Split(new string[] { ", " }, 2, StringSplitOptions.None);
                if (!dict.ContainsKey(stationFrom[1]))
                {
                    var list = new List<string>()
                    {
                        $"{stationFrom[0]} to {stationto[0]}"
                    };
                    dict.Add(stationFrom[1], list);
                }
                else
                {
                    var list = dict[stationFrom[1]];
                    list.Add($"{stationFrom[0]} to {stationto[0]}");
                }
            }

            if (dict.Count > 0)
            {
                foreach (var pair in dict)
                {
                    Console.WriteLine($"{pair.Key}:");
                    Console.WriteLine("-------------");
                    foreach (var track in pair.Value)
                    {
                        Console.WriteLine(track);
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("No closed tracks");
            }

            return dict.Count;
        }


        public void ShowPath(List<Edge> path)
        {
            Console.Clear();
            Console.WriteLine($"Journey from {path[0].Target} to {path[path.Count - 1].Source}");
            Console.WriteLine("");
            if (path == null || path.Count == 0)
            {
                Console.WriteLine("Path is not found");
                Continue();
                return;
            }

            int skip = 0;
            double skipTime = 0.0;
            double total = 0.0;

            for (int i = 0; i < path.Count; i++)
            {
                var travelTime = path[i].GetTravelTime() != null ? Convert.ToDouble(path[i].GetTravelTime()) : 0.0;
                total += travelTime;
                string[] stationFrom = path[i].Source.Split(new string[] { ", " }, 2, StringSplitOptions.None);
                string[] stationTo = path[i].Target.Split(new string[] { ", " }, 2, StringSplitOptions.None);

                if (stationFrom[1] == stationTo[1])
                {
                    skip += 1;
                    skipTime += travelTime;
                }
                else
                {
                    if (skip > 0)
                    {
                        Console.Write($"{stationFrom[1]}: ");
                        Console.Write($"{path[i - skip].Source.Split(new string[] { ", " }, 2, StringSplitOptions.None)[0]} to ");
                        Console.WriteLine($"{stationFrom[0]}, {skipTime}min");

                        skip = 0;
                        skipTime = 0.0;
                    }
                    Console.WriteLine($"Change from {path[i].Source} " +
                        $" to {path[i].Target} " +
                        $", {path[i].GetTravelTime()}min");
                }
            }

            if (skip > 0)
            {
                var lastStation = path[path.Count - 1].Target.Split(new string[] { ", " }, 2, StringSplitOptions.None);
                Console.Write($"{lastStation[1]}: ");
                Console.Write($"{path[path.Count - skip].Source.Split(new string[] { ", " }, 2, StringSplitOptions.None)[0]} to ");
                Console.WriteLine($"{lastStation[0]}, {skipTime}min");
            }

            Console.WriteLine($"Total travel time: {total}min");

            Continue();
            return;
        }


        //utility function to get valid bool value as an console input
        private bool boolValue()
        {
            string input;
            do
            {
                Console.WriteLine("Enter 'true' or 'false' ");
                input = Console.ReadLine().ToLower();
            } while (input != "true" && input != "false");
            
            return input == "true";
        }

        private void Continue()
        {
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            return;
        }

        public void StartJourney()
        {
            int choice = 0;
            while (choice != 3)
            {
                choice = Tfl_menu();
                switch (choice)
                {
                    case 1:
                        // starting customer opetations
                        Customer_Operation();
                        break;

                    case 2:
                        Engineer_Operation();
                        break;
                }
            }
        }
    }
}
