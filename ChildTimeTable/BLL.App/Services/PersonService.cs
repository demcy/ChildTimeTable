using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Person> OnePerson(Guid? userId = null)=>
            Mapper.Map(await ServiceRepository.OnePerson(userId));
        
        public async Task<Person> PersonByName(string fullName)=>
            Mapper.Map(await ServiceRepository.PersonByName(fullName));
        
        public async Task<Person> RecipientPerson(string email)=>
            Mapper.Map(await ServiceRepository.RecipientPerson(email));
        

        public async Task<IEnumerable<BLL.App.DTO.Person>> AllAsync(Guid? userId = null)=>
            (await ServiceRepository.AllAsync(userId)).Select( dalEntity => Mapper.Map(dalEntity) );
        
        public async Task<IEnumerable<BLL.App.DTO.Person>> AllFamilyPersons(Guid? userId = null)=>
            (await ServiceRepository.AllFamilyPersons(userId)).Select( dalEntity => Mapper.Map(dalEntity) );
        

        public async Task<BLL.App.DTO.Person> FirstOrDefaultAsync(Guid id, Guid? userId = null)=>
            Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, userId));

        public async Task<bool> ExistAny(string email)=>
            await ServiceRepository.ExistAny(email);
        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)=>
            await ServiceRepository.ExistsAsync(id, userId);

        public async Task DeleteAsync(Guid id, Guid? userId = null)=>
            await ServiceRepository.DeleteAsync(id, userId);
        
        
    }
}