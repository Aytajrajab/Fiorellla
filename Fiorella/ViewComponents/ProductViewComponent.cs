using Fiorella.DAL;
using Fiorella.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiorella.ViewComponents
{
    public class ProductViewComponent :ViewComponent
    {
        private AppDbContext _context;
        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
           var products = _context.Products.Include(p=>p.Category).ToList();
            return View(products);
        }
    }
}
