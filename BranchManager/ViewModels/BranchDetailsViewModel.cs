using BranchManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BranchManager.ViewModels
{
    public class BranchDetailsViewModel
    {
        public Branch Branch { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}