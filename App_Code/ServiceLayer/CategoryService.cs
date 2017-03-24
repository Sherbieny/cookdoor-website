using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CookDoor.DB_Layer;
/// <summary>
/// Summary description for CategoryService
/// </summary>

namespace CookDoor.Service_Layer
{
    public class CategoryService
    {
        ConnectionDB Connection;
        public CategoryService()
        {
            //Intiailizing ConnectionDB Class
            Connection = new ConnectionDB();
        }

        public List<Category> GetCategories()
        {
            Category t = new Category();
            ProductService PS = new ProductService();
            List<Category> CategoriesList;
            try
            {
                CategoriesList = new List<Category>();
                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetCategories", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;

                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Category();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Path = Convert.ToString(dr["Path"]);
                    t.ProductsList = new List<Product>();
                    t.ProductsList = PS.GetProductsByCategory(t.ID);
                    CategoriesList.Add(t);
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
            return CategoriesList;
        }

        /// <summary>
        /// This Functions adds a new Employee to the DataBase
        /// </summary>
        /// <param name="t">News to be added</param>
        public void addCategory(Category b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("AddCategory", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = b.Name;
                commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdel.Parameters[1].Value = b.Name_ar;
                commdel.Parameters.Add("EPath", MySqlDbType.VarChar);
                commdel.Parameters[2].Value = b.Path;
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
        public void removeCategory(int b)
        {
            try
            {

                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("RemoveCategory", Connection.conn);
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

        public Category GetCategoryByName(string name)
        {
            Category t = new Category();
            try
            {

                MySqlDataReader dr;
                /////////////////Construcing the MY SQL command//////////// 
                Connection.connect();
                MySqlCommand commdel = new MySqlCommand("GetCategoryByName", Connection.conn);
                commdel.CommandType = System.Data.CommandType.StoredProcedure;
                //////////////////News Parameters///////////////////////
                commdel.Parameters.Add("EName", MySqlDbType.VarChar);
                commdel.Parameters[0].Value = name;
                //////////////////Retreiveing the Project props from DB/////////
                dr = commdel.ExecuteReader();
                while (dr.Read())
                {
                    t = new Category();
                    t.ID = Convert.ToInt32(dr["ID"]);
                    t.Name = Convert.ToString(dr["Name"]);
                    t.Name_ar = Convert.ToString(dr["Name_ar"]);
                    t.Path = Convert.ToString(dr["Path"]);

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

      public void editCategory(Category c)
    {
        try
        {

            /////////////////Construcing the MY SQL command//////////// 
            Connection.connect();
            MySqlCommand commdel = new MySqlCommand("EditCategory", Connection.conn);
            commdel.CommandType = System.Data.CommandType.StoredProcedure;
            //////////////////News Parameters///////////////////////
            commdel.Parameters.Add("EID", MySqlDbType.Int32);
            commdel.Parameters[0].Value = c.ID;
            commdel.Parameters.Add("EName", MySqlDbType.VarChar);
            commdel.Parameters[1].Value = c.Name;
            commdel.Parameters.Add("EName_ar", MySqlDbType.VarChar);
            commdel.Parameters[2].Value = c.Name_ar;
            commdel.Parameters.Add("EPath", MySqlDbType.VarChar);
            commdel.Parameters[3].Value = c.Path;
            
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
