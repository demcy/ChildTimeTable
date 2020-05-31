using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface INotificationService : IBaseEntityService<Notification>, INotificationRepositoryCustom<Notification>
    {
        Task<IEnumerable<Notification>> AllImportant(Guid? userId = null);
        
    }
}