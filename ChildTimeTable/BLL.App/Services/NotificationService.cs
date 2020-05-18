using System;
using System.Collections.Generic;
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

        public Task<IEnumerable<Notification>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }
    }
}