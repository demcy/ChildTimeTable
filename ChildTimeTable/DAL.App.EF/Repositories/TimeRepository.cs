using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Domain;
using Domain.App.Identity;
using Time = DAL.App.DTO.Time;

namespace DAL.App.EF.Repositories
{
    public class TimeRepository : EFBaseRepository<ApplicationDbContext, AppUser, Domain.App.Time, DAL.App.DTO.Time>, ITimeRepository
    {
        public TimeRepository(ApplicationDbContext dbContext) : base(dbContext, 
            new DALMapper<Domain.App.Time, DAL.App.DTO.Time>())
        {
        }


        public Task<IEnumerable<Time>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Time> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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