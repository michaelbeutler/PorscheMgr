using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Transmission
	{
		private string drivetrain;
		private string manualTransmission;
		private string automaticTransmission;

		public Transmission(string drivetrain, string manualTransmission, string automaticTransmission)
		{
            Drivetrain = drivetrain;
            ManualTransmission = manualTransmission;
            AutomaticTransmission = automaticTransmission;
        }

        public string Drivetrain { get => drivetrain; set => drivetrain = value; }
        public string ManualTransmission { get => manualTransmission; set => manualTransmission = value; }
        public string AutomaticTransmission { get => automaticTransmission; set => automaticTransmission = value; }
	}
}
