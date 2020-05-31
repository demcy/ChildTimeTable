using AutoMapper;
using BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class NotificationServiceMapper : BaseMapper<DALAppDTO.Notification, BLLAppDTO.Notification>, INotificationServiceMapper
    {
        public NotificationServiceMapper()
        {
            MapperConfigurationExpression.CreateMap<BLLAppDTO.Notification, DALAppDTO.Notification>()
                .ForMember(item=>item.Sender,
                    o=>o.Ignore())
                .ForMember(item=>item.Recipient,
                    o=>o.Ignore());
            MapperConfigurationExpression.CreateMap<DALAppDTO.Notification, BLLAppDTO.Notification>()
                .ForMember(item=>item.Sender,
                    o=>o.Ignore())
                .ForMember(item=>item.Recipient,
                    o=>o.Ignore());
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}