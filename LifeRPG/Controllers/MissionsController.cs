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
    public class MissionsController : Controller
    {
        private readonly LifeRPGContext _context;

        public MissionsController(LifeRPGContext context)
        {
            _context = context;
        }

        // GET: Missions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Missions.ToListAsync());
        }

        // GET: Missions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missions = await _context.Missions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (missions == null)
            {
                return NotFound();
            }

            return View(missions);
        }

        // GET: Missions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Missions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Parent,Completed,Title,Description,Difficulty,Productiveness,Fear,TimeCreated,TimeUpdated,TimeDue,TimeCompleted,LevelCreated,LevelDone,Continuous,Repetition,IconAsset,Notes,Interval,Duration,DurationUnits,RewardPoints,SeriesId,RelativePosition,IsDueAtSpecificTime,HasReminders,HasLocation,Latitude,Longitude")] Missions missions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(missions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(missions);
        }

        // GET: Missions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missions = await _context.Missions.FindAsync(id);
            if (missions == null)
            {
                return NotFound();
            }
            return View(missions);
        }

        // POST: Missions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Parent,Completed,Title,Description,Difficulty,Productiveness,Fear,TimeCreated,TimeUpdated,TimeDue,TimeCompleted,LevelCreated,LevelDone,Continuous,Repetition,IconAsset,Notes,Interval,Duration,DurationUnits,RewardPoints,SeriesId,RelativePosition,IsDueAtSpecificTime,HasReminders,HasLocation,Latitude,Longitude")] Missions missions)
        {
            if (id != missions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(missions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionsExists(missions.Id))
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
            return View(missions);
        }

        // GET: Missions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missions = await _context.Missions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (missions == null)
            {
                return NotFound();
            }

            return View(missions);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var missions = await _context.Missions.FindAsync(id);
            _context.Missions.Remove(missions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissionsExists(long id)
        {
            return _context.Missions.Any(e => e.Id == id);
        }
    }
}
