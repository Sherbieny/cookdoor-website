using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Branch
/// </summary>
namespace CookDoor.DB_Layer
{
    public class Branch
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Name_ar { get; set; }
        public String Otlob { get; set; }
        public String Facebook { get; set; }
        public String Mail { get; set; }
        public int City_ID { get; set; }
        public String City_Name { get; set; }
        public Branch()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}