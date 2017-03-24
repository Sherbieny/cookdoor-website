

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using CookDoor.DB_Layer;
/// <summary>
/// Summary description for ExelService
/// </summary>
namespace CookDoor.Service_Layer
{
    public class ExcelService
    {

        ConnectionDB Connection;
        MySqlDataAdapter commdept = new MySqlDataAdapter();
        /// <summary>
        /// Constructor
        /// </summary>
        /// 
        public ExcelService()
        {
            Connection = new ConnectionDB();
        }
        public void AddBranches(DataTable dt)
        {
            DataTable dtdepts = new DataTable();
            int counter = 0;
            //Declare & Initialize Variables
            try
            {
                //Initialize DB Connection
                Connection.connect();
                ///////////////////////Initialize Data Adapter with its Add & Update commands & their properties/////////////////
                commdept.SelectCommand = new MySqlCommand();
                commdept.SelectCommand.Connection = Connection.conn;
                commdept.SelectCommand.CommandText = "GetBranches";
                commdept.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                ////////////////////////////////////////////////////////////////////////////////////////////

                #region Insert & Update Command parameters
                commdept.InsertCommand = new MySqlCommand();
                commdept.InsertCommand.CommandText = "AddBranch";
                commdept.InsertCommand.Connection = Connection.conn;
                commdept.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                commdept.InsertCommand.Parameters.Add("EID", MySqlDbType.Int32);
                commdept.InsertCommand.Parameters[0].SourceColumn = "ID";
                commdept.InsertCommand.Parameters[0].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[1].SourceColumn = "Name";
                commdept.InsertCommand.Parameters[1].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[2].SourceColumn = "Name_ar";
                commdept.InsertCommand.Parameters[2].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EOtlob", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[3].SourceColumn = "Otlob";
                commdept.InsertCommand.Parameters[3].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EFaceBook", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[4].SourceColumn = "Facebook";
                commdept.InsertCommand.Parameters[4].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EMail", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[5].SourceColumn = "Mail";
                commdept.InsertCommand.Parameters[5].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("ECity_ID", MySqlDbType.Int32);
                commdept.InsertCommand.Parameters[6].SourceColumn = "City_ID";
                commdept.InsertCommand.Parameters[6].SourceVersion = DataRowVersion.Current;
                # endregion Insert & Update Command parameters
                //Fill the DataTable
                commdept.Fill(dtdepts);


            }
            catch (Exception e)
            {
                //Closing the Data Adapter
                commdept.Dispose();
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
                throw e;

            }
            /////////////////Construcing the MY SQL command//////////// 
            //Filling New Departments and Titles
            //------------------------------------
            #region Initialize bugloyee
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                Branch branch = new Branch();
                try
                {

                    for (int z = 0; z < dt.Columns.Count; z++)
                    {


                        /////////////////////////////////////////////ID////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "City")
                        {

                            int n;
                            CityService cs = new CityService();
                            City c = cs.GetCityByName(dt.Rows[k][z].ToString());
                            branch.City_ID = c.ID;
                            ///////////////////////////////////////////////////////////////////////////


                        }
                        /////////////////////////////////////////Name/////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name")
                        {
                            branch.Name = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Name_ar////////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name_ar")
                        {
                            branch.Name_ar = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Otlob////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Otlob")
                        {
                            branch.Otlob = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////RESOLUTION////////////////////////////////////////////

                    }
            #endregion
                }
                catch (Exception es)
                { }

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                //Addition of the new rows
                #region Add
                DataRow[] drdepts = dtdepts.Select("Name='" + branch.Name + "'");

                if (drdepts.GetUpperBound(0) < 0)
                {
                    ////Addition Mode
                    DataRow drdeptnew = dtdepts.NewRow();
                    //////////////////////////////////////////
                    drdeptnew["ID"] = ++counter;
                    ////////////////////////////////////////////////////////////
                    drdeptnew["Name"] = branch.Name;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Name_ar"] = branch.Name_ar;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["FaceBook"] = branch.Facebook;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Otlob"] = branch.Otlob;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Mail"] = branch.Mail;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["City_ID"] = branch.City_ID;
                    /////////////////////////////////////////////////////////////////////////
                    dtdepts.Rows.Add(drdeptnew);

                }

                #endregion



            }
            //////////////////////////////////////////////////////////////////////////////
            try
            {
                //dtdepts.AcceptChanges();
                commdept.Update(dtdepts);
                dtdepts.Clear();
            }
            catch (Exception eee)
            {
                throw eee;
            }

        }

        public void AddCategories(DataTable dt)
        {
            DataTable dtdepts = new DataTable();
            int counter = 0;
            //Declare & Initialize Variables
            try
            {
                //Initialize DB Connection
                Connection.connect();
                ///////////////////////Initialize Data Adapter with its Add & Update commands & their properties/////////////////
                commdept.SelectCommand = new MySqlCommand();
                commdept.SelectCommand.Connection = Connection.conn;
                commdept.SelectCommand.CommandText = "GetCategories";
                commdept.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                ////////////////////////////////////////////////////////////////////////////////////////////

                #region Insert & Update Command parameters
                commdept.InsertCommand = new MySqlCommand();
                commdept.InsertCommand.CommandText = "AddCategory";
                commdept.InsertCommand.Connection = Connection.conn;
                commdept.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                commdept.InsertCommand.Parameters.Add("EID", MySqlDbType.Int32);
                commdept.InsertCommand.Parameters[0].SourceColumn = "ID";
                commdept.InsertCommand.Parameters[0].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[1].SourceColumn = "Name";
                commdept.InsertCommand.Parameters[1].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[2].SourceColumn = "Name_ar";
                commdept.InsertCommand.Parameters[2].SourceVersion = DataRowVersion.Current;
                # endregion Insert & Update Command parameters
                //Fill the DataTable
                commdept.Fill(dtdepts);


            }
            catch (Exception e)
            {
                //Closing the Data Adapter
                commdept.Dispose();
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
                throw e;

            }
            /////////////////Construcing the MY SQL command//////////// 
            //Filling New Departments and Titles
            //------------------------------------
            #region Initialize bugloyee
            for (int k = 0; k < dt.Rows.Count; k++)
            {

                Category c = new Category();
                try
                {
                    for (int z = 0; z < dt.Columns.Count; z++)
                    {


                        /////////////////////////////////////////////ID////////////////////////////////////////
                        //if (dt.Columns[z].ColumnName == "BUGID" || dt.Columns[z].ColumnName == "bug_Code")
                        //{
                        //    if (!dt.Rows[k][z].ToString().Equals("") && !dt.Rows[k][z].ToString().Equals(null))
                        //    {
                        //        int n;
                        //        ///////////////////////////////////////////////////////////////////////////
                        //        if (int.TryParse(dt.Rows[k][z].ToString().Replace(" ", String.Empty), out n))
                        //            branch.bug_id = Int32.Parse(dt.Rows[k][z].ToString());
                        //        ///////////////////////////////////////////////////////////////////////////
                        //        branch.bug_db_id = "Rhino";
                        //    }

                        //}
                        /////////////////////////////////////////Name/////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name")
                        {
                            c.Name = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Name_ar////////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name_ar")
                        {
                            c.Name_ar = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Otlob////////////////////////////////////////
                    }
            #endregion
                }
                catch (Exception es)
                { }

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                //Addition of the new rows
                #region Add
                DataRow[] drdepts = dtdepts.Select("Name='" + c.Name + "'");
                if (drdepts.GetUpperBound(0) < 0)
                {
                    ////Addition Mode
                    DataRow drdeptnew = dtdepts.NewRow();
                    //////////////////////////////////////////
                    drdeptnew["ID"] = ++counter;
                    /////////////////////////////////////////////
                    drdeptnew["Name"] = c.Name;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Name_ar"] = c.Name_ar;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Path"] = "";
                    /////////////////////////////////////////////////////////////////////////
                    dtdepts.Rows.Add(drdeptnew);

                }

                #endregion



            }
            //////////////////////////////////////////////////////////////////////////////
            try
            {
                //dtdepts.AcceptChanges();
                commdept.Update(dtdepts);
                dtdepts.Clear();
            }
            catch (Exception eee)
            {
                throw eee;
            }

        }

        public void AddCities(DataTable dt)
        {
            DataTable dtdepts = new DataTable();
            int counter = 0;
            //Declare & Initialize Variables
            try
            {
                //Initialize DB Connection
                Connection.connect();
                ///////////////////////Initialize Data Adapter with its Add & Update commands & their properties/////////////////
                commdept.SelectCommand = new MySqlCommand();
                commdept.SelectCommand.Connection = Connection.conn;
                commdept.SelectCommand.CommandText = "GetCities";
                commdept.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                ////////////////////////////////////////////////////////////////////////////////////////////

                #region Insert & Update Command parameters
                commdept.InsertCommand = new MySqlCommand();
                commdept.InsertCommand.CommandText = "AddCity";
                commdept.InsertCommand.Connection = Connection.conn;
                commdept.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                commdept.InsertCommand.Parameters.Add("EID", MySqlDbType.Int32);
                commdept.InsertCommand.Parameters[0].SourceColumn = "ID";
                commdept.InsertCommand.Parameters[0].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[1].SourceColumn = "Name";
                commdept.InsertCommand.Parameters[1].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[2].SourceColumn = "Name_ar";
                commdept.InsertCommand.Parameters[2].SourceVersion = DataRowVersion.Current;
                # endregion Insert & Update Command parameters
                //Fill the DataTable
                commdept.Fill(dtdepts);


            }
            catch (Exception e)
            {
                //Closing the Data Adapter
                commdept.Dispose();
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
                throw e;

            }
            /////////////////Construcing the MY SQL command//////////// 
            //Filling New Departments and Titles
            //------------------------------------
            #region Initialize bugloyee
            for (int k = 0; k < dt.Rows.Count; k++)
            {

                City c = new City();
                try
                {
                    for (int z = 0; z < dt.Columns.Count; z++)
                    {


                        /////////////////////////////////////////////ID////////////////////////////////////////
                        //if (dt.Columns[z].ColumnName == "BUGID" || dt.Columns[z].ColumnName == "bug_Code")
                        //{
                        //    if (!dt.Rows[k][z].ToString().Equals("") && !dt.Rows[k][z].ToString().Equals(null))
                        //    {
                        //        int n;
                        //        ///////////////////////////////////////////////////////////////////////////
                        //        if (int.TryParse(dt.Rows[k][z].ToString().Replace(" ", String.Empty), out n))
                        //            branch.bug_id = Int32.Parse(dt.Rows[k][z].ToString());
                        //        ///////////////////////////////////////////////////////////////////////////
                        //        branch.bug_db_id = "Rhino";
                        //    }

                        //}
                        /////////////////////////////////////////Name/////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name")
                        {
                            c.Name = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Name_ar////////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name_ar")
                        {
                            c.Name_ar = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Otlob////////////////////////////////////////
                    }
            #endregion
                }
                catch (Exception es)
                { }

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                //Addition of the new rows
                #region Add
                DataRow[] drdepts = dtdepts.Select("Name='" + c.Name + "'");
                if (drdepts.GetUpperBound(0) < 0)
                {
                    ////Addition Mode
                    DataRow drdeptnew = dtdepts.NewRow();
                    //////////////////////////////////////////
                    drdeptnew["ID"] = ++counter;
                    /////////////////////////////////////////////
                    drdeptnew["Name"] = c.Name;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Name_ar"] = c.Name_ar;
                    /////////////////////////////////////////////////////////////////////////
                    dtdepts.Rows.Add(drdeptnew);

                }

                #endregion



            }
            //////////////////////////////////////////////////////////////////////////////
            try
            {
                //dtdepts.AcceptChanges();
                commdept.Update(dtdepts);
                dtdepts.Clear();
            }
            catch (Exception eee)
            {
                throw eee;
            }

        }

        public void AddProducts(DataTable dt)
        {
            DataTable dtdepts = new DataTable();
            int counter = 0;
            //Declare & Initialize Variables
            try
            {
                //Initialize DB Connection
                Connection.connect();
                ///////////////////////Initialize Data Adapter with its Add & Update commands & their properties/////////////////
                commdept.SelectCommand = new MySqlCommand();
                commdept.SelectCommand.Connection = Connection.conn;
                commdept.SelectCommand.CommandText = "GetProducts";
                commdept.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                ////////////////////////////////////////////////////////////////////////////////////////////

                #region Insert & Update Command parameters
                commdept.InsertCommand = new MySqlCommand();
                commdept.InsertCommand.CommandText = "AddProduct";
                commdept.InsertCommand.Connection = Connection.conn;
                commdept.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                commdept.InsertCommand.Parameters.Add("EID", MySqlDbType.Int32);
                commdept.InsertCommand.Parameters[0].SourceColumn = "ID";
                commdept.InsertCommand.Parameters[0].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[1].SourceColumn = "Name";
                commdept.InsertCommand.Parameters[1].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EName_ar", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[2].SourceColumn = "Name_ar";
                commdept.InsertCommand.Parameters[2].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("EPath", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[3].SourceColumn = "Otlob";
                commdept.InsertCommand.Parameters[3].SourceVersion = DataRowVersion.Current;
                commdept.InsertCommand.Parameters.Add("ECategory_ID", MySqlDbType.VarChar);
                commdept.InsertCommand.Parameters[4].SourceColumn = "Category_ID";
                commdept.InsertCommand.Parameters[4].SourceVersion = DataRowVersion.Current;
                # endregion Insert & Update Command parameters
                //Fill the DataTable
                commdept.Fill(dtdepts);


            }
            catch (Exception e)
            {
                //Closing the Data Adapter
                commdept.Dispose();
                /////////////////Disconnecting from the DB///////////////
                Connection.disconnect();
                throw e;

            }
            /////////////////Construcing the MY SQL command//////////// 
            //Filling New Departments and Titles
            //------------------------------------
            #region Initialize bugloyee
            for (int k = 0; k < dt.Rows.Count; k++)
            {

                Product product = new Product();
                try
                {
                    for (int z = 0; z < dt.Columns.Count; z++)
                    {


                        /////////////////////////////////////////////ID////////////////////////////////////////
                        //if (dt.Columns[z].ColumnName == "BUGID" || dt.Columns[z].ColumnName == "bug_Code")
                        //{
                        //    if (!dt.Rows[k][z].ToString().Equals("") && !dt.Rows[k][z].ToString().Equals(null))
                        //    {
                        //        int n;
                        //        ///////////////////////////////////////////////////////////////////////////
                        //        if (int.TryParse(dt.Rows[k][z].ToString().Replace(" ", String.Empty), out n))
                        //            branch.bug_id = Int32.Parse(dt.Rows[k][z].ToString());
                        //        ///////////////////////////////////////////////////////////////////////////
                        //        branch.bug_db_id = "Rhino";
                        //    }

                        //}
                        /////////////////////////////////////////Name/////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Name")
                        {
                            product.Name = dt.Rows[k][z].ToString();
                        }
                        /////////////////////////////////////////Name_ar////////////////////////////////////////////
                        if (dt.Columns[z].ColumnName == "Category")
                        {
                            Category c = new Category();
                            CategoryService cs = new CategoryService();
                            c = cs.GetCategoryByName(dt.Rows[k][z].ToString());
                            product.Category_ID = c.ID;
                        }
                        /////////////////////////////////////////Otlob////////////////////////////////////////
                    }
            #endregion
                }
                catch (Exception es)
                { }

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                //Addition of the new rows
                #region Add
                DataRow[] drdepts = dtdepts.Select("Name='" + product.Name + "'");
                if (drdepts.GetUpperBound(0) < 0)
                {
                    ////Addition Mode
                    DataRow drdeptnew = dtdepts.NewRow();
                    //////////////////////////////////////////
                    drdeptnew["ID"] = ++counter;
                    /////////////////////////////////////////////
                    drdeptnew["Name"] = product.Name;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Name_ar"] = product.Name_ar;
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Path"] = "";
                    /////////////////////////////////////////////////////////////////////////
                    drdeptnew["Category_ID"] = product.Category_ID;
                    /////////////////////////////////////////////////////////////////////////
                    dtdepts.Rows.Add(drdeptnew);

                }

                #endregion



            }
            //////////////////////////////////////////////////////////////////////////////
            try
            {
                //dtdepts.AcceptChanges();
                commdept.Update(dtdepts);
                dtdepts.Clear();
            }
            catch (Exception eee)
            {
                throw eee;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public DateTime HandleDate(String x)
        {
            if (x == "")
                return new DateTime(1, 1, 1);
            //If string is year only
            if (x.Length == 4)
            {
                try
                {
                    Int32.Parse(x);
                    return new DateTime(Int32.Parse(x), 1, 1);
                }

                catch (Exception eeee)
                {
                    return new DateTime(1, 1, 1);
                }

            }
            DateTime output;
            try
            {
                output = DateTime.Parse(x);
                return output;
            }
            catch (Exception e)
            {

                try
                {
                    output = DateTime.ParseExact(x, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    return output;
                }
                catch (Exception e1)
                {

                    try
                    {
                        output = DateTime.ParseExact(x, "dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                        return output;
                    }
                    catch (Exception e2)
                    {
                        try
                        {
                            output = DateTime.ParseExact(x, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
                            return output;
                        }
                        catch (Exception e3)
                        {
                            try
                            {
                                output = DateTime.ParseExact(x, "yyyy-mm-dd", System.Globalization.CultureInfo.CurrentCulture);
                                return output;
                            }
                            catch (Exception e4)
                            {
                                try
                                {
                                    output = DateTime.ParseExact(x, "yyyy-mm-dd hh:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                                    return output;
                                }
                                catch (Exception e5)
                                {
                                    output = DateTime.ParseExact(x, "dd-MM-yyyy hh:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                                    return output;
                                }
                            }
                        }
                    }
                }




            }
        }


    }
}