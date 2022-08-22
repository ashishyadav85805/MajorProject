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
    public class DonorDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonorDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonorDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDetail>>> GetDonorDetail()
        {
            return await _context.DonorDetail.ToListAsync();
        }

        // GET: api/DonorDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorDetail>> GetDonorDetail(int id)
        {
            var donorDetail = await _context.DonorDetail.FindAsync(id);

            if (donorDetail == null)
            {
                return NotFound();
            }

            return donorDetail;
        }

        // PUT: api/DonorDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonorDetail(int id, DonorDetail donorDetail)
        {
            if (id != donorDetail.OrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(donorDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorDetailExists(id))
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

        // POST: api/DonorDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DonorDetail>> PostDonorDetail(DonorDetail donorDetail)
        {
            _context.DonorDetail.Add(donorDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonorDetail", new { id = donorDetail.OrderDetailId }, donorDetail);
        }

        // DELETE: api/DonorDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DonorDetail>> DeleteDonorDetail(int id)
        {
            var donorDetail = await _context.DonorDetail.FindAsync(id);
            if (donorDetail == null)
            {
                return NotFound();
            }

            _context.DonorDetail.Remove(donorDetail);
            await _context.SaveChangesAsync();

            return donorDetail;
        }

        private bool DonorDetailExists(int id)
        {
            return _context.DonorDetail.Any(e => e.OrderDetailId == id);
        }
    }
}
