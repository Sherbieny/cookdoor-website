using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CookDoor.DB_Layer;
/// <summary>
/// Summary description for ProductService
/// </summary>
namespace CookDoor.Service_Layer
{
    public class ProductService
    {

        ConnectionDB Connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductService()
        {
            //Intiailizing ConnectionDB Class
            Connection = new ConnectionDB();
        }

        public List<Product> GetProducts()
        {
            Product t = new Product();
            List<Product> ProductsList;
            try
            {
                ProductsList = new List<Product>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetProducts", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Product();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Path = Convert.ToString(dr["Path"]);
                    t.Category_Name = Convert.ToString(dr["Categtory_Name"]);
                    if (dr["Category_ID"] != null)
                        t.Category_ID = Convert.ToInt32(dr["Category_ID"]);

                    ProductsList.Add(t);
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
            return ProductsList;
        }

        public List<Product> GetProductsByCategory(int CategoryID)
        {
            Product t = new Product();
            List<Product> ProductsList;
            try
            {
                ProductsList = new List<Product>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetProductByCategory", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("ECatgory_ID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = CategoryID;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Product();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Path = Convert.ToString(dr["Path"]);
                    t.Category_Name = Convert.ToString(dr["Categtory_Name"]);
                    if (dr["Category_ID"] != null)
                        t.Category_ID = Convert.ToInt32(dr["Category_ID"]);

                    ProductsList.Add(t);
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
            return ProductsList;
        }

        public List<Product> GetProductsByCategoryName(string CategoryName)
        {
            Product t = new Product();
            List<Product> ProductsList;
            try
            {
                ProductsList = new List<Product>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetProductByCategoryName", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = CategoryName;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Product();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Path = Convert.ToString(dr["Path"]);
                    t.Category_Name = Convert.ToString(dr["Categtory_Name"]);
                    if (dr["Category_ID"] != null)
                        t.Category_ID = Convert.ToInt32(dr["Category_ID"]);

                    ProductsList.Add(t);
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
            return ProductsList;
        }


        /// <summary>
        /// This Functions adds a new Employee to the DataBase
        /// </summary>
        /// <param name="t">News to be added</param>
        public void addProduct(Product b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("AddProduct", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = b.Name;
                commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Name_ar;
                commdel.Parameters.Add("EPath", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = b.Path;
                commdel.Parameters.Add("ECategory_ID", MySqlDbType.Int32);
                commdel.Parameters[3].Value = b.Category_ID;
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
        public void removeProduct(int b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("RemoveProduct", Connection.conn);
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

        public void editProduct(Product p)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("EditProduct", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EID", MySqlDbType.Int32);
                commdel.Parameters[0].Value = p.ID;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = p.Name;
                commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = p.Name_ar;
                commdel.Parameters.Add("EPath", MySqlDbType.VarChar);
                commdel.Parameters[3].Value = p.Path;
                commdel.Parameters.Add("ECategory_ID", MySqlDbType.Int32);
                commdel.Parameters[4].Value = p.Category_ID;

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

        public Product GetProductByName(String Name)
        {
            Product t = new Product();
            List<Product> ProductsList;
            try
            {
                ProductsList = new List<Product>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetProductByName", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = Name;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Product();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Path = Convert.ToString(dr["Path"]);
                    t.Category_Name = Convert.ToString(dr["Categtory_Name"]);
                    if (dr["Category_ID"] != null)
                        t.Category_ID = Convert.ToInt32(dr["Category_ID"]);

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
    }
}