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
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }

        
        public Person PersonDisplayMapper(BLL.App.DTO.PersonDisplay inObject)
        {
            return Mapper.Map<Person>(inObject);
        }
        
        

        
    }
}