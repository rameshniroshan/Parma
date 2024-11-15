using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy_System.Data;
using Pharmacy_System.Models;

namespace Pharmacy_System.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly RegisterDb _context;

        public MedicinesController(RegisterDb context)
        {
            _context = context;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicines.ToListAsync());
        }

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicines = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == id);
            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

       
        // GET: Medicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicineID,Name,Brand,DosageForm,Strength,Manufacturer,ExpirationDate,ReorderLevel,PricePerUnit")] Medicines medicines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicines);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicines = await _context.Medicines.FindAsync(id);
            if (medicines == null)
            {
                return NotFound();
            }
            return View(medicines);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicineID,Name,Brand,DosageForm,Strength,Manufacturer,ExpirationDate,ReorderLevel,PricePerUnit")] Medicines medicines)
        {
            if (id != medicines.MedicineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicinesExists(medicines.MedicineID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicines);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicines = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == id);
            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicines = await _context.Medicines.FindAsync(id);
            if (medicines != null)
            {
                _context.Medicines.Remove(medicines);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicinesExists(int id)
        {
            return _context.Medicines.Any(e => e.MedicineID == id);
        }
    }
}
