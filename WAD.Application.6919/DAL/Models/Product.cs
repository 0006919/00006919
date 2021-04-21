using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Product
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int Price { get; set; }
        public String Description { get; set; }
    }
}
