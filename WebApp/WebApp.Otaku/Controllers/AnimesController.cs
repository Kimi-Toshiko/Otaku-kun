using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.DBO;
using WebApp.DAL.Repositories;
using WebApp.Otaku;
using WebApp.Otaku.Models;

namespace WebApp.Otaku.Controllers
{
    public class AnimesController : Controller
    {
        private readonly IRepository<Anime> _animeRepo;
        private readonly IRepository<Status> _statusRepo;

        public AnimesController(IRepository<Anime> animeRepo, IRepository<Status> statusRepo)
        {
            _animeRepo = animeRepo;
            _statusRepo = statusRepo;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            return View(await _animeRepo.GetAllAsync());
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _animeRepo.GetByIdAsync(id.Value);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["StatusID"] = new SelectList(await _statusRepo.GetAllAsync(), "ID", "ProgressionStatus");
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,StatusID,AgeRestriction,EpisodesAmount,Author,Studio,DubTeam,LinkToWatch")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                await _animeRepo.CreateAsync(anime);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusID"] = new SelectList(await _statusRepo.GetAllAsync(), "ID", "ProgressionStatus", anime.StatusID);
            return View(anime);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _animeRepo.GetByIdAsync(id.Value);
            if (anime == null)
            {
                return NotFound();
            }
            ViewData["StatusID"] = new SelectList(await _statusRepo.GetAllAsync(), "ID", "ProgressionStatus", anime.StatusID);
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,StatusID,AgeRestriction,EpisodesAmount,Author,Studio,DubTeam,LinkToWatch")] Anime anime)
        {
            if (id != anime.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _animeRepo.UpdateAsync(anime);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_animeRepo.Exists(anime.ID))
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
            ViewData["StatusID"] = new SelectList(await _statusRepo.GetAllAsync(), "ID", "ProgressionStatus", anime.StatusID);
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _animeRepo.GetByIdAsync(id.Value);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _animeRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
