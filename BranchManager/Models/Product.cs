using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BranchManager.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IList<Branch> Branch { get; set; }
        public Product()
        {
            Branch = new List<Branch>();
        }

    }
}

