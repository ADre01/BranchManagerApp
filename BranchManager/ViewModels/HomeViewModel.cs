using BranchManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BranchManager.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Branch> Branch { get; set; }

    }
}