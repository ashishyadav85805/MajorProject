using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGOManagementSystem.Data;
using NGOManagementSystem.Models;

namespace NGOManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorInfoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonorInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonorInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorInfo>>> GetDonorInfo()
        {
            return await _context.DonorInfo.ToListAsync();
        }

        // GET: api/DonorInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorInfo>> GetDonorInfo(int id)
        {
            var donorInfo = await _context.DonorInfo.FindAsync(id);

            if (donorInfo == null)
            {
                return NotFound();
            }

            return donorInfo;
        }

        // PUT: api/DonorInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonorInfo(int id, DonorInfo donorInfo)
        {
            if (id != donorInfo.DonorId)
            {
                return BadRequest();
            }

            _context.Entry(donorInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DonorInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DonorInfo>> PostDonorInfo(DonorInfo donorInfo)
        {
            _context.DonorInfo.Add(donorInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonorInfo", new { id = donorInfo.DonorId }, donorInfo);
        }

        // DELETE: api/DonorInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DonorInfo>> DeleteDonorInfo(int id)
        {
            var donorInfo = await _context.DonorInfo.FindAsync(id);
            if (donorInfo == null)
            {
                return NotFound();
            }

            _context.DonorInfo.Remove(donorInfo);
            await _context.SaveChangesAsync();

            return donorInfo;
        }

        private bool DonorInfoExists(int id)
        {
            return _context.DonorInfo.Any(e => e.DonorId == id);
        }
    }
}
