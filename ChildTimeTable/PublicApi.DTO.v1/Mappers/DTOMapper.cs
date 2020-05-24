using System;

namespace PublicApi.DTO.v1.Mappers
{
    public class DTOMapper
    {
        public Person MapPerson(BLL.App.DTO.Person BLLPerson)
        {
            return new Person()
            {
                Id = BLLPerson.Id,
                FirstName = BLLPerson.FirstName,
                LastName = BLLPerson.LastName,
                Logo = BLLPerson.Logo,
                LocationCount = BLLPerson.LocationCount
            };
        }
    }
}