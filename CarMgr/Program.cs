using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Program
	{
		private static ICarConfiguratorDAO dao = new MySQL();
		private static FrontController frontController;
        private static CarBuilder carbuilder = new CarBuilder();

		public static List<Car> GetAllCars()
		{
            return carbuilder.Build(dao.GetAllCars());
		}
	}
}
