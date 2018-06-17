using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace CarMgr
{
	public class CarBuilder
	{
		public List<Car> Build(DataTable data)
		{
            List<Car> cars = new List<Car>();
			foreach(DataRow row in data.Rows)
            {
                cars.Add(Pharse(row));
            }
            return cars;
		}

        public Car Build(DataRow data)
        {
            return Pharse(data);
        }

        private Car Pharse(DataRow row)
        {
            // Car
            string name = row["car_name"].ToString();
            int year = int.Parse(row["car_year"].ToString());
            double price = double.Parse(row["car_price"].ToString());
            string image = row["car_image"].ToString();

            // Engine
            string engineLayout = row["engine_enginelayout"].ToString();
            string engineDesign = row["engine_enginedesign"].ToString();
            int cylinderNum = int.Parse(row["engine_cylindernum"].ToString());
            double bore = double.Parse(row["engine_bore"].ToString());
            double stroke = double.Parse(row["engine_stroke"].ToString());
            double displacement = double.Parse(row["engine_displacement"].ToString());
            double maxPower = double.Parse(row["engine_maxpower"].ToString());
            double maxPowerAtRpm = double.Parse(row["engine_maxpowerrpm"].ToString());
            double maxTorque = double.Parse(row["engine_maxtorque"].ToString());
            double maxEngineSpeed = double.Parse(row["engine_maxenginespeed"].ToString());
            Engine engine = new Engine(engineLayout, engineDesign, cylinderNum, bore, stroke, displacement, maxPower, maxPowerAtRpm, maxTorque, maxEngineSpeed);

            // Body
            string bodyType = row["body_type"].ToString();
            Body body = new Body(bodyType);

            // ChassisAndSuspension
            string frontAxle = row["chassisandsuspension_frontaxle"].ToString();
            string rearAxle = row["chassisandsuspension_rearaxle"].ToString();
            string brakes = row["chassisandsuspension_brakes"].ToString();
            string steering = row["chassisandsuspension_steering"].ToString();
            string abs = row["chassisandsuspension_abs"].ToString();
            string tractionControl = row["chassisandsuspension_tractioncontrol"].ToString();
            string stabilityControl = row["chassisandsuspension_stabilitycontrol"].ToString();
            ChassisAndSuspension chassisAndSuspension = new ChassisAndSuspension(frontAxle, rearAxle, brakes, steering, abs, tractionControl, stabilityControl);

            // FuelConsumption
            double city = double.Parse(row["fuelconsumption_city"].ToString());
            double highway = double.Parse(row["fuelconsumption_highway"].ToString());
            double combined = double.Parse(row["fuelconsumption_combined"].ToString());
            string epaDisclaimer = row["fuelconsumption_epadisclaimer"].ToString();
            FuelConsumption fuelConsumption = new FuelConsumption(city, highway, combined, epaDisclaimer);

            // Brand
            string brand_name = row["brand_companyname"].ToString();
            Brand brand = new Brand(brand_name);

            // Perfromance
            double topTrackSpeed = double.Parse(row["performance_toptrackspeed"].ToString());
            double zeroToSixty = double.Parse(row["performance_zerotosixty"].ToString());
            Performance performance = new Performance(topTrackSpeed, zeroToSixty);

            // Transmission
            string drivetrain = row["transmission_drivetrain"].ToString();
            string manualTransmission = row["transmission_manualtransmission"].ToString();
            string automaticTransmission = row["transmission_automatictransmission"].ToString();
            Transmission transmission = new Transmission(drivetrain, manualTransmission, automaticTransmission);

            Car car = new Car(name, year, image, price, engine, body, chassisAndSuspension, fuelConsumption, brand, performance, transmission);
            return car;
        }
	}
}
