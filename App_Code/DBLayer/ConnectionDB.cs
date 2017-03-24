using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CookDoor.DB_Layer
{
    public class ConnectionDB
    {
        public MySqlConnection conn { get; set; }

        public ConnectionDB()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["CookDoorConnectionString"].ConnectionString);
        }


        public void connect()
        {

            try { conn.Open(); }
            catch (Exception e) { }

        }

        public void disconnect()
        {
            conn.Close();
        }


    }
}