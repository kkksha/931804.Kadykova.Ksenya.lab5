using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab5.Models;

namespace lab5.Controllers
{
    public class PatientsController : Controller
    {
        private readonly AppliContext _context;

        public PatientsController(AppliContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Patient()
        {
            return View(await _context.patients.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew([Bind("id,name,disease")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Patient));
            }
            return View(patients);
        }


        public ActionResult CreateNew()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.patients.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,disease")] Patients patients)
        {
            if (id != patients.id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Patient));
            }
            return View(patients);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.patients.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.patients.FindAsync(id);
            if (per == null) return NotFound();
            _context.patients.Remove(per);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Patient));
        }
    }
}
