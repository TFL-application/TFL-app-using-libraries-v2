using System;
namespace Edge_track_and_change
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


