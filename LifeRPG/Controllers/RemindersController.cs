using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeRPG.Models;

namespace LifeRPG.Controllers
{
    public class RemindersController : Controller
    {
        private readonly LifeRPGContext _context;

        public RemindersController(LifeRPGContext context)
        {
            _context = context;
        }

        // GET: Reminders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reminders.ToListAsync());
        }

        // GET: Reminders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminders = await _context.Reminders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminders == null)
            {
                return NotFound();
            }

            return View(reminders);
        }

        // GET: Reminders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reminders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObjectType,ObjectId,ReminderAmount,ReminderUnits,JobId")] Reminders reminders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reminders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reminders);
        }

        // GET: Reminders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminders = await _context.Reminders.FindAsync(id);
            if (reminders == null)
            {
                return NotFound();
            }
            return View(reminders);
        }

        // POST: Reminders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ObjectType,ObjectId,ReminderAmount,ReminderUnits,JobId")] Reminders reminders)
        {
            if (id != reminders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reminders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemindersExists(reminders.Id))
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
            return View(reminders);
        }

        // GET: Reminders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminders = await _context.Reminders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminders == null)
            {
                return NotFound();
            }

            return View(reminders);
        }

        // POST: Reminders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var reminders = await _context.Reminders.FindAsync(id);
            _context.Reminders.Remove(reminders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemindersExists(long id)
        {
            return _context.Reminders.Any(e => e.Id == id);
        }
    }
}
