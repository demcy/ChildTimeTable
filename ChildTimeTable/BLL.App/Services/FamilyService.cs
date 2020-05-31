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
    public class FamilyService :
        BaseEntityService<IAppUnitOfWork, IFamilyRepository , IFamilyServiceMapper,
            DAL.App.DTO.Family, BLL.App.DTO.Family>, IFamilyService 
    {
        public FamilyService(IAppUnitOfWork uow) : base(uow, uow.Families,
            new FamilyServiceMapper())
        {
        }

    }
}