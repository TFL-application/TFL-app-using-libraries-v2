using System;
namespace TFLAppLibraries
{
	public class Change : Edge
    {
		public Change(string stationFrom, string stationTo)
        : base(2.0, stationFrom, stationTo)
        {

        }




        public override double GetTravelTime()
        {
            return time;

        }

        }
	}


