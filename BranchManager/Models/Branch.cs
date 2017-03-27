using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace BranchManager.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<Product> Product { get; set; }

        public Branch()
        {
            Product = new List<Product>();
        }

        public void AddToBranch(Product product)
        {
            Product.Add(product);
        }


        public void DeleteFromBranch(Product product)
        {
            Product.Remove(product);
        }
    }
}