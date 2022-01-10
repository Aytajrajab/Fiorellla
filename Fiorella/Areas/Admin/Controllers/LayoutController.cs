using Fiorella.DAL;
using Fiorella.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Fiorella.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public LayoutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var layouts = await _context.Layout.ToListAsync();

            return View(layouts);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var layoutI = await _context.Layout.FindAsync(id);
            if (layoutI == null)
            {
                return NotFound();
            }
            return View(layoutI);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Layout lyt)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!lyt.file.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(lyt.file), "Not valid");
                return View(lyt);
            }

            if (lyt.file.Length > 1024 * 1000)
            {
                ModelState.AddModelError(nameof(lyt.file), "File size cannot be greater than 1 mb!");
                return View(lyt);
            }
            string fileName = Guid.NewGuid() + lyt.file.FileName;
            string wwwRoot = _env.WebRootPath;

            var path = Path.Combine(wwwRoot, "img", fileName);
            FileStream fileStream = new FileStream(path, FileMode.Create);
            await lyt.file.CopyToAsync(fileStream);
            fileStream.Close();

            await _context.Layout.AddAsync(lyt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {

            Layout layout = await _context.Layout.FindAsync(id);

            if (layout == null)
            {
                return NotFound();
            }

            return View(layout);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteCategory(int id)
        {

            Layout layout = await _context.Layout.FindAsync(id);

            if (layout == null)
            {
                return NotFound();
            }
            _context.Layout.Remove(layout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



    }
}
