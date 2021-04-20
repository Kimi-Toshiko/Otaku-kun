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
    public class StatusController : Controller
    {
        private readonly IRepository<Status> _statusRepo;

        public StatusController(IRepository<Status> statusRepo)
        {
            _statusRepo = statusRepo;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(await _statusRepo.GetAllAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _statusRepo.GetByIdAsync(id.Value);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProgressionStatus")] Status status)
        {
            if (ModelState.IsValid)
            {
                await _statusRepo.CreateAsync(status);
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _statusRepo.GetByIdAsync(id.Value);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProgressionStatus")] Status status)
        {
            if (id != status.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _statusRepo.UpdateAsync(status);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_statusRepo.Exists(status.ID))
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
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _statusRepo.GetByIdAsync(id.Value);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _statusRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
