using BranchManager.Models;
using BranchManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BranchManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        { 
            var branchesAndProducts = _context.Branches.Include(z => z.Product);

            var viewModel = new HomeViewModel
            {
                Branch = branchesAndProducts
            };
            return View(viewModel);
        }

       
    }
}