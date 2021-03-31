using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Login
    {


        [Required]
        public string mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


    }
}