using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonRepository : IPersonRepository<Guid, Person>, IBaseRepository<Person>
    {
    }

    public interface IPersonRepository<TKey, TDALEntity> : IBaseRepository<TKey,TDALEntity> 
        where TDALEntity : class, IDomainBaseEntity<TKey>, new() 
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TDALEntity>> AllFamilyPersons(Guid? userId = null);
        Task<TDALEntity> OnePerson(Guid? userId = null);
        Task<TDALEntity> PersonByName(string fullName);
        Task<TDALEntity> RecipientPerson(string email);
        Task<IEnumerable<TDALEntity>> AllAsync(Guid? userId = null);
        Task<TDALEntity> FirstOrDefaultAsync(Guid id, Guid? userId = null);
        Task<bool> ExistAny(string email);
        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        
        
    }
    

    
}