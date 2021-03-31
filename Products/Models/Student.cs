using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Name needed")]
        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage = "Mark needed")]
        [StringLength(50)]
        public string mark { get; set; }


        public House house { get; set; }

        public int houseid { get; set; }
    }
}