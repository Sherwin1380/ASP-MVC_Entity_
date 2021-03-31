using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models.ViewModels
{
    public class StudentHouse
    {
       public Student student { get; set; }
       public IEnumerable<House> house { get; set; }
    }
}