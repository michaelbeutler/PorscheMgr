using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace CarMgr
{
	public class MySQL : ICarConfiguratorDAO
	{
		MySqlConnection connection;
		private string server;
        private string username;
        private string password;
        private string database;

		public MySQL()
		{
            Initialize();
		}

        private void Initialize()
        {
            server = "localhost";
            database = "carmgr_db";
            username = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";" + "SslMode=none";

            connection = new MySqlConnection(connectionString);
        }

        private bool Close()
		{
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

		private bool Open()
		{
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

		public bool Test()
		{
            bool status = Open();
            Close();
            return status;
        }

        public DataTable GetAllCars()
        {
            DataTable dataTable;
            if (Open())
            {
                string query = "SELECT * FROM `tbl_car` LEFT JOIN `tbl_brand` ON `tbl_car`.`brand_id` = `tbl_brand`.`brand_id` LEFT JOIN `tbl_engine` ON `tbl_car`.`engine_id` = `tbl_engine`.`engine_id`LEFT JOIN `tbl_transmission` ON `tbl_car`.`transmission_id` = `tbl_transmission`.`transmission_id` LEFT JOIN `tbl_fuelconsumption` ON `tbl_car`.`fuelconsumption_id` = `tbl_fuelconsumption`.`fuelconsumption_id` LEFT JOIN `tbl_chassisandsuspension` ON `tbl_car`.`chassisandsuspension_id` = `tbl_chassisandsuspension`.`chassisandsuspension_id` LEFT JOIN `tbl_body` ON `tbl_car`.`body_id` = `tbl_body`.`body_id` LEFT JOIN `tbl_performance` ON `tbl_car`.`performance_id` = `tbl_performance`.`performance_id`";

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                MySqlDataReader reader;

                reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                
                Close();
                return dataTable;
            }
            return null;
        }

        public DataTable GetAllParts(Car c)
        {
            DataTable dataTable;
            if (Open())
            {
                string query = "SELECT * FROM tbl_partlist LEFT JOIN tbl_part ON tbl_partlist.part_id=tbl_part.part_id WHERE car_id=" + c.ID + ";";

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                MySqlDataReader reader;

                reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                Close();
                return dataTable;
            }
            return null;
        }

    }
}
