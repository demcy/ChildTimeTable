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