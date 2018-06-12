using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class OpticPart: Part
	{
		private string type;

        public OpticPart(string description, string image, string name, double price, string type)
        {
            base.Description = description;
            base.Image = image;
            base.Name = name;
            base.Price = price;

            Type = type;
        }

        public string Type { get => type; set => type = value; }
	}
}
