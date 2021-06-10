using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab5.Models;

namespace lab5.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppliContext _context;

        public DoctorsController(AppliContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Doctor()
        {
            return View(await _context.doctors.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew([Bind("id,name,speciality")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Doctor));
            }
            return View(doctors);
        }


        public ActionResult CreateNew()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.doctors.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,speciality")] Doctors doctors)
        {
            if (id != doctors.id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Doctor));
            }
            return View(doctors);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.doctors.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.doctors.FindAsync(id);
            if (per == null) return NotFound();
            _context.doctors.Remove(per);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Doctor));
        }
    }
}
