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
            //create
            //MapperConfigurationExpression.CreateMap<BLLAppDTO.Time, DALAppDTO.Time>();
            //MapperConfigurationExpression.CreateMap<BLLAppDTO.Location, DALAppDTO.Location>();
            /*.ForMember(item => item.Person,
                o =>
                    o.Ignore());
                    //o.MapFrom(t=>t.Person));
            .ForMember(item => item.PersonId,
                o =>
                    o.Ignore());*/
            //MapperConfigurationExpression.CreateMap<BLLAppDTO.Person, DALAppDTO.Person>();
            MapperConfigurationExpression.CreateMap<BLLAppDTO.Obligation, DALAppDTO.Obligation>()
                .ForMember(item => item.Location,
                    o =>
                        o.Ignore())
                .ForMember(item => item.Time,
                    o =>
                        o.Ignore())
                .ForMember(item => item.Parent,
                    o =>
                        o.Ignore())
                .ForMember(item => item.Child,
                    o =>
                        o.Ignore());

            MapperConfigurationExpression.CreateMap<DALAppDTO.Time, BLLAppDTO.Time>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Location, BLLAppDTO.Location>();
            /*.ForMember(item => item.Person,
            o =>
                o.Ignore());
            //o.MapFrom(t=>t.Person));
            .ForMember(item => item.PersonId,
                o =>
                    o.Ignore());*/
            
            MapperConfigurationExpression.CreateMap<DALAppDTO.Person, BLLAppDTO.Person>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Obligation, BLLAppDTO.Obligation>()
                .ForMember(item => item.Location,
                    o =>
                        //o.Ignore())
                        o.MapFrom(t => t.Location))
                .ForMember(item => item.Time,
                    o =>
                        o.MapFrom(t => t.Time))
                .ForMember(item => item.Parent,
                    o =>
                        o.MapFrom(t => t.Parent))
                        //o.Ignore())
                .ForMember(item => item.Child,
                    o =>
                        o.MapFrom(t => t.Child));
                        //o.Ignore());
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        

        
        
        
        
        
        

        

        
    }
}