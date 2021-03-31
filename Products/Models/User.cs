using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Name needed")]
        public string name { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
   


    }
}