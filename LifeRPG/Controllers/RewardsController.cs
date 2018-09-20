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
    public class RewardsController : Controller
    {
        private readonly LifeRPGContext _context;

        public RewardsController(LifeRPGContext context)
        {
            _context = context;
        }

        // GET: Rewards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rewards.ToListAsync());
        }

        // GET: Rewards/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewards = await _context.Rewards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewards == null)
            {
                return NotFound();
            }

            return View(rewards);
        }

        // GET: Rewards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,QuantityAvailable,ClaimTotal,Cost,TimeCreated,TimeUpdated,TimeLastUpdated,IconAsset,IsCostIncrementing,CostIncrement,AddsToInventory,Category")] Rewards rewards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rewards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewards);
        }

        // GET: Rewards/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewards = await _context.Rewards.FindAsync(id);
            if (rewards == null)
            {
                return NotFound();
            }
            return View(rewards);
        }

        // POST: Rewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,QuantityAvailable,ClaimTotal,Cost,TimeCreated,TimeUpdated,TimeLastUpdated,IconAsset,IsCostIncrementing,CostIncrement,AddsToInventory,Category")] Rewards rewards)
        {
            if (id != rewards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardsExists(rewards.Id))
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
            return View(rewards);
        }

        // GET: Rewards/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewards = await _context.Rewards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewards == null)
            {
                return NotFound();
            }

            return View(rewards);
        }

        // POST: Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var rewards = await _context.Rewards.FindAsync(id);
            _context.Rewards.Remove(rewards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardsExists(long id)
        {
            return _context.Rewards.Any(e => e.Id == id);
        }
    }
}
