using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;


namespace BLL.App.Services
{
    public class PersonService :
        BaseEntityService<IAppUnitOfWork, IPersonRepository , IPersonServiceMapper,
            DAL.App.DTO.Person, BLL.App.DTO.Person>, IPersonService 
    {
        public PersonService(IAppUnitOfWork uow) : base(uow, uow.Persons,
            new PersonServiceMapper())
        {
        }


        public async Task<bool> ExistAny(string email)
        {
            return await UOW.Persons.ExistAny(email); 
        }

        public async Task<Person> OnePerson(Guid? userId = null)
        {
            return Mapper.MapPersonDisplay(await UOW.Persons.OnePerson(userId));
        }

        public async Task<Person> RecipientPerson(string email)
        {
            return Mapper.Map(await UOW.Persons.RecipientPerson(email));
        }

        public async Task<IEnumerable<Person>> AllFamilyPersons(Guid? userId = null)
        {
            return (await UOW.Persons.AllFamilyPersons(userId))
                .Select(e => Mapper.Map(e));

        }

        public async Task<Person> PersonByName(string fullName)
        {
            return Mapper.Map(await UOW.Persons.PersonByName(fullName));
        }
    }
    

        /*
        public async Task<Person> OnePerson(Guid? userId = null)=>
            Mapper.Map(await ServiceRepository.OnePerson(userId));
        public async Task<Person> PersonByName(string fullName)=>
            Mapper.Map(await ServiceRepository.PersonByName(fullName));
        public async Task<Person> RecipientPerson(string email)=>
            Mapper.Map(await ServiceRepository.RecipientPerson(email));
        public async Task<IEnumerable<BLL.App.DTO.Person>> AllFamilyPersons(Guid? userId = null)=>
            (await ServiceRepository.AllFamilyPersons(userId)).Select( dalEntity => Mapper.Map(dalEntity) );
        public async Task<bool> ExistAny(string email)=>
            await ServiceRepository.ExistAny(email);
        
*/
        
        
        
    
}