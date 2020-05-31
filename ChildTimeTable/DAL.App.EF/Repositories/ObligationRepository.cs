using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Domain;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;
using Obligation = DAL.App.DTO.Obligation;

namespace DAL.App.EF.Repositories
{
    public class ObligationRepository : EFBaseRepository<ApplicationDbContext, AppUser, Domain.App.Obligation, DAL.App.DTO.Obligation>, IObligationRepository
    {
        public ObligationRepository(ApplicationDbContext dbContext) : base(dbContext, 
            new DALMapper<Domain.App.Obligation, DAL.App.DTO.Obligation>())
        {
        }
        
        public async Task<IEnumerable<Obligation>> AllPerDay(DateTime dt ,Guid? userId = null)
        {
            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            return (await RepoDbSet.Where(o=>o.Time!.StartTime.Day==dt.Day)
                    .Include(o=>o.Time)
                    .Where(o=>o.ParentId==personId || o.ChildId==personId)
                    .OrderBy(o=>o.Time!.StartTime).ToListAsync())
                .Select(dbEntity => Mapper.Map(dbEntity));
        }

        public async Task<List<DateTime>> DatesList(Guid? userId = null)
        {
            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            return await RepoDbSet.Where(o => o.ParentId == personId || o.ChildId == personId)
                .Select(o => o.Time).Select(t => t!.StartTime).ToListAsync();
        }
        
        
        
        

        

        
    }
}