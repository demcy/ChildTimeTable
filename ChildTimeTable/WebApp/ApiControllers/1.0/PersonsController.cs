using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.EF;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;
using Person = PublicApi.DTO.v1.Person;

namespace WebApp.ApiControllers._1._0
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PersonsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var persons = await _bll.Persons.AllAsync(User.UserGuidId());
            return Ok(persons);
        }
    
        // GET: api/Persons/5
        /// <summary>
        /// Find and return person from data source
        /// </summary>
        /// <param name="id">person id - guid</param>
        /// <returns>Person object based on id</returns>
        /// <response code="200">The person was successfully retrieved.</response>
        /// <response code="404">The person does not exist.</response>
        [ProducesResponseType( typeof( Person ), 200 )]	
        [ProducesResponseType( 404 )]
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await _bll.Persons.FirstOrDefaultAsync(id, User.UserGuidId());

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, PersonEdit personEdit)
        {
            if (id != personEdit.Id)
            {
                return BadRequest();
            }

            var person = await _bll.Persons.FirstOrDefaultAsync(personEdit.Id, User.UserGuidId());

            if (person == null)
            {
                return BadRequest();
            }
            person.FirstName = personEdit.FirstName;
            person.LastName = personEdit.LastName;
            
            _bll.Persons.Update(person);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Persons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Person>> PostPerson(PersonCreate personCreate)
        {
            var person = new BLL.App.DTO.Person
            {
                AppUserId = User.UserGuidId(),
                FirstName = personCreate.FirstName,
                LastName = personCreate.LastName
            };
            _bll.Persons.Add(person);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Person>> DeletePerson(Guid id)
        {
            var person = await _bll.Persons.FirstOrDefaultAsync(id, User.UserGuidId());
            if (person == null)
            {
                return NotFound();
            }

            _bll.Persons.Remove(person);
            await _bll.SaveChangesAsync();
            return Ok(person);
            
        }

        
    }
}
