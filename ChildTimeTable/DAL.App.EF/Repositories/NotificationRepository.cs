using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class NotificationRepository: EFBaseRepository<Notification, ApplicationDbContext>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        /*public async override Task<IEnumerable<Notification>> AllAsync()
        {
            //RepoDbSet.Include()

            DbSet<Person> personDbSet = RepoDbContext.Set<Person>();

            var person = personDbSet.Single(p => p.Id == id);
            var x = RepoDbSet
                .Include(n => n.Recipient)
                .Where(item => item.RecipientId == person.Id)
                .Include(n => n.Sender);
            return await x.ToListAsync();
        }*/
    }
}