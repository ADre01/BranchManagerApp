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
    public class BranchController : Controller
    {
        private ApplicationDbContext _context;

        public BranchController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
   
        public ActionResult ViewBranches()
        {
            var branches = _context.Branches;
            var viewModel = new AssociateViewModel
            {
                AllBranches = branches
            };
           
            return View("ViewBranches", viewModel);
        }




        public ActionResult Details(int id)
        {
            var branch = _context.Branches.Include(b => b.Product).SingleOrDefault(b => b.Id == id);
            var allProducts = _context.Products.ToList();

            if (branch == null)
                return HttpNotFound();

            var viewModel = new BranchDetailsViewModel
            {
                Branch = branch,
                AllProducts = allProducts
            };

            return View("Details", viewModel);
        }



        public ActionResult AddBranch()
        {
            var viewModel = new BranchFormViewModel
            {
               Heading = "Add a New Branch" 
            };


            return View("BranchForm", viewModel);
        }


        [HttpPost]
        public ActionResult CreateBranch(BranchFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            if (_context.Branches.Any(b => b.Id == viewModel.Id))
                return HttpNotFound();

            var branch = new Branch
            {
                Name = viewModel.Name,
                Address = viewModel.Address
            };

            _context.Branches.Add(branch);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }


        public ActionResult EditBranch(int id)
        {
            var branch = _context.Branches.Single(b => b.Id == id);

            var viewModel = new BranchFormViewModel
            {
                Heading = "Update Branch",
                Name = branch.Name,
                Address = branch.Address
            };


            return View("BranchForm", viewModel);
        }


        [HttpPost]
        public ActionResult EditBranch(BranchFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("BranchForm", viewModel);

            var branch = _context.Branches.Single(b => b.Id == viewModel.Id);
            branch.Name = viewModel.Name;
            branch.Address = viewModel.Address;

            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}