using System;
using System.Collections.Generic;
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
    public class TimeService :
        BaseEntityService<IAppUnitOfWork, ITimeRepository , ITimeServiceMapper,
            DAL.App.DTO.Time, BLL.App.DTO.Time>, ITimeService 
    {
        public TimeService(IAppUnitOfWork uow) : base(uow, uow.Times,
            new TimeServiceMapper())
        {
        }

    }


}