using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
    /// <summary>
    /// This calss defines the body of the car
    /// </summary>
	public class Body
	{
		private string bodyType;

        // Contructor to initialize the class
		public Body(string bodyType)
		{
            // Set the body type
            BodyType = bodyType;
		}

        public string BodyType { get => bodyType; set => bodyType = value; }
	}
}
