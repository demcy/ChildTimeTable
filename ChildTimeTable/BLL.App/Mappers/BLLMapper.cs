using AutoMapper;
using BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BLLMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public BLLMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Family, BLL.App.DTO.Family>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Location, BLL.App.DTO.Location>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Notification, BLL.App.DTO.Notification>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Obligation, BLL.App.DTO.Obligation>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Person, BLL.App.DTO.Person>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Time, BLL.App.DTO.Time>();
            
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Family, DAL.App.DTO.Family>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Location, DAL.App.DTO.Location>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Notification, DAL.App.DTO.Notification>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Obligation, DAL.App.DTO.Obligation>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Person, DAL.App.DTO.Person>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Time, DAL.App.DTO.Time>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}