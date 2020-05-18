using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Time = DAL.App.DTO.Time;

namespace DAL.App.EF.Repositories
{
    public class TimeRepository : EFBaseRepository<ApplicationDbContext, Domain.Time, DAL.App.DTO.Time>, ITimeRepository
    {
        public TimeRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Time, DAL.App.DTO.Time>())
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