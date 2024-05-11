using System;
using QuickGraph;

namespace TFLAppLibraries
{
    public abstract class Edge : IEdge<string>
    {

        protected double time;
        public string Source { get; set; }
        public string Target { get; set; }

        public Edge(double time, string stationFrom, string stationTo)
        {
            this.time = time;
            this.Source = stationFrom;
            this.Target = stationTo;
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

