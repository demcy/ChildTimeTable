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
    public class FamilyRepository : EFBaseRepository<ApplicationDbContext, Domain.Family, DAL.App.DTO.Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Family, DAL.App.DTO.Family>())
        {
        }

        public async Task<IEnumerable<DAL.App.DTO.Family>> AllAsync(Guid? userId = null)
        {
            var query = RepoDbSet.AsQueryable();

            if (userId != null)
            {
                query = query.Where(f => f.Persons.Any(p=>p.AppUserId==userId));
            }

            return (await query.ToListAsync())
                .Select(domainEntity => Mapper.Map(domainEntity));
        }

        public async Task<Family> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet
                .Where(f => f.Id == id)
                .AsQueryable();

            if (userId != null)
            {
                query = query.Where(f => f.Persons.Any(p=>p.AppUserId==userId));
            }

            return Mapper.Map(  await query.FirstOrDefaultAsync());
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(f => f.Id == id);
            }

            return await RepoDbSet.AnyAsync(f =>
                f.Id == id && f.Persons.Any(p=>p.AppUserId==userId));
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var family = await FirstOrDefaultAsync(id, userId);
            base.Remove(family);
        }
    }
}