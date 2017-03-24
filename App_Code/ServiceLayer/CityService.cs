using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CookDoor.DB_Layer;

/// <summary>
/// Summary description for CityService
/// </summary>
namespace CookDoor.Service_Layer
{
    public class CityService
    {


        ConnectionDB Connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public CityService()
        {
            //Intiailizing ConnectionDB Class
            Connection = new ConnectionDB();
        }

        public List<City> GetCities()
        {
            City t = new City();
            List<City> CitiesList;
            try
            {
                CitiesList = new List<City>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetCities", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new City();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    CitiesList.Add(t);
                }
                dr.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }
            /////////////////Returning the Result (SubteamsList)/////////////
            return CitiesList;
        }

        public City GetCityByName(string name)
        {
            City t = new City();
            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetCityByName", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = name;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new City();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                }
                dr.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }
            /////////////////Returning the Result (SubteamsList)/////////////
            return t;
        }

        /// <summary>
        /// This Functions adds a new City to the DataBase
        /// </summary>
        /// <param name="t">News to be added</param>
        public void addCity(City b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("AddCity", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = b.Name;
                commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Name_ar;
                //////////////////Executing the Command/////////////////
                commdel.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
            }

        }

    }
}