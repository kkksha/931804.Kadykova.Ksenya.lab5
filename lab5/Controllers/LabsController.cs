using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab5.Models;

namespace lab5.Controllers
{
    public class LabsController : Controller
    {
        private readonly AppliContext _context;

        public LabsController(AppliContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lab()
        {
            return View(await _context.labs.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew([Bind("id,name,adress")] Labs labs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lab));
            }
            return View(labs);
        }


        public ActionResult CreateNew()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.labs.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,adress")] Labs labs)
        {
            if (id != labs.id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(labs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lab));
            }
            return View(labs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.labs.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.labs.FindAsync(id);
            if (per == null) return NotFound();
            _context.labs.Remove(per);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Lab));
        }
    }
}
