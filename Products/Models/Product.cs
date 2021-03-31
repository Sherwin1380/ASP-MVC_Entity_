using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    { 
        public int id { get; set; }
        [Required(ErrorMessage = "Product name required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Product price required")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Product supplier required")]
        public string supplier { get; set; }
    }
}