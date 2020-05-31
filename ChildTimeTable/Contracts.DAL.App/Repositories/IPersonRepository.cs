using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>, IPersonRepositoryCustom
    {
        Task<bool> ExistAny(string email);
        Task<PersonDisplay> OnePerson(Guid? userId = null);
        Task<Person> RecipientPerson(string email);
        Task<IEnumerable<Person>> AllFamilyPersons(Guid? userId = null);
        Task<Person> PersonByName(string fullName);
    }
}

/*Task<IEnumerable<TDALEntity>> AllFamilyPersons(Guid? userId = null);
        Task<TDALEntity> OnePerson(Guid? userId = null);
        Task<TDALEntity> PersonByName(string fullName);
        Task<TDALEntity> RecipientPerson(string email);
        */