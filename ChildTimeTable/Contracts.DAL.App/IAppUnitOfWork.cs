using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork: IBaseUnitOfWork
    {
        
        INotificationRepository Notifications { get; }
        IObligationRepository Obligations { get; }
        IPersonRepository Persons { get; }
        IBaseRepository<Time> Times { get; }
        IBaseRepository<Family> Families { get; }
        IBaseRepository<Location> Locations { get; }
    }
}