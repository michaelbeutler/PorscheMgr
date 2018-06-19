using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarMgr
{
	public interface ICarConfiguratorDAO
	{
		DataTable GetAllCars();
		DataTable GetAllParts(Car c);
		bool Test();
	}
}
