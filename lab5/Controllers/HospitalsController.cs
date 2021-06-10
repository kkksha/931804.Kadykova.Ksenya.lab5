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
    public class HospitalsController : Controller
    {
        private readonly AppliContext _context;

        public HospitalsController(AppliContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Hospital()
        {
            return View(await _context.hospitals.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew([Bind("id,name,adress,phones")] Hospitals hospitals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Hospital));
            }
            return View(hospitals);
        }


        public ActionResult CreateNew()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.hospitals.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,adress,phones")] Hospitals hospitals)
        {
            if (id != hospitals.id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(hospitals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Hospital));
            }
            return View(hospitals);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.hospitals.FindAsync(id);
            if (per == null) return NotFound();
            return View(per);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var per = await _context.hospitals.FindAsync(id);
            if (per == null) return NotFound();
            _context.hospitals.Remove(per);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Hospital)); ;
        }

        //// GET: HomeController1/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: HomeController1/Create
        //public ActionResult Create()
        //{
        //    return View("CreateNew");
        //}

        //// POST: HomeController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
