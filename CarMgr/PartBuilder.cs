using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarMgr
{
    class PartBuilder
    {
        public List<Part> Build(DataTable data)
        {
            List<Part> parts = new List<Part>();
            foreach (DataRow row in data.Rows)
            {
                parts.Add(Pharse(row));
            }
            return parts;
        }

        public Part Build(DataRow data)
        {
            return Pharse(data);
        }

        private Part Pharse(DataRow row)
        {
            string name = row["part_name"].ToString();
            double price = double.Parse(row["part_price"].ToString());
            string description = row["part_description"].ToString();
            string image = row["part_image"].ToString();
            double horsepower = double.Parse(row["part_horsepower"].ToString());
            double torque = double.Parse(row["part_torque"].ToString());
            double maxrpm = double.Parse(row["part_maxrpm"].ToString());
            double displacement = double.Parse(row["part_displacement"].ToString());
            double toptrackspeed = double.Parse(row["part_toptrackspeed"].ToString());
            double zerotosixty = double.Parse(row["part_zerotosixty"].ToString());
            double stroke = double.Parse(row["part_stroke"].ToString());
            double bore = double.Parse(row["part_bore"].ToString());
            string partType = row["part_type"].ToString();

            if (partType == null || partType == "")
            {
                // Udpate part table
                return new PerformancePart(description, image, name, price, horsepower, torque, toptrackspeed, zerotosixty, maxrpm, stroke, bore, displacement);
            } else
            {
                return new OpticPart(description, image, name, price, partType);
            }
        }
    }
}
