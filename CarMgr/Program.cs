using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CarMgr
{
	public class Program
	{
		private static ICarConfiguratorDAO dao = new MySQL();
        private static CarBuilder carbuilder = new CarBuilder();
        private static PartBuilder partBuilder = new PartBuilder();

		public static List<Car> GetAllCars()
		{
            if (dao.Test())
            {
                return carbuilder.Build(dao.GetAllCars());
            } else
            {
                MessageBox.Show("Das Programm konnte keine Verbindung zum MySQL Server herstellen.\r\nDas Programm wird nun beendet.");
                Environment.Exit(-1);
            }
            return null;
		}

        public static List<Part> GetAllParts(Car c)
        {
            if (dao.Test())
            {
                return partBuilder.Build(dao.GetAllParts(c));
            }
            else
            {
                MessageBox.Show("Das Programm konnte keine Verbindung zum MySQL Server herstellen.\r\nDas Programm wird nun beendet.");
                Environment.Exit(-1);
            }
            return null;
        }
	}
}
