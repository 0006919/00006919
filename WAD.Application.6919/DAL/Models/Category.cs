using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Category
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
