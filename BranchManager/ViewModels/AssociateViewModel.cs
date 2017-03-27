using BranchManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BranchManager.ViewModels
{
    public class AssociateViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public IEnumerable<Branch> AllBranches { get; set; }
        public string SearchTerm { get; set; }
    }
}