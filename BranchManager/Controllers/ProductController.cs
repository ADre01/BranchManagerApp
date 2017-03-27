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
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }



        public ActionResult viewProducts()
        {
            var viewModel = new AssociateViewModel
            {
                AllProducts = _context.Products.ToList()
            };


            return View("viewProducts", viewModel);
        }


        public ActionResult CreateProduct()
        {
            var viewModel = new ProductFormViewModel
            {
                Heading = "Add a New Product"
            };

            return View("ProductForm", viewModel);
        }


        [HttpPost]
        public ActionResult CreateProduct(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ProductForm", viewModel);

            var product = new Product
            {
                Price = viewModel.Price,
                Title = viewModel.Title,
                Description = viewModel.Description 
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult EditProduct(int Id)
        {
            var product = _context.Products.Single(p => p.Id == Id);
            var viewModel = new ProductFormViewModel
            {
                Heading = "Update Product",
                Title = product.Title,
                Description = product.Description,
                Price = product.Price
            };

            return View("EditProduct", viewModel);
        }


        [HttpPost]
        public ActionResult EditProduct(ProductFormViewModel viewModel, string action)
        {

            switch (action)
            {
                case "update":

                    if (!ModelState.IsValid)
                        return View("EditProduct", viewModel);

                    var product = _context.Products.Single(p => p.Id == viewModel.Id);
                    product.Title = viewModel.Title;
                    product.Description = viewModel.Description;
                    product.Price = viewModel.Price;

                    break;
                case "delete":
                    var productToRemove = _context.Products.Single(p => p.Id == viewModel.Id);
                    _context.Products.Remove(productToRemove);
                    break;
            }

            

            _context.SaveChanges();

            return RedirectToAction("viewProducts", "Product");
        }


        public ActionResult Details(int id)
        {
            var product = _context.Products.Single(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Heading = product.Title + " Details"
            };


            return View("Details", viewModel);
        }

    }
}