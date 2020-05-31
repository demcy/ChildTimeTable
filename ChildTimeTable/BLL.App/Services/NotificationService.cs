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


namespace BLL.App.Services
{
    public class NotificationService :
        BaseEntityService<IAppUnitOfWork, INotificationRepository , INotificationServiceMapper,
            DAL.App.DTO.Notification, BLL.App.DTO.Notification>, INotificationService 
    {
        public NotificationService(IAppUnitOfWork uow) : base(uow, uow.Notifications,
            new NotificationServiceMapper())
        {
        }

        public async Task<IEnumerable<Notification>> AllImportant(Guid? userId = null)
        {
            return (await UOW.Notifications.AllImportant(userId))
                .Select(dbEntity => Mapper.Map(dbEntity));
        }
    }
    
        /*public async Task<IEnumerable<Notification>> AllImportant(Guid? userId = null)=>
            (await ServiceRepository.AllImportant(userId)).Select( dalEntity => Mapper.Map(dalEntity) );
        */
    
}