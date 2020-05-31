using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    
    public class ObligationService :
        BaseEntityService<IAppUnitOfWork, IObligationRepository , IObligationServiceMapper,
            DAL.App.DTO.Obligation, BLL.App.DTO.Obligation>, IObligationService 
    {
        public ObligationService(IAppUnitOfWork uow) : base(uow, uow.Obligations,
            new ObligationServiceMapper())
        {
        }

        public async Task<IEnumerable<Obligation>> AllPerDay(DateTime dt, Guid? userId = null)
        {
            var x = await UOW.Obligations.AllPerDay(dt, userId);
            return (await UOW.Obligations.AllPerDay(dt, userId))
                .Select(e => Mapper.Map(e));
        }

        public async Task<List<DateTime>> DatesList(Guid? userId = null)
        {
            return (await UOW.Obligations.DatesList(userId));
        }
    }
    
        
}