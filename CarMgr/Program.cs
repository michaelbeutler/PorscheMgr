using System;
using System.Collections.Generic;
using System.Text;

namespace CarMgr
{
	public class Program
	{
		private ICarConfiguratorDAO dao = new MySQL();
		private FrontController frontController;

		public List<Car> GetAllCars()
		{
			throw new NotImplementedException();
		}
	}
}
