using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CarMgr
{
	public class Program
	{
		private static ICarConfiguratorDAO dao = new MySQL();
		private static FrontController frontController;
        private static CarBuilder carbuilder = new CarBuilder();

		public static List<Car> GetAllCars()
		{
            if (dao.Test())
            {
                return carbuilder.Build(dao.GetAllCars());
            } else
            {
                MessageBox.Show("Connection invalid");
                Environment.Exit(-1);
                return null;
            }
		}
	}
}
