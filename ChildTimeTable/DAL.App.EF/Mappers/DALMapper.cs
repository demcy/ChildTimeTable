using System;
using System.ComponentModel;
using AutoMapper;
using DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DALMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?,  new()
    {
        public DALMapper() : base()
        { 
            // add more mappings
            MapperConfigurationExpression.CreateMap<Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<Domain.App.Family, DAL.App.DTO.Family>();
            MapperConfigurationExpression.CreateMap<Domain.App.Location, DAL.App.DTO.Location>();
            MapperConfigurationExpression.CreateMap<Domain.App.Notification, DAL.App.DTO.Notification>();
            MapperConfigurationExpression.CreateMap<Domain.App.Obligation, DAL.App.DTO.Obligation>();
            MapperConfigurationExpression.CreateMap<Domain.App.Person, DAL.App.DTO.Person>();
            MapperConfigurationExpression.CreateMap<Domain.App.Time, DAL.App.DTO.Time>();

            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Family, Domain.App.Family>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Location, Domain.App.Location>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Notification, Domain.App.Notification>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Obligation, Domain.App.Obligation>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Person, Domain.App.Person>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Time, Domain.App.Time>();
            
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}