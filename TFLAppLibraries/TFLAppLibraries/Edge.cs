using System;
namespace TFLAppLibraries
{
    public abstract class Edge
    {

        protected double time;
        protected string stationFrom;
        protected string stationTo;

        public Edge(double time, string stationFrom, string stationTo)
        {
            this.time = time;
            this.stationFrom = stationFrom;
            this.stationTo = stationTo;
        }

        public double GetTime()
        {
            return time;
        }


        public void SetTime(double time)
        {
            this.time = time;
        }


        public virtual double GetTravelTime()
        {
            return time;
        }


    }
}

