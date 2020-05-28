using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class NotificationService : BaseEntityService<INotificationRepository, IAppUnitOfWork, DAL.App.DTO.Notification, Notification>, INotificationService
    {
        public NotificationService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Notification, Notification>(), unitOfWork.Notifications)
        {
        }

        public async Task<IEnumerable<Notification>> AllImportant(Guid? userId = null)=>
            (await ServiceRepository.AllImportant(userId)).Select( dalEntity => Mapper.Map(dalEntity) );
        public async Task<IEnumerable<Notification>> AllAsync(Guid? userId = null)=>
            (await ServiceRepository.AllAsync(userId)).Select( dalEntity => Mapper.Map(dalEntity) );
        
        public async Task<Notification> FirstOrDefaultAsync(Guid id, Guid? userId = null)=>
            Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, userId));
        
        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)=>
            await ServiceRepository.ExistsAsync(id, userId);
        
        public async Task DeleteAsync(Guid id, Guid? userId = null)=>
            await ServiceRepository.DeleteAsync(id, userId);
    }
}