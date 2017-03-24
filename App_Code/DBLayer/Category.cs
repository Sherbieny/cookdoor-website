using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
/// 
namespace CookDoor.DB_Layer
{
    public class Category
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Name_ar { get; set; }
        public String Path { get; set; }
        public List<Product> ProductsList { get; set; }
        public Category()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}