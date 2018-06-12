using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class FuelConsumption
	{
		private double city;
		private double highway;
		private double combined;
		private string epaDisclaimer;

		public FuelConsumption(double city, double highway, double combined, string epaDisclaimer)
		{
            City = city;
            Highway = highway;
            Combined = combined;
            EpaDisclaimer = epaDisclaimer;
		}

        public double City { get => city; set => city = value; }
        public double Highway { get => highway; set => highway = value; }
        public double Combined { get => combined; set => combined = value; }
        public string EpaDisclaimer { get => epaDisclaimer; set => epaDisclaimer = value; }
	}
}
