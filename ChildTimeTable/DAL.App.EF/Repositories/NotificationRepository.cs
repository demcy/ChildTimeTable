using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Notification = DAL.App.DTO.Notification;

namespace DAL.App.EF.Repositories
{
    public class NotificationRepository : EFBaseRepository<ApplicationDbContext, Domain.Notification, DAL.App.DTO.Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Notification, DAL.App.DTO.Notification>())
        {
        }

        public async Task<IEnumerable<Notification>> AllImportant(Guid? userId = null)
        {
            if (userId == null)
            {
                return await base.AllAsync();
            }

            var personId = RepoDbContext.Persons.First(p => p.AppUserId == userId).Id;
            var b =(await RepoDbSet.Where(n => n.RecipientId == personId)
                .ToListAsync()).Select(dbEntity => Mapper.Map(dbEntity));
            return b;
        }
        
        public Task<IEnumerable<Notification>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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