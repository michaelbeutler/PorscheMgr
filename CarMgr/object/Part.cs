using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public abstract class Part
	{
		private string description;
		private string image;
		private string name;
		private double price;

        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
	}
}
