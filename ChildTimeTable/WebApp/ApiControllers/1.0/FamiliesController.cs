using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers._1._0
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FamiliesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public FamiliesController(IAppBLL bll)
        {
            _bll = bll;
        }


        // GET: api/Families
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Family>>> GetFamilies()
        {
            var families = (await _bll.Families.AllAsync())
                .Select(bllEntity => new Family()
                {
                    Id = bllEntity.Id,
                }) ;
            
            return Ok(families);
        }

        // GET: api/Families/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Family>> GetFamily(Guid id)
        {
            var family = await _bll.Families.FirstOrDefaultAsync(id, User.UserGuidId());

            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        // PUT: api/Families/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamily(Guid id, BLL.App.DTO.Family family)
        {
            if (id != family.Id)
            {
                return BadRequest();
            }

            _bll.Families.Update(family);

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _bll.Families.ExistsAsync(id, User.UserGuidId()))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/Families
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Family>> PostFamily(BLL.App.DTO.Family family)
        {
            _bll.Families.Add(family);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetFamily", new { id = family.Id }, family);
        }

        // DELETE: api/Families/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Family>> DeleteFamily(Guid id)
        {
            var family = await _bll.Families.FirstOrDefaultAsync(id, User.UserGuidId());
            if (family == null)
            {
                return NotFound();
            }

            _bll.Families.Remove(family);
            await _bll.SaveChangesAsync();

            return Ok(family);
        }

        
    }
}
