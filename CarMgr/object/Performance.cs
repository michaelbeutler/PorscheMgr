using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Performance
	{
		private double topTrackSpeed;
        private double zeroToSixty;

        public Performance(double topTrackSpeed, double zeroToSixty)
        {
            TopTrackSpeed = topTrackSpeed;
            ZeroToSixty = zeroToSixty;
        }

        public double TopTrackSpeed { get => topTrackSpeed; set => topTrackSpeed = value; }
        public double ZeroToSixty { get => zeroToSixty; set => zeroToSixty = value; }
	}
}
