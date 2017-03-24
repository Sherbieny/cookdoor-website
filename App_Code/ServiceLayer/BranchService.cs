using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CookDoor.DB_Layer;

namespace CookDoor.Service_Layer
{
    /// <summary>
    /// Summary description for BranchService
    /// </summary>
    public class BranchService
    {


        ConnectionDB Connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public BranchService()
        {
            //Intiailizing ConnectionDB Class
            Connection = new ConnectionDB();
        }

        public List<Branch> GetBranches()
        {
            Branch t = new Branch();
            List<Branch> BranchesList;
            try
            {
                BranchesList = new List<Branch>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetBranches", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Branch();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Otlob = Convert.ToString(dr["Otlob"]);
                    t.Facebook = Convert.ToString(dr["FaceBook"]);
                    t.City_Name = Convert.ToString(dr["City_Name"]);
                    if (dr["City_ID"] != null)
                        t.City_ID = Convert.ToInt32(dr["City_ID"]);
                    t.Mail = Convert.ToString(dr["Mail"]);
                    BranchesList.Add(t);
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
            return BranchesList;
        }

        public Branch GetBranchByID(int EID)
        {
            Branch t = new Branch();
            try
            {

                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetBranchByID", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = EID;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Branch();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Otlob = Convert.ToString(dr["Otlob"]);
                    t.City_Name = Convert.ToString(dr["City_Name"]);
                    t.Facebook = Convert.ToString(dr["FaceBook"]);
                    if (dr["City_ID"] != null)
                        t.City_ID = Convert.ToInt32(dr["City_ID"]);
                    t.Mail = Convert.ToString(dr["Mail"]);

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


        public List<Branch> GetBranchByCity(int ECityID)
        {
            Branch t = new Branch();
            List<Branch> BranchesList;
            try
            {
                BranchesList = new List<Branch>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetBranchByCity", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("ECity_ID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = ECityID;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Branch();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Otlob = Convert.ToString(dr["Otlob"]);
                    t.City_Name = Convert.ToString(dr["City_Name"]);
                    t.Facebook = Convert.ToString(dr["FaceBook"]);
                    if (dr["City_ID"] != null)
                        t.City_ID = Convert.ToInt32(dr["City_ID"]);
                    t.Mail = Convert.ToString(dr["Mail"]);
                    BranchesList.Add(t);
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
            return BranchesList;
        }

        /// <summary>
        /// This Functions adds a new Employee to the DataBase
        /// </summary>
        /// <param name="t">News to be added</param>
        public void addBranch(Branch b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("AddBranch", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = b.Name;
                commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Name_ar;
                commdel.Parameters.Add("EOtlob", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = b.Otlob;
                commdel.Parameters.Add("EFaceBook", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = b.Facebook;
                commdel.Parameters.Add("EMail", MySqlDbType.VarChar);
                commdel.Parameters[4].Value = b.Mail;
                commdel.Parameters.Add("ECity_ID", MySqlDbType.Int32);
                commdel.Parameters[5].Value = b.City_ID;
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

        /// <summary>
        /// Remove the branch
        /// </summary>
        /// <param name="b"></param>
        public void removeBranch(int b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("RemoveBranch", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = b;
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

        /// <summary>
        /// This Functions edits a new Employee to the DataBase
        /// </summary>
        /// <param name="t">News to be added</param>
        public void editBranch(Branch b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("EditBranch", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = b.ID;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Name;
                commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = b.Name_ar;
                commdel.Parameters.Add("EOtlob", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = b.Otlob;
                commdel.Parameters.Add("EFaceBook", MySqlDbType.VarChar);
                commdel.Parameters[4].Value = b.Facebook;
                commdel.Parameters.Add("EMail", MySqlDbType.VarChar);
                commdel.Parameters[5].Value = b.Mail;
                commdel.Parameters.Add("ECity_ID", MySqlDbType.Int32);
                commdel.Parameters[6].Value = b.City_ID;
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