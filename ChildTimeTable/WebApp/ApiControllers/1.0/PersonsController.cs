using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using DAL.App.EF;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Mappers;
using Person = PublicApi.DTO.v1.Person;
using V1DTO = PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    /// <summary>
    /// API PERSON CONTROLLER
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PersonsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PersonMapper _mapper = new PersonMapper();
        /// <summary>
        /// API PERSON CONSTRUCTOR
        /// </summary>
        /// <param name="bll"></param>
        public PersonsController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        /// <summary>
        /// GET PERSONS
        /// </summary>
        /// <returns></returns>
        // GET: api/Persons
        [HttpGet]
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.Person>))]
        public async Task<ActionResult<IEnumerable<PersonDisplay>>> GetPersons()
        {
            if (User.IsInRole("admin"))
            {
                return Ok((await _bll.Persons.GetAllPersonsAsync()).Select(e =>
                    _mapper.PersonDisplayMapper(e)));
            }

            var b = await _bll.Persons.GetAllFamilyPersons(User.UserId());
            //var g = b.Select(e => _mapper.Map(e));
            return Ok((await _bll.Persons.AllFamilyPersons(User.UserId())).Select(e =>
                _mapper.Map(e)));
        }
        
    
        // GET: api/Persons/5
        /// <summary>
        /// Find and return person from data source
        /// </summary>
        /// <param name="id">person id - guid</param>
        /// <returns>Person object based on id</returns>
        /// <response code="200">The person was successfully retrieved.</response>
        /// <response code="404">The person does not exist.</response>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.Person))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<PersonDisplay>> GetPerson(Guid id)
        {
            var person = await _bll.Persons.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Person with id {id} not found"));
            }
            return Ok(_mapper.PersonDisplayMapper(person));
        }
        
        
        //PUT: api/Persons/5
        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutPerson(Guid id, Person person)
        {
            var inProperties = person
                .GetType()
                .GetProperties()
                .ToDictionary(
                    key => key.Name,
                    val => val.GetValue(person));
            var p = await _bll.Persons.OnePerson(User.UserId());
            foreach (var property in p.GetType().GetProperties())
            {
                if (inProperties.TryGetValue(property.Name, out var value))
                {
                    if (value != null)
                    {
                        if (value.ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            property.SetValue(p, value);
                        }
                    }
                }
            }
            await _bll.Persons.UpdateAsync(p);
            await _bll.SaveChangesAsync();
            return NoContent();
        }
        
        
        // POST: api/Persons
        /// <summary>
        /// POST PERSON
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.Person))]
        public async Task<ActionResult<BLL.App.DTO.Person>> PostPerson(Person person)
        {
            var prePerson = await _bll.Persons.OnePerson(User.UserId());
            person.AppUserId = User.UserId();
            person.FamilyId = prePerson.FamilyId;

            var bllEntity = _mapper.Map(person);
            _bll.Persons.Add(bllEntity);
            await _bll.SaveChangesAsync();
            person.Id = bllEntity.Id;

            return CreatedAtAction("GetPerson",
                new {id = person.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                person);
        }
        

        // DELETE: api/Persons/5
        /// <summary>
        /// DELETE PERSON
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.Person))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<BLL.App.DTO.Person>> DeletePerson(Guid id)
        {
            var person =
                await _bll.Persons.FirstOrDefaultAsync(id);

            
            if (person == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Person with id {id} not found!"));
            }

            await _bll.Persons.RemoveAsync(person);
            await _bll.SaveChangesAsync();

            return Ok(person);
        }

        
    }
}
