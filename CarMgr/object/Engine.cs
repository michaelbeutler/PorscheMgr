using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Engine
	{
		private string engineLayout;
		private string engineDesign;
		private int cylinderNum;
		private double bore;
		private double stroke;
		private double displacement;
		private double maxPower;
		private double maxPowerAtRpm;
		private double maxTorque;
		private double maxEngineSpeed;
		private string image;

		public Engine(string engineLayout, string engineDesign, int cylinderNum, double bore, double stroke, double displacement, double maxPower, double maxPowerAtRPM, double maxTorque, double maxEngineSpeed)
		{
            EngineLayout = engineLayout;
            EngineDesign = engineDesign;
            CylinderNum = cylinderNum;
            Bore = bore;
            Stroke = stroke;
            Displacement = displacement;
            MaxPower = maxPower;
            MaxPowerAtRpm = maxPowerAtRPM;
            MaxTorque = maxTorque;
            MaxEngineSpeed = maxEngineSpeed;
		}

        public string EngineLayout { get => engineLayout; set => engineLayout = value; }
        public string EngineDesign { get => engineDesign; set => engineDesign = value; }
        public int CylinderNum { get => cylinderNum; set => cylinderNum = value; }
        public double Bore { get => bore; set => bore = value; }
        public double Stroke { get => stroke; set => stroke = value; }
        public double Displacement { get => displacement; set => displacement = value; }
        public double MaxPower { get => maxPower; set => maxPower = value; }
        public double MaxPowerAtRpm { get => maxPowerAtRpm; set => maxPowerAtRpm = value; }
        public double MaxTorque { get => maxTorque; set => maxTorque = value; }
        public double MaxEngineSpeed { get => maxEngineSpeed; set => maxEngineSpeed = value; }
        public string Image { get => image; set => image = value; }
	}
}
