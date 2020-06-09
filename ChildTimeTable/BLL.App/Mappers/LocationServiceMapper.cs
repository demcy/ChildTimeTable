using AutoMapper;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class LocationServiceMapper : BaseMapper<DALAppDTO.Location, BLLAppDTO.Location>, ILocationServiceMapper
    {
        public LocationServiceMapper()
        {
            MapperConfigurationExpression.CreateMap<BLLAppDTO.Location, DALAppDTO.Location>()
                .ForMember(item=>item.Person,
                    k=>k.Ignore());
            MapperConfigurationExpression.CreateMap<DALAppDTO.Location, BLLAppDTO.Location>()
                .ForMember(item=>item.Person,
                    k=>k.Ignore())
                .ForMember(item=>item.Obligations,
                    k=>k.Ignore());
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
    }
}