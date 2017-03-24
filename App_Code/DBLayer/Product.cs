using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
namespace CookDoor.DB_Layer
{
    public class Product
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Name_ar { get; set; }
        public int Category_ID { get; set; }
        public String Path { get; set; }
        public String Category_Name { get; set; }

        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}