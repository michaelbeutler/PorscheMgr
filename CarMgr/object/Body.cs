using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Body
	{
		private string bodyType;

		public Body(string bodyType)
		{
			throw new NotImplementedException();
		}

        public string BodyType { get => bodyType; set => bodyType = value; }
	}
}
