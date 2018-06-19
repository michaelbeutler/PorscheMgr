using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Brand
	{
		private string name;

		public Brand(string name)
		{
            Name = name;
		}

        public string Name { get => name; set => name = value; }
	}
}
