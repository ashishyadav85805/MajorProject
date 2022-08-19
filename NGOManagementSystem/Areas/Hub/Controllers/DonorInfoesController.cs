﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGOManagementSystem.Data;
using NGOManagementSystem.Models;

namespace NGOManagementSystem.Areas.Hub.Controllers
{
    [Area("Hub")]
    public class DonorInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hub/DonorInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonorInfo.Include(d => d.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hub/DonorInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorInfo = await _context.DonorInfo
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donorInfo == null)
            {
                return NotFound();
            }

            return View(donorInfo);
        }

        // GET: Hub/DonorInfoes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Hub/DonorInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonorId,DonorName,Address,PhoneNumber,CategoryId")] DonorInfo donorInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donorInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", donorInfo.CategoryId);
            return View(donorInfo);
        }

        // GET: Hub/DonorInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorInfo = await _context.DonorInfo.FindAsync(id);
            if (donorInfo == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", donorInfo.CategoryId);
            return View(donorInfo);
        }

        // POST: Hub/DonorInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonorId,DonorName,Address,PhoneNumber,CategoryId")] DonorInfo donorInfo)
        {
            if (id != donorInfo.DonorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donorInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorInfoExists(donorInfo.DonorId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", donorInfo.CategoryId);
            return View(donorInfo);
        }

        // GET: Hub/DonorInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorInfo = await _context.DonorInfo
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donorInfo == null)
            {
                return NotFound();
            }

            return View(donorInfo);
        }

        // POST: Hub/DonorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donorInfo = await _context.DonorInfo.FindAsync(id);
            _context.DonorInfo.Remove(donorInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorInfoExists(int id)
        {
            return _context.DonorInfo.Any(e => e.DonorId == id);
        }
    }
}