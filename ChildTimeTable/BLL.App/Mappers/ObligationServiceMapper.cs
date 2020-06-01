using System.Runtime.CompilerServices;
using AutoMapper;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class ObligationServiceMapper : BaseMapper<DALAppDTO.Obligation, BLLAppDTO.Obligation>, IObligationServiceMapper
    {
        public ObligationServiceMapper()
        {
            MapperConfigurationExpression.CreateMap<BLLAppDTO.Time, DALAppDTO.Time>();
            MapperConfigurationExpression.CreateMap<BLLAppDTO.Obligation, DALAppDTO.Obligation>()
                .ForMember(item=>item.Location,
                    o=>o.Ignore())
                .ForMember(item=>item.Time,
                    o=> 
                        o.MapFrom(t=>t.Time))
                .ForMember(item=>item.Parent,
                    o=>o.Ignore())
                .ForMember(item=>item.Child,
                    o=>o.Ignore());

            MapperConfigurationExpression.CreateMap<DALAppDTO.Time, BLLAppDTO.Time>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Obligation, BLLAppDTO.Obligation>()
                .ForMember(item=>item.Location,
                    o=>o.Ignore())
                .ForMember(item=>item.Time,
                    o=> 
                        o.MapFrom(t=>t.Time))
                .ForMember(item=>item.Parent,
                    o=>o.Ignore())
                .ForMember(item=>item.Child,
                    o=>o.Ignore());
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public BLLAppDTO.Time MapTime1(DALAppDTO.Time inObject)
        {
            return Mapper.Map<BLLAppDTO.Time>(inObject);
        }
        
        public DALAppDTO.Time MapTime2(BLLAppDTO.Time inObject)
        {
            return Mapper.Map<DALAppDTO.Time>(inObject);
        }

        

        
    }
}