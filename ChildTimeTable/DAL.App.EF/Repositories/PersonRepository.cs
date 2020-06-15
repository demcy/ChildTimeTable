using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;
using PersonType = Domain.App.PersonType;


namespace DAL.App.EF.Repositories
{
    public class PersonRepository : EFBaseRepository<ApplicationDbContext, AppUser, Domain.App.Person, DAL.App.DTO.Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext) : base(dbContext, 
            new DALMapper<Domain.App.Person, DAL.App.DTO.Person>())
        {
        }
        
        
        public async Task<bool> ExistAny(string email)
        {
            return await RepoDbSet.AnyAsync(p => p.AppUser!.UserName == email);
        }

        public async Task<PersonDisplay> OnePerson(Guid? userId = null)
        {
            return (await RepoDbSet.Where(p => p.AppUserId == userId)
                .Select(dbEntity => new PersonDisplay()
                {
                    Id = dbEntity.Id,
                    AppUserId = dbEntity.AppUserId,
                    FirstName = dbEntity.FirstName,
                    LastName = dbEntity.LastName,
                    Logo = dbEntity.Logo,
                    FamilyId = dbEntity.FamilyId,
                    PersonType = dbEntity.PersonType.ToString(),
                    UnreadMessages = dbEntity.RecipientNotifications
                        .Where(n => n.Status == false)!.Count()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync());
            
            /*return Mapper.Map(await RepoDbSet.Where(p => p.AppUserId == userId)
                .FirstOrDefaultAsync());*/
        }
        
        public async Task<Person> RecipientPerson(string email)
        {
            return Mapper.Map(await RepoDbSet.Where(p => p.AppUser!.UserName == email)
                .FirstOrDefaultAsync());
        }
        
        public async Task<IEnumerable<Person>> AllFamilyPersons(Guid? userId = null)
        {
            var familyId = RepoDbSet.First(p => p.AppUserId == userId).FamilyId;
            return (await RepoDbSet.Where(p => p.FamilyId == familyId)
                .Include(p=>p.ChangedAt)
                .Include(p=>p.ChangedBy)
                .Include(p=>p.CreatedAt)
                .Include(p=>p.ChangedBy)
                .Include(p=>p.Locations)
                .Include(p=>p.ChildObligations)
                .Include(p=>p.ParentObligations)
                .Include(p=>p.RecipientNotifications
                    .Where(n => n.Status == false))
                .AsNoTracking()
                .ToListAsync()).Select(dbEntity => Mapper.Map(dbEntity));
        }
        
        public async Task<Person> PersonByName(string fullName)
        {
            return Mapper.Map(await RepoDbSet.Where(p => p.FirstName + " " + p.LastName == fullName)
                .AsNoTracking()
                .FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<PersonDisplay>> GetAllPersonsAsync()
        {
            return await RepoDbSet.AsNoTracking()
                .Select(dbEntity => new PersonDisplay()
                {
                    Id = dbEntity.Id,
                    AppUserId = dbEntity.AppUserId,
                    CreatedAt = dbEntity.CreatedAt,
                    CreatedBy = dbEntity.CreatedBy,
                    ChangedAt = dbEntity.ChangedAt,
                    ChangedBy = dbEntity.ChangedBy,
                    FirstName = dbEntity.FirstName,
                    LastName = dbEntity.LastName,
                    Logo = dbEntity.Logo,
                    FamilyId = dbEntity.FamilyId,
                    PersonType = dbEntity.PersonType.ToString(),
                    LocationCount = dbEntity.Locations!.Count,
                    ParentObligationCount = dbEntity.ParentObligations!.Count,
                    ChildObligationCount = dbEntity.ChildObligations!.Count,
                    UnreadMessages = dbEntity.RecipientNotifications
                        .Where(n => n.Status == false)!.Count()
                }).ToListAsync();
        }
        
        public async Task<PersonDisplay> GetPersonAsync(Guid? id)
        {
            return await RepoDbSet.AsNoTracking()
                .Select(dbEntity => new PersonDisplay()
                {
                    Id = dbEntity.Id,
                    AppUserId = dbEntity.AppUserId,
                    CreatedAt = dbEntity.CreatedAt,
                    CreatedBy = dbEntity.CreatedBy,
                    ChangedAt = dbEntity.ChangedAt,
                    ChangedBy = dbEntity.ChangedBy,
                    FirstName = dbEntity.FirstName,
                    LastName = dbEntity.LastName,
                    Logo = dbEntity.Logo,
                    FamilyId = dbEntity.FamilyId,
                    PersonType = dbEntity.PersonType.ToString(),
                    LocationCount = dbEntity.Locations!.Count,
                    ParentObligationCount = dbEntity.ParentObligations!.Count,
                    ChildObligationCount = dbEntity.ChildObligations!.Count,
                    UnreadMessages = dbEntity.RecipientNotifications
                        .Where(n => n.Status == false)!.Count()
                }).FirstAsync(p => p.Id == id);

            //return (await RepoDbSet.AsNoTracking().ToListAsync()).Select(e => Mapper.Map(e));
        }
        
        /*

        public async Task<Person> PersonByName(string fullName)
        {
            return Mapper.Map(await RepoDbSet.Where(p => p.FirstName + " " + p.LastName == fullName).FirstOrDefaultAsync());
        }
        
        
        public async Task<Person> RecipientPerson(string email)
        {
            return Mapper.Map(await RepoDbSet.Where(p => p.AppUser.UserName == email).FirstOrDefaultAsync());
        }
        
        

        
        
            
        }
        public async Task<IEnumerable<DAL.App.DTO.Person>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return await base.AllAsync(); // base is not actually needed, using it for clarity
            }

            return (await RepoDbSet
                .Where(p => p.AppUserId == userId)
                .Select(dbEntity=> new PersonDisplay()
                {
                    Id = dbEntity.Id,
                    FirstName = dbEntity.FirstName,
                    LastName = dbEntity.LastName,
                    Logo = dbEntity.Logo,
                    LocationCount = dbEntity.Locations.Count
                })
                .ToListAsync())
                .Select(dbEntity => Mapper.Map<PersonDisplay,DAL.App.DTO.Person>(dbEntity));
        }

        public async Task<DAL.App.DTO.Person> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(p => p.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(p => p.AppUserId == userId);
            }

            return Mapper.Map(await query.FirstOrDefaultAsync());
        }

        
        
        
        */

        
    }
}