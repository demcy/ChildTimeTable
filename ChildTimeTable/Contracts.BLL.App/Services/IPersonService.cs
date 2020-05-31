using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IPersonService : IBaseEntityService<Person>, IPersonRepositoryCustom<Person>
    {
        Task<bool> ExistAny(string email);
        Task<Person> OnePerson(Guid? userId = null);
        Task<Person> RecipientPerson(string email);
        Task<IEnumerable<Person>> AllFamilyPersons(Guid? userId = null);
        Task<Person> PersonByName(string fullName);
    }
}