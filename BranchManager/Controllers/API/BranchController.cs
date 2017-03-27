using BranchManager.DTOs;
using BranchManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BranchManager.Controllers.API
{
    public class BranchController : ApiController
    {
        private ApplicationDbContext _context;
        public BranchController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult AddToBranch(AssociateDto dto)
        {
            var productToAdd = _context.Products.Single(p => p.Id == dto.ProductId);

             _context.Branches.Single(b => b.Id == dto.BranchId).Product.Add(productToAdd);

            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult DeleteFromBranch(AssociateDto dto)
        {
            var productToRemove = _context.Products.Single(p => p.Id == dto.ProductId);
            _context.Branches.Single(b => b.Id == dto.BranchId).Product.Remove(productToRemove);

            _context.SaveChanges();

            return Ok();
        }
    }
}
