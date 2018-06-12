using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class PerformancePart: Part
	{
		private double maxPower;
		private double maxTorque;
		private double topTrackSpeed;
		private double zeroToSixty;
		private double maxEngineSpeed;
		private double stroke;
		private double bore;
		private double displacment;

        public PerformancePart(string description, string image, string name, double price, double maxPower, double maxTorque, double topTrackSpeed, double zeroToSixty, double maxEngineSpeed, double stroke, double bore, double displacment)
        {
            base.Description = description;
            base.Image = image;
            base.Name = name;
            base.Price = price;

            MaxPower = maxPower;
            MaxTorque = maxTorque;
            TopTrackSpeed = topTrackSpeed;
            ZeroToSixty = zeroToSixty;
            MaxEngineSpeed = maxEngineSpeed;
            Stroke = stroke;
            Bore = bore;
            Displacment = displacment;
        }

        public double MaxPower { get => maxPower; set => maxPower = value; }
        public double MaxTorque { get => maxTorque; set => maxTorque = value; }
        public double TopTrackSpeed { get => topTrackSpeed; set => topTrackSpeed = value; }
        public double ZeroToSixty { get => zeroToSixty; set => zeroToSixty = value; }
        public double MaxEngineSpeed { get => maxEngineSpeed; set => maxEngineSpeed = value; }
        public double Stroke { get => stroke; set => stroke = value; }
        public double Bore { get => bore; set => bore = value; }
        public double Displacment { get => displacment; set => displacment = value; }

        public void Print()
		{
			throw new NotImplementedException();
		}
	}
}
