using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class ChassisAndSuspension
	{
		private string frontAxle;
		private string rearAxle;
		private string brakes;
		private string steering;
		private string abs;
		private string tractionControl;
		private string stabilityControl;

        public ChassisAndSuspension(string frontAxle, string rearAxle, string brakes, string steering, string abs, string tractionControl, string stabilityControl)
        {
            FrontAxle = frontAxle;
            RearAxle = rearAxle;
            Brakes = brakes;
            Steering = steering;
            Abs = abs;
            TractionControl = tractionControl;
            StabilityControl = stabilityControl;
        }

        public string FrontAxle { get => frontAxle; set => frontAxle = value; }
        public string RearAxle { get => rearAxle; set => rearAxle = value; }
        public string Brakes { get => brakes; set => brakes = value; }
        public string Steering { get => steering; set => steering = value; }
        public string Abs { get => abs; set => abs = value; }
        public string TractionControl { get => tractionControl; set => tractionControl = value; }
        public string StabilityControl { get => stabilityControl; set => stabilityControl = value; }
	}
}
