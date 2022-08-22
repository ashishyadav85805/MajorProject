using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGOManagementSystem.Data;
using NGOManagementSystem.Models;

namespace NGOManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaytmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaytmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Paytms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paytm.ToListAsync());
        }

        // GET: Admin/Paytms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paytm = await _context.Paytm
                .FirstOrDefaultAsync(m => m.PaytmId == id);
            if (paytm == null)
            {
                return NotFound();
            }

            return View(paytm);
        }

        // GET: Admin/Paytms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Paytms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaytmId,PaytmMethods")] Paytm paytm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paytm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paytm);
        }

        // GET: Admin/Paytms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paytm = await _context.Paytm.FindAsync(id);
            if (paytm == null)
            {
                return NotFound();
            }
            return View(paytm);
        }

        // POST: Admin/Paytms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaytmId,PaytmMethods")] Paytm paytm)
        {
            if (id != paytm.PaytmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paytm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaytmExists(paytm.PaytmId))
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
            return View(paytm);
        }

        // GET: Admin/Paytms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paytm = await _context.Paytm
                .FirstOrDefaultAsync(m => m.PaytmId == id);
            if (paytm == null)
            {
                return NotFound();
            }

            return View(paytm);
        }

        // POST: Admin/Paytms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paytm = await _context.Paytm.FindAsync(id);
            _context.Paytm.Remove(paytm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaytmExists(int id)
        {
            return _context.Paytm.Any(e => e.PaytmId == id);
        }
    }
}
