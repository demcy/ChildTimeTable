using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Domain;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;
using Notification = DAL.App.DTO.Notification;

namespace DAL.App.EF.Repositories
{
    public class NotificationRepository : EFBaseRepository<ApplicationDbContext, AppUser, Domain.App.Notification, DAL.App.DTO.Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext, 
            new DALMapper<Domain.App.Notification, DAL.App.DTO.Notification>())
        {
        }

        public async Task<IEnumerable<Notification>> AllImportant(Guid? userId = null)
        {
            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            return (await RepoDbSet.Where(n => n.RecipientId == personId)
                .ToListAsync()).Select(dbEntity => Mapper.Map(dbEntity));
        }
        
        

       

        

        
    }
}