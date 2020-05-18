using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ObligationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ObligationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Obligations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Obligation>>> GetObligations()
        {
            return await _context.Obligations.ToListAsync();
        }

        // GET: api/Obligations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obligation>> GetObligation(Guid id)
        {
            var obligation = await _context.Obligations.FindAsync(id);

            if (obligation == null)
            {
                return NotFound();
            }

            return obligation;
        }

        // PUT: api/Obligations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObligation(Guid id, Obligation obligation)
        {
            if (id != obligation.Id)
            {
                return BadRequest();
            }

            _context.Entry(obligation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObligationExists(id))
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

        // POST: api/Obligations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Obligation>> PostObligation(Obligation obligation)
        {
            _context.Obligations.Add(obligation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObligation", new { id = obligation.Id }, obligation);
        }

        // DELETE: api/Obligations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Obligation>> DeleteObligation(Guid id)
        {
            var obligation = await _context.Obligations.FindAsync(id);
            if (obligation == null)
            {
                return NotFound();
            }

            _context.Obligations.Remove(obligation);
            await _context.SaveChangesAsync();

            return obligation;
        }

        private bool ObligationExists(Guid id)
        {
            return _context.Obligations.Any(e => e.Id == id);
        }
    }
}
