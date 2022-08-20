using System;
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
    public class DonorDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hub/DonorDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonorDetail.Include(d => d.Category).Include(d => d.DonorInfo).Include(d => d.Payments);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hub/DonorDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorDetail = await _context.DonorDetail
                .Include(d => d.Category)
                .Include(d => d.DonorInfo)
                .Include(d => d.Payments)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (donorDetail == null)
            {
                return NotFound();
            }

            return View(donorDetail);
        }

        // GET: Hub/DonorDetails/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["DonorId"] = new SelectList(_context.DonorInfo, "DonorId", "DonorName");
            ViewData["PaymentMethod"] = new SelectList(_context.Payment, "DonorDetailId", "PaymentMethods");
            return View();
        }

        // POST: Hub/DonorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailId,DonorId,Amount,CategoryId,PaymentMethod")] DonorDetail donorDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donorDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", donorDetail.CategoryId);
            ViewData["DonorId"] = new SelectList(_context.DonorInfo, "DonorId", "DonorName", donorDetail.DonorId);
            ViewData["PaymentMethod"] = new SelectList(_context.Payment, "DonorDetailId", "PaymentMethods", donorDetail.PaymentMethod);
            return View(donorDetail);
        }

        // GET: Hub/DonorDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorDetail = await _context.DonorDetail.FindAsync(id);
            if (donorDetail == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", donorDetail.CategoryId);
            ViewData["DonorId"] = new SelectList(_context.DonorInfo, "DonorId", "DonorName", donorDetail.DonorId);
            ViewData["PaymentMethod"] = new SelectList(_context.Payment, "DonorDetailId", "PaymentMethods", donorDetail.PaymentMethod);
            return View(donorDetail);
        }

        // POST: Hub/DonorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailId,DonorId,Amount,CategoryId,PaymentMethod")] DonorDetail donorDetail)
        {
            if (id != donorDetail.OrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donorDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorDetailExists(donorDetail.OrderDetailId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", donorDetail.CategoryId);
            ViewData["DonorId"] = new SelectList(_context.DonorInfo, "DonorId", "DonorName", donorDetail.DonorId);
            ViewData["PaymentMethod"] = new SelectList(_context.Payment, "DonorDetailId", "PaymentMethods", donorDetail.PaymentMethod);
            return View(donorDetail);
        }

        // GET: Hub/DonorDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorDetail = await _context.DonorDetail
                .Include(d => d.Category)
                .Include(d => d.DonorInfo)
                .Include(d => d.Payments)
                .FirstOrDefaultAsync(m => m.OrderDetailId == id);
            if (donorDetail == null)
            {
                return NotFound();
            }

            return View(donorDetail);
        }

        // POST: Hub/DonorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donorDetail = await _context.DonorDetail.FindAsync(id);
            _context.DonorDetail.Remove(donorDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorDetailExists(int id)
        {
            return _context.DonorDetail.Any(e => e.OrderDetailId == id);
        }
    }
}
