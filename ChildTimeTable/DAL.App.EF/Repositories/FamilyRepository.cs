using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class FamilyRepository : 
        EFBaseRepository<ApplicationDbContext, AppUser, Domain.App.Family, DAL.App.DTO.Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext repoDbContext) : base(repoDbContext, 
            new DALMapper<Domain.App.Family, DAL.App.DTO.Family>())
        {
            
        }

        
    }
}