using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;


namespace BLL.App.Services
{
    public class PersonService : BaseEntityService<IPersonRepository, IAppUnitOfWork, DAL.App.DTO.Person, Person>, IPersonService
    {
        public PersonService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Person, Person>(), unitOfWork.Persons)
        {
        }

        public Task<IEnumerable<Person>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Person> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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