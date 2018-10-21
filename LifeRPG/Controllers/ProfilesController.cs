using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeRPG.Models;
using LifeRPG.ViewModels;

namespace LifeRPG.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly LifeRPGContext _context;

        public ProfilesController(LifeRPGContext context)
        {
            _context = context;
        }

        // GET: ProfileViewModels
        public IActionResult Index()
        {
            List<Profiles> profiles = _context.Profiles.ToList();
            List<Missions> missions = _context.Missions.ToList();
            List<ProfileViewModel> model = new List<ProfileViewModel>();
            foreach (Profiles p in profiles)
            {
                model.Add(new ProfileViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Title = p.Title,
                    Avatar = p.Avatar,
                    Description = p.Description,
                    RewardPoints = p.RewardPoints,
                    XP = (int)missions.Sum(m => m.Fear + m.Productiveness + m.Difficulty)
                });
            }            
            return View(model);
        }

        // GET: ProfileViewModels/Details/5
        public IActionResult Details(int? id)
        {
            Profiles profile = _context.Profiles.FirstOrDefault(p=>p.Id==id);
            //TODO: add support for more than one profile in each table
            List<Missions> missions = _context.Missions.ToList();
            ProfileViewModel model = new ProfileViewModel();
            if (profile != null)
            {
                model = new ProfileViewModel()
                {
                    Id = profile.Id,
                    Name = profile.Name,
                    Title = profile.Title,
                    Avatar = profile.Avatar,
                    Description = profile.Description,
                    RewardPoints = profile.RewardPoints,
                    XP = (int)missions.Sum(m => m.Fear + m.Productiveness + m.Difficulty)
                };
            }
            
            return View(model);
        }

        // GET: ProfileViewModels/Edit/5
        public IActionResult Edit(int? id)
        {
            Profiles profile = _context.Profiles.FirstOrDefault(p => p.Id == id);
            //TODO: add support for more than one profile in each table
            List<Missions> missions = _context.Missions.ToList();
            ProfileViewModel model = new ProfileViewModel();
            if (profile != null)
            {
                model = new ProfileViewModel()
                {
                    Id = profile.Id,
                    Name = profile.Name,
                    Title = profile.Title,
                    Avatar = profile.Avatar,
                    Description = profile.Description,
                    RewardPoints = profile.RewardPoints,
                    XP = (int)missions.Sum(m => m.Fear + m.Productiveness + m.Difficulty)
                };
            }
            return View(model);
        }

        // POST: ProfileViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Avatar,Description")] ProfileViewModel profileViewModel)
        {
            if (id != profileViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                List<Profile> profile = new List<Profile>()
                    {
                        new Profile(){Setting="name",Value=profileViewModel.Name},
                        new Profile(){Setting="title",Value=profileViewModel.Title},
                        new Profile(){Setting="avatar",Value=profileViewModel.Avatar},
                        new Profile(){Setting="description",Value=profileViewModel.Description},
                        new Profile(){Setting="rewardPoints",Value=profileViewModel.RewardPoints.ToString()}
                    };
                foreach (var item in profile)
                {
                    _context.Update(item);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(profileViewModel);
        }
    }
}
