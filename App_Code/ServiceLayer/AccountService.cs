using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CookDoor.DB_Layer;

/// <summary>
/// Summary description for AccountService
/// </summary>
namespace CookDoor.Service_Layer
{
    public class AccountService
    {


        ConnectionDB Connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountService()
        {
            //Intiailizing ConnectionDB Class
            Connection = new ConnectionDB();
        }

        public void EditPassword(Account b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("EditPassword", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = b.Name;
                commdel.Parameters.Add("EPassword", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Password;
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
   


 
        public Account GetAccountByName(string name)
        {
            Account t = new Account();
            try
            {
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetAccountByName", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = name;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Account();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Password = Convert.ToString(dr["Password"]);
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

        public List<Account> GetAccounts()
        {
            Account t = new Account();
            List<Account> theList = new List<Account>();
            try
            {

                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetAccounts", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Account();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Password = Convert.ToString(dr["Password"]);
                    theList.Add(t);
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
            return theList;
        }


        /// <summary>
        /// This Functions adds a new Account to the DataBase
        /// </summary>
        /// <param name="t">News to be added</param>
        public void addAccount(Account b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("AddAccount", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = b.Name;
                commdel.Parameters.Add("EPassword", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Password;
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