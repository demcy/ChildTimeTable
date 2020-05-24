using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PersonRepository : EFBaseRepository<ApplicationDbContext, Domain.Person, DAL.App.DTO.Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Person, DAL.App.DTO.Person>())
        {
        }
        public async Task<IEnumerable<DAL.App.DTO.Person>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return await base.AllAsync(); // base is not actually needed, using it for clarity
            }

            return (await RepoDbSet
                .Where(p => p.AppUserId == userId)
                .Select(dbEntity=> new PersonDisplay()
                {
                    Id = dbEntity.Id,
                    FirstName = dbEntity.FirstName,
                    LastName = dbEntity.LastName,
                    LocationCount = dbEntity.Locations.Count
                })
                .ToListAsync())
                .Select(dbEntity => Mapper.Map<PersonDisplay,DAL.App.DTO.Person>(dbEntity));
        }

        public async Task<DAL.App.DTO.Person> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(p => p.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(p => p.AppUserId == userId);
            }

            return Mapper.Map(await query.FirstOrDefaultAsync());
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(p => p.Id == id);
            }

            return await RepoDbSet.AnyAsync(p => p.Id == id && p.AppUserId == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var person = await FirstOrDefaultAsync(id, userId);
            base.Remove(person);
        }
       
    }
}