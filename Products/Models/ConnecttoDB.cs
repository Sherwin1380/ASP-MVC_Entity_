using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class ConnecttoDB
    {
        public static string ConnectDb()
        {
            return ConfigurationManager.ConnectionStrings["Ecom"].ConnectionString;
        }
    }
}