using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Therapy_Clinic_House
{
    class connection
    {
        public MySqlConnection con = new MySqlConnection(@"Server=localhost;Port=3306;database=clinic;User=root; Pwd=password");

        public string connect()
        {
            try
            {
                con.Open();
                return ("All set!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
                 
            }
        }
        public string disconnect()
        {
            try
            {
                con.Close();
                return ("Disconnected!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
    }
}
