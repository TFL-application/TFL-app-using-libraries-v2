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

            // Victoria
            // 1. Declare line
            var victoriaName = "Victoria";

            // 2. Create stations and distances for the line
            var victoriaLineStations = new List<string>()
            {
                "Brixton",
                "Stockwell",
                "Vauxhall",
                "Pimlico",
                "Victoria",
                "Green Park",
                "Oxford Circus",
                "Warren Street",
                "Euston",
                "King's Cross St. Pancras",
                "Highbury & Islington",
                "Finsbury Park",
                "Seven Sisters",
                "Tottenham Hale",
                "Blackhorse Road",
                "Walthamstow Central"
            };

            var victoriaLineDistances = new List<double>()
            {
                2.0,    // Brixton          to Stockwell
                3.0,    // Stockwell        to Vauxhall
                1.0,    // Vauxhall         to Pimlico
                2.0,    // Pimlico          to Victoria
                2.0,    // Victoria         to Green Park
                2.0,    // Green Park       to Oxford Circus
                2.0,    // Oxford Circus    to Warren Street
                1.0,    // Warren Street    to Euston
                2.0,    // Euston           to King's Cross St. Pancras
                3.0,    // King's Cross     to Highbury & Islington
                3.0,    // Highbury & Islington to Finsbury Park
                4.0,    // Finsbury Park    to Seven Sisters
                2.0,    // Seven Sisters    to Tottenham Hale
                2.0,    // Tottenham Hale   to Blackhorse Road
                2.0     // Blackhorse Road  to Walthamstow Central
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
                "Stanmore",
                "Canons Park",
                "Queensbury",
                "Kingsbury",
                "Wembley Park",
                "Neasden",
                "Dollis Hill",
                "Willesden Green",
                "Kilburn",
                "West Hampstead",
                "Finchley Road & Frognal",
                "Swiss Cottage",
                "St. John's Wood",
                "Baker Street",
                "Bond Street",
                "Green Park",
                "Westminster",
                "Waterloo",
                "Southwark",
                "London Bridge",
                "Bermondsey",
                "Canada Water",
                "Canary Wharf",
                "North Greenwich",
                "Canning Town",
                "West Ham",
                "Stratford"
            };

            var jubileeLineDistances = new List<double>()
            {
                2.0,    // Stanmore           to Canons Park
                3.0,    // Canons Park        to Queensbury
                2.0,    // Queensbury         to Kingsbury
                4.0,    // Kingsbury          to Wembley Park
                3.0,    // Wembley Park       to Neasden
                2.0,    // Neasden            to Dollis Hill
                2.0,    // Dollis Hill        to Willesden Green
                2.0,    // Willesden Green    to Kilburn
                2.0,    // Kilburn            to West Hampstead
                1.0,    // West Hampstead     to Finchley Road
                2.0,    // Finchley Road      to Swiss Cottage
                2.0,    // Swiss Cottage      to St. John's Wood
                3.0,    // St. John's Wood    to Baker Street
                3.0,    // Baker Street       to Bond Street
                2.0,    // Bond Street        to Green Park
                3.0,    // Green Park         to Westminster
                2.0,    // Westminster        to Waterloo
                1.0,    // Waterloo           to Southwark
                2.0,    // Southwark          to London Bridge
                3.0,    // London Bridge      to Bermondsey
                2.0,    // Bermondsey         to Canada Water
                3.0,    // Canada Water       to Canary Wharf
                2.0,    // Canary Wharf       to North Greenwich
                3.0,    // North Greenwich    to Canning Town
                3.0,    // Canning Town       to West Ham
                3.0,    // West Ham           to Stratford
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
                "Hammersmith",
                "Goldhawk Road",
                "Shepherd's Bush Market",
                "Wood Lane",
                "Latimer Road",
                "Ladbroke Grove",
                "Westbourne Park",
                "Royal Oak",
                "Paddington",
                "Edgware Road",
                "Baker Street",
                "Great Portland Street",
                "Euston Square",
                "King's Cross St. Pancras",
                "Farringdon",
                "Barbican",
                "Moorgate",
                "Liverpool Street",
                "Aldgate",
                "Tower Hill",
                "Monument",
                "Cannon Street",
                "Mansion House",
                "Blackfriars",
                "Temple",
                "Embankment",
                "Westminster",
                "St. James's Park",
                "Victoria",
                "Sloane Square",
                "South Kensington",
                "Gloucester Road",
                "High Street Kensington",
                "Notting Hill Gate",
                "Bayswater",
                "Paddington (inner)",
                "Edgware Road (inner)"
            };

            var circleLineDistances = new List<double>()
            {
                2.0,    // Hammersmith                to Goldhawk Road
                1.0,    // Goldhawk Road              to Shepherd's Bush Market
                1.0,    // Shepherd's Bush Market     to Wood Lane
                1.0,    // Wood Lane                  to Latimer Road
                1.0,    // Latimer Road               to Ladbroke Grove
                2.0,    // Ladbroke Grove             to Westbourne Park
                2.0,    // Westbourne Park            to Royal Oak
                1.0,    // Royal Oak                  to Paddington
                2.0,    // Paddington                 to Edgware Road (Circle)
                2.0,    // Edgware Road (Circle)      to Baker Street
                2.0,    // Baker Street               to Great Portland Street
                2.0,    // Great Portland Street      to Euston Square
                2.0,    // Euston Square              to King's Cross St. Pancras
                3.0,    // King's Cross St. Pancras   to Farringdon
                2.0,    // Farringdon                 to Barbican
                1.0,    // Barbican                   to Moorgate
                2.0,    // Moorgate                   to Liverpool Street
                2.0,    // Liverpool Street           to Aldgate
                2.0,    // Aldgate                    to Tower Hill
                2.0,    // Tower Hill                 to Monument
                1.0,    // Monument                   to Cannon Street
                1.0,    // Cannon Street              to Mansion House
                1.0,    // Mansion House              to Blackfriars
                2.0,    // Blackfriars                to Temple
                1.0,    // Temple                     to Embankment
                2.0,    // Embankment                 to Westminster
                1.0,    // Westminster                to St. James's Park
                2.0,    // St. James's Park           to Victoria
                2.0,    // Victoria                   to Sloane Square
                2.0,    // Sloane Square              to South Kensington
                2.0,    // South Kensington           to Gloucester Road
                3.0,    // Gloucester Road            to High Street Kensington
                2.0,    // High Street Kensington     to Notting Hill Gate
                2.0,    // Notting Hill Gate          to Bayswater
                2.0,    // Bayswater                  to Paddington (inner)
                2.0     // Paddington (inner)         to Edgware Road (inner)
            };

            // 3. Add line
            this.AddLine(circleName, circleLineStations, circleLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var bakerStreet1 = new Change("Baker Street, Circle", "Baker Street, Jubilee");
            var bakerStreet2 = new Change("Baker Street, Jubilee", "Baker Street, Circle");
            var westminster1 = new Change("Westminster, Circle", "Westminster, Jubilee");
            var westminster2 = new Change("Westminster, Jubilee", "Westminster, Circle");
            var victoria1 = new Change("Victoria, Circle", "Victoria, Victoria");
            var victoria2 = new Change("Victoria, Victoria", "Victoria, Circle");
            var kingsCross1 = new Change("King's Cross St. Pancras, Circle", "King's Cross St. Pancras, Victoria");
            var kingsCross2 = new Change("King's Cross St. Pancras, Victoria", "King's Cross St. Pancras, Circle");
            network.AddEdge(bakerStreet1);
            network.AddEdge(bakerStreet2);
            network.AddEdge(westminster1);
            network.AddEdge(westminster2);
            network.AddEdge(victoria1);
            network.AddEdge(victoria2);
            network.AddEdge(kingsCross1);
            network.AddEdge(kingsCross2);

            // Overground
            // 1. Declare line
            var overgroundaName = "Overground";

            // 2. Create stations and distances for the line
            var overgroundLineStations = new List<string>()
            {
                "Richmond",
                "Kew Gardens",
                "Gunnersbury",
                "South Acton",
                "Acton Central",
                "Willesden Junction",
                "Kensal Rise",
                "Brondesbury Park",
                "Brondesbury",
                "West Hampstead",
                "Finchley Road & Frognal",
                "Hampstead Heath",
                "Gospel Oak",
                "Kentish Town West",
                "Camden Road",
                "Caledonian Road & Barnsbury",
                "Highbury & Islington",
                "Canonbury",
                "Dalston Kingsland",
                "Hackney Central",
                "Homerton",
                "Hackney Wick",
                "Stratford"
            };

            var overgroundLineDistances = new List<double>()
            {
                3.0,    // Richmond                        to Kew Gardens
                3.0,    // Kew Gardens                     to Gunnersbury
                3.0,    // Gunnersbury                     to South Acton
                3.0,    // South Acton                     to Acton Central
                4.0,    // Acton Central                   to Willesden Junction
                3.0,    // Willesden Junction              to Kensal Rise
                2.0,    // Kensal Rise                     to Brondesbury Park
                2.0,    // Brondesbury Park                to Brondesbury
                1.0,    // Brondesbury                     to West Hampstead
                2.0,    // West Hampstead                  to Finchley Road & Frognal
                2.0,    // Finchley Road & Frognal         to Hampstead Heath
                2.0,    // Hampstead Heath                 to Gospel Oak
                2.0,    // Gospel Oak                      to Kentish Town West
                3.0,    // Kentish Town West               to Camden Road
                3.0,    // Camden Road                     to Caledonian Road & Barnsbury
                2.0,    // Caledonian Road & Barnsbury     to Highbury & Islington
                1.0,    // Highbury & Islington            to Canonbury
                2.0,    // Canonbury                       to Dalston Kingsland
                2.0,    // Dalston Kingsland               to Hackney Central
                2.0,    // Hackney Central                 to Homerton
                3.0,    // Homerton                        to Hackney Wick
                3.0,    // Hackney Wick                    to Stratford
            };

            // 3. Add line
            this.AddLine(overgroundaName, overgroundLineStations, overgroundLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var westHampstead1 = new Change("West Hampstead, Overground", "West Hampstead, Jubilee");
            var westHampstead2 = new Change("West Hampstead, Jubilee", "West Hampstead, Overground");
            var finchley1 = new Change("Finchley Road & Frognal, Overground", "Finchley Road & Frognal, Jubilee");
            var finchley2 = new Change("Finchley Road & Frognal, Jubilee", "Finchley Road & Frognal, Overground");
            var Stratford1 = new Change("Stratford, Overground", "Stratford, Jubilee");
            var Stratford2 = new Change("Stratford, Jubilee", "Stratford, Overground");
            var victoria3 = new Change("Highbury & Islington, Overground", "Highbury & Islington, Victoria");
            var victoria4 = new Change("Highbury & Islington, Victoria", "Highbury & Islington, Overground");
            network.AddEdge(westHampstead1);
            network.AddEdge(westHampstead2);
            network.AddEdge(finchley1);
            network.AddEdge(finchley2);
            network.AddEdge(Stratford1);
            network.AddEdge(Stratford2);
            network.AddEdge(victoria3);
            network.AddEdge(victoria4);

            // Bakerloo
            // 1. Declare line
            var bakerlooName = "Bakerloo";

            // 2. Create stations and distances for the line
            var bakerlooLineStations = new List<string>()
            {
                "Embankment",
                "Charing Cross",
                "Piccadilly Circus",
                "Oxford Circus",
                "Regent's Park",
                "Baker Street"
            };

            var bakerlooLineDistances = new List<double>()
            {
                1.0,    // Embankment             to Charing Cross
                2.0,    // Charing Cross          to Piccadilly Circus
                2.0,    // Piccadilly Circus      to Oxford Circus
                2.0,    // Oxford Circus          to Regent's Park
                2.0     // Regent's Park          to Baker Street
            };

            // 3. Add line
            this.AddLine(bakerlooName, bakerlooLineStations, bakerlooLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var bakerStreet3 = new Change("Baker Street, Bakerloo", "Baker Street, Circle");
            var bakerStreet4 = new Change("Baker Street, Circle", "Baker Street, Bakerloo");
            var bakerStreet5 = new Change("Baker Street, Bakerloo", "Baker Street, Jubilee");
            var bakerStreet6 = new Change("Baker Street, Jubilee", "Baker Street, Bakerloo");
            var oxfordCircus1 = new Change("Oxford Circus, Bakerloo", "Oxford Circus, Victoria");
            var oxfordCircus2 = new Change("Oxford Circus, Victoria", "Oxford Circus, Bakerloo");
            var Embankment1 = new Change("Embankment, Bakerloo", "Embankment, Circle");
            var Embankment2 = new Change("Embankment, Circle", "Embankment, Bakerloo");
            network.AddEdge(bakerStreet3);
            network.AddEdge(bakerStreet4);
            network.AddEdge(bakerStreet5);
            network.AddEdge(bakerStreet6);
            network.AddEdge(oxfordCircus1);
            network.AddEdge(oxfordCircus2);
            network.AddEdge(Embankment1);
            network.AddEdge(Embankment2);

            // Central
            // 1. Declare line
            var centralName = "Central";

            // 2. Create stations and distances for the line
            var centralLineStations = new List<string>()
            {
                "White City",
                "Shepherd's Bush",
                "Holland Park",
                "Notting Hill Gate",
                "Queensway",
                "Lancaster Gate",
                "Marble Arch",
                "Bond Street",
                "Oxford Circus",
                "Tottenham Court Road",
                "Holborn",
                "Chancery Lane",
                "St. Paul's",
                "Bank",
                "Liverpool Street"
            };

            var centralLineDistances = new List<double>()
            {
                2.0,    // White City                to Shepherd's Bush
                2.0,    // Shepherd's Bush           to Holland Park
                1.0,    // Holland Park              to Notting Hill Gate
                2.0,    // Notting Hill Gate         to Queensway
                2.0,    // Queensway                 to Lancaster Gate
                2.0,    // Lancaster Gate            to Marble Arch
                1.0,    // Marble Arch               to Bond Street
                2.0,    // Bond Street               to Oxford Circus
                1.0,    // Oxford Circus             to Tottenham Court Road
                2.0,    // Tottenham Court Road      to Holborn
                2.0,    // Holborn                   to Chancery Lane
                2.0,    // Chancery Lane             to St. Paul's
                2.0,    // St. Paul's                to Bank
                2.0     // Bank                      to Liverpool Street
            };


            // 3. Add line
            this.AddLine(centralName, centralLineStations, centralLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var bondStreet1 = new Change("Bond Street, Central", "Bond Street, Jubilee");
            var bondStreet2 = new Change("Bond Street, Jubilee", "Bond Street, Central");
            var oxford1 = new Change("Oxford Circus, Central", "Oxford Circus, Victoria");
            var oxford2 = new Change("Oxford Circus, Victoria", "Oxford Circus, Central");
            var whitrCity = new Change("White City, Central", "Wood Lane, Circle");
            var woodlane = new Change("Wood Lane, Circle", "White City, Central");
            var notting1 = new Change("Notting Hill Gate, Central", "Notting Hill Gate, Circle");
            var notting2 = new Change("Notting Hill Gate, Circle", "Notting Hill Gate, Central");
            var liver1 = new Change("Liverpool Street, Central", "Liverpool Street, Circle");
            var liver2 = new Change("Liverpool Street, Circle", "Liverpool Street, Central");
            var ox1 = new Change("Oxford Circus, Central", "Oxford Circus, Bakerloo");
            var ox2 = new Change("Oxford Circus, Bakerloo", "Oxford Circus, Central");
            network.AddEdge(bondStreet1);
            network.AddEdge(bondStreet2);
            network.AddEdge(oxford1);
            network.AddEdge(oxford2);
            network.AddEdge(whitrCity);
            network.AddEdge(woodlane);
            network.AddEdge(notting1);
            network.AddEdge(notting2);
            network.AddEdge(liver1);
            network.AddEdge(liver2);
            network.AddEdge(ox1);
            network.AddEdge(ox2);


            // Central
            // 1. Declare line
            var piccadillyName = "Piccadilly";

            // 2. Create stations and distances for the line
            var piccadillyLineStations = new List<string>()
            {
                "Hammersmith",
                "Barons Court",
                "Earl's Court",
                "Gloucester Road",
                "South Kensington",
                "Knightsbridge",
                "Hyde Park Corner",
                "Green Park",
                "Piccadilly Circus",
                "Leicester Square",
                "Covent Garden",
                "Holborn",
                "Russell Square",
                "King's Cross St. Pancras"
            };

            var piccadillyLineDistances = new List<double>()
            {
                2.0,    // Hammersmith                  to Barons Court
                3.0,    // Barons Court                 to Earl's Court
                2.0,    // Earl's Court                 to Gloucester Road
                1.0,    // Gloucester Road              to South Kensington
                3.0,    // South Kensington             to Knightsbridge
                1.0,    // Knightsbridge                to Hyde Park Corner
                2.0,    // Hyde Park Corner             to Green Park
                1.0,    // Green Park                   to Piccadilly Circus
                2.0,    // Piccadilly Circus            to Leicester Square
                1.0,    // Leicester Square             to Covent Garden
                2.0,    // Covent Garden                to Holborn
                1.0,    // Holborn                      to Russell Square
                2.0     // Russell Square               to King's Cross St. Pancras
            };

            // 3. Add line
            this.AddLine(piccadillyName, piccadillyLineStations, piccadillyLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var greenPark1 = new Change("Green Park, Piccadilly", "Green Park, Jubilee");
            var greenPark2 = new Change("Green Park, Jubilee", "Green Park, Piccadilly");
            var greenPark3 = new Change("Green Park, Piccadilly", "Green Park, Victoria");
            var greenPark4 = new Change("Green Park, Victoria", "Green Park, Piccadilly");
            var kingsCross3 = new Change("King's Cross St. Pancras, Piccadilly", "King's Cross St. Pancras, Victoria");
            var kingsCross4 = new Change("King's Cross St. Pancras, Victoria", "King's Cross St. Pancras, Piccadilly");
            var hammersmith1 = new Change("Hammersmith, Piccadilly", "Hammersmith, Circle");
            var hammersmith2 = new Change("Hammersmith, Circle", "Hammersmith, Piccadilly");
            var kingsCross5 = new Change("King's Cross St. Pancras, Piccadilly", "King's Cross St. Pancras, Circle");
            var kingsCross6 = new Change("King's Cross St. Pancras, Circle", "King's Cross St. Pancras, Piccadilly");
            var southKensington1 = new Change("South Kensington, Piccadilly", "South Kensington, Circle");
            var southKensington2 = new Change("South Kensington, Circle", "South Kensington, Piccadilly");
            var piccadillyCircus1 = new Change("Piccadilly Circus, Piccadilly", "Piccadilly Circus, Bakerloo");
            var piccadillyCircus2 = new Change("Piccadilly Circus, Bakerloo", "Piccadilly Circus, Piccadilly");
            var holborn1 = new Change("Holborn, Piccadilly", "Holborn, Central");
            var holborn2 = new Change("Holborn, Central", "Holborn, Piccadilly");
            network.AddEdge(greenPark1);
            network.AddEdge(greenPark2);
            network.AddEdge(greenPark3);
            network.AddEdge(greenPark4);
            network.AddEdge(kingsCross3);
            network.AddEdge(kingsCross4);
            network.AddEdge(hammersmith1);
            network.AddEdge(hammersmith2);
            network.AddEdge(kingsCross5);
            network.AddEdge(kingsCross6);
            network.AddEdge(southKensington1);
            network.AddEdge(southKensington2);
            network.AddEdge(piccadillyCircus1);
            network.AddEdge(piccadillyCircus2);
            network.AddEdge(holborn1);
            network.AddEdge(holborn2);

            // Nothern West
            // 1. Declare line
            var northernLineWestName = "Northern";

            // 2. Create stations and distances for the line
            var northernLineWestStations = new List<string>()
            {
                "Euston",
                "Warren Street",
                "Goodge Street",
                "Tottenham Court Road",
                "Leicester Square",
                "Charing Cross",
                "Embankment"
            };

            var nothernLineDistances = new List<double>()
            {
                1.0,    // Euston                    to Warren Street
                2.0,    // Warren Street             to Goodge Street
                1.0,    // Goodge Street             to Tottenham Court Road
                1.0,    // Tottenham Court Road      to Leicester Square
                2.0,    // Leicester Square          to Charing Cross
                1.0     // Charing Cross             to Embankment
            };

            // 3. Add line
            this.AddLine(northernLineWestName, northernLineWestStations, nothernLineDistances);

            // 4. Create connections to the stations on the previous lines both ways
            var warrenStreet1 = new Change("Warren Street, Northern", "Warren Street, Victoria");
            var warrenStreet2 = new Change("Warren Street, Victoria", "Warren Street, Northern");
            var euston1 = new Change("Euston, Northern", "Euston, Victoria");
            var euston2 = new Change("Euston, Victoria", "Euston, Northern");
            var embankment1 = new Change("Embankment, Northern", "Embankment, Circle");
            var embankment2 = new Change("Embankment, Circle", "Embankment, Northern");
            var charingCross1 = new Change("Charing Cross, Northern", "Charing Cross, Bakerloo");
            var charingCross2 = new Change("Charing Cross, Bakerloo", "Charing Cross, Northern");
            var tottenhamCourtRoad1 = new Change("Tottenham Court Road, Northern", "Tottenham Court Road, Central");
            var tottenhamCourtRoad2 = new Change("Tottenham Court Road, Central", "Tottenham Court Road, Northern");
            var leicesterSquare1 = new Change("Leicester Square, Northern", "Leicester Square, Piccadilly");
            var leicesterSquare2 = new Change("Leicester Square, Piccadilly", "Leicester Square, Northern");
            network.AddEdge(warrenStreet1);
            network.AddEdge(warrenStreet2);
            network.AddEdge(euston1);
            network.AddEdge(euston2);
            network.AddEdge(embankment1);
            network.AddEdge(embankment2);
            network.AddEdge(charingCross1);
            network.AddEdge(charingCross2);
            network.AddEdge(tottenhamCourtRoad1);
            network.AddEdge(tottenhamCourtRoad2);
            network.AddEdge(leicesterSquare1);
            network.AddEdge(leicesterSquare2);

            // Nothern East
            // 1. Declare line
            var northernLineEastName = "Northern";

            // 2. Create stations and distances for the line
            var northernLineEastStations = new List<string>()
            {
                "Moorgate",
                "Bank"
            };

            var nothernLineEastDistances = new List<double>()
            {
                2.0,    // Moorgate     to Bank
            };
            var moorg = northernLineEastStations[0] + ", " + northernLineEastName;
            var bank = northernLineEastStations[1] + ", " + northernLineEastName;
            network.AddVertex(moorg);
            network.AddVertex(bank);
            var track1 = new Track(nothernLineEastDistances[0], moorg, bank);
            var track2 = new Track(nothernLineEastDistances[0], bank, moorg);
            network.AddEdge(track1);
            network.AddEdge(track2);

            // 3. Add line
            var n = this.lines["Northern"];
            n.AddRange(northernLineEastStations);

            // 4. Create connections to the stations on the previous lines both ways
            var moorgate1 = new Change("Moorgate, Northern", "Moorgate, Circle");
            var moorgate2 = new Change("Moorgate, Circle", "Moorgate, Northern");
            var bank1 = new Change("Bank, Northern", "Monument, Circle");
            var bank2 = new Change("Monument, Circle", "Bank, Northern");
            var bank3 = new Change("Bank, Northern", "Bank, Central");
            var bank4 = new Change("Bank, Central", "Bank, Northern");
            network.AddEdge(moorgate1);
            network.AddEdge(moorgate2);
            network.AddEdge(bank1);
            network.AddEdge(bank2);
            network.AddEdge(bank3);
            network.AddEdge(bank4);
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

