﻿using System;
namespace TFLAppLibraries
{
    public class Track : Edge
    {
        private bool isOpen;
        private double delay;

        // Constructor including parameters for the base class

        public Track (double time, string stationFrom, string stationTo, bool isOpen = true, double delay = 0.0)
    : base(time, stationFrom, stationTo)
        {
            this.isOpen = isOpen;
            this.delay = delay;
        }

        // Override the abstract method from Edge class to calculate travel time
        public override double? GetTravelTime()
        {
            if (this.isOpen)
            {
                return base.GetTravelTime() + delay;
            }
            else
            {
                return null;
            }
        }

        public bool GetIsOpen()
        {
            return isOpen;
        }


        public void SetIsOpen(bool isOpen)
        {
            this.isOpen = isOpen;
        }

        public double GetDelay()
        {
            return delay;
        }


        public void SetDelay(double delay)
        {
            this.delay = delay;
        }

    }
}
