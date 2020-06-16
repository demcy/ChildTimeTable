using System;
using System.Linq;
using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonMapper: BaseMapper<BLL.App.DTO.Person, Person>
    {
        public PersonMapper()
        {
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.PersonDisplay, Person>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.PersonDisplay, PersonView>();
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }

        
        public PersonView PersonViewDisplayMapper(BLL.App.DTO.PersonDisplay inObject)
        {
            return Mapper.Map<PersonView>(inObject);
        }
        
        public Person PersonDisplayMapper(BLL.App.DTO.PersonDisplay inObject)
        {
            return Mapper.Map<Person>(inObject);
        }
        
        

        
    }
}