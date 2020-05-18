using System;
using System.Threading.Tasks;
using BLL.App.Services;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;
using Contracts.DAL.App;
using DAL.App.EF;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IFamilyService Families =>
            GetService<IFamilyService>(() => new FamilyService(UnitOfWork));
        public ILocationService Locations =>
            GetService<ILocationService>(() => new LocationService(UnitOfWork));
        public INotificationService Notifications =>
            GetService<INotificationService>(() => new NotificationService(UnitOfWork));
        public IObligationService Obligations =>
            GetService<IObligationService>(() => new ObligationService(UnitOfWork));
        public IPersonService Persons =>
            GetService<IPersonService>(() => new PersonService(UnitOfWork));
        public ITimeService Times =>
            GetService<ITimeService>(() => new TimeService(UnitOfWork));

        
    }
}