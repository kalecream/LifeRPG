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
    public class SkillDetailsController : Controller
    {
        private readonly LifeRPGContext _context;

        public SkillDetailsController(LifeRPGContext context)
        {
            _context = context;
        }

        // GET: SkillDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkillDetails.ToListAsync());
        }

        // GET: SkillDetails/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDetails = await _context.SkillDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skillDetails == null)
            {
                return NotFound();
            }

            return View(skillDetails);
        }

        // GET: SkillDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Skill,Description,Category,Icon,StartingXp,Notes")] SkillDetails skillDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillDetails);
        }

        // GET: SkillDetails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDetails = await _context.SkillDetails.FindAsync(id);
            if (skillDetails == null)
            {
                return NotFound();
            }
            return View(skillDetails);
        }

        // POST: SkillDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Skill,Description,Category,Icon,StartingXp,Notes")] SkillDetails skillDetails)
        {
            if (id != skillDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillDetailsExists(skillDetails.Id))
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
            return View(skillDetails);
        }

        // GET: SkillDetails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDetails = await _context.SkillDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skillDetails == null)
            {
                return NotFound();
            }

            return View(skillDetails);
        }

        // POST: SkillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var skillDetails = await _context.SkillDetails.FindAsync(id);
            _context.SkillDetails.Remove(skillDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillDetailsExists(long id)
        {
            return _context.SkillDetails.Any(e => e.Id == id);
        }
    }
}
