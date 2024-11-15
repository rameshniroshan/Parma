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
    public class UsersTypesController : Controller
    {
        private readonly RegisterDb _context;

        public UsersTypesController(RegisterDb context)
        {
            _context = context;
        }

        // GET: UsersTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsersType.ToListAsync());
        }

        // GET: UsersTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersType = await _context.UsersType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersType == null)
            {
                return NotFound();
            }

            return View(usersType);
        }

        // GET: UsersTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleName,Active")] UsersType usersType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usersType);
        }

        // GET: UsersTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersType = await _context.UsersType.FindAsync(id);
            if (usersType == null)
            {
                return NotFound();
            }
            return View(usersType);
        }

        // POST: UsersTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleName,Active")] UsersType usersType)
        {
            if (id != usersType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersTypeExists(usersType.Id))
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
            return View(usersType);
        }

        // GET: UsersTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersType = await _context.UsersType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersType == null)
            {
                return NotFound();
            }

            return View(usersType);
        }

        // POST: UsersTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersType = await _context.UsersType.FindAsync(id);
            if (usersType != null)
            {
                _context.UsersType.Remove(usersType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersTypeExists(int id)
        {
            return _context.UsersType.Any(e => e.Id == id);
        }
    }
}
