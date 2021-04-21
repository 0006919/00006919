using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.Application._6919.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public CategoryViewModel Category { get; set; }
        public Int32 Price { get; set; }
        public String Description { get; set; }
    }
}
