using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Obligation = DAL.App.DTO.Obligation;

namespace DAL.App.EF.Repositories
{
    public class ObligationRepository : EFBaseRepository<ApplicationDbContext, Domain.Obligation, DAL.App.DTO.Obligation>, IObligationRepository
    {
        public ObligationRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Obligation, DAL.App.DTO.Obligation>())
        {
        }

        public async Task<List<DateTime>> DatesList(Guid? userId = null)
        {
            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            return await RepoDbSet.Where(o => o.ParentId == personId || o.ChildId == personId)
                .Select(o => o.Time).Select(t => t.StartTime).ToListAsync();
        }
        
        public async Task<IEnumerable<Obligation>> AllPerDay(DateTime dt ,Guid? userId = null)
        {
            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            return (await RepoDbSet.Where(o=>o.Time.StartTime.Day==dt.Day)
                .Where(o=>o.ParentId==personId || o.ChildId==personId)
                .OrderBy(o=>o.Time.StartTime).ToListAsync())
                .Select(dbEntity => Mapper.Map(dbEntity));
        }
        
        public Task<IEnumerable<Obligation>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Obligation> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }
    }
}