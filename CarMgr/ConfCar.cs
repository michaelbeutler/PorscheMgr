using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgr
{
    /// <summary>
    /// This method represents the current configuration selected in the configure window
    /// </summary>
    class ConfCar
    {
        private Car carBase;

        private double priceParts = 0.0;
        private double horsepower = 0.0;
        private double torque = 0.0;
        private double maxrpm = 0.0;
        private double zeroToSixty = 0.0;
        private double topTrackSpeed = 0.0;
        private double displacment = 0.0;

        private List<Part> parts = new List<Part>();

        public ConfCar(Car carBase)
        {
            this.carBase = carBase;
        }

        /// <summary>
        /// Add Parts to the current configuration
        /// </summary>
        /// <param name="part"></param>
        public void AddPart(Part part)
        {
            if (part is PerformancePart)
            {
                PerformancePart _part = part as PerformancePart;
                Horsepower += _part.MaxPower;

                Torque += _part.MaxTorque;

                maxrpm += _part.MaxEngineSpeed;

                zeroToSixty -= _part.ZeroToSixty;

                topTrackSpeed += _part.TopTrackSpeed;

                displacment += _part.Displacment;
            }

            PriceParts += part.Price;
            parts.Add(part);
        }

        /// <summary>
        /// Remove Part from the current configuration
        /// </summary>
        /// <param name="part"></param>
        public void RemovePart(Part part)
        {
            if (part is PerformancePart)
            {
                PerformancePart _part = part as PerformancePart;
                Horsepower -= _part.MaxPower;

                Torque -= _part.MaxTorque;

                maxrpm -= _part.MaxEngineSpeed;

                zeroToSixty += _part.ZeroToSixty;

                topTrackSpeed -= _part.TopTrackSpeed;

                displacment -= _part.Displacment;
            }

            PriceParts -= part.Price;
            parts.Remove(part);
        }

        public Car CarBase { get => carBase; set => carBase = value; }
        public double PriceParts { get => priceParts; set => priceParts = value; }
        public double Horsepower { get => horsepower; set => horsepower = value; }
        public double Torque { get => torque; set => torque = value; }
        public double Maxrpm { get => maxrpm; set => maxrpm = value; }
        public double ZeroToSixty { get => zeroToSixty; set => zeroToSixty = value; }
        public double TopTrackSpeed { get => topTrackSpeed; set => topTrackSpeed = value; }
        public double Displacment { get => displacment; set => displacment = value; }
        public List<Part> Parts { get => parts; set => parts = value; }

        public string GetCarBasePrice()
        {
            return Math.Round(Math.Round(CarBase.Price * 20, MidpointRounding.AwayFromZero) / 20, 1) + " CHF";
        }

        public string GetPartPrice()
        {
            return Math.Round(Math.Round(PriceParts * 20, MidpointRounding.AwayFromZero) / 20, 1) + " CHF";
        }

        public string GetTotalPrice()
        {
            return Math.Round(Math.Round((CarBase.Price + PriceParts) * 20, MidpointRounding.AwayFromZero) / 20, 1) + " CHF";
        }
    }
}
