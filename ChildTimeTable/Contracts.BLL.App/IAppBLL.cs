using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {

        public IFamilyService Families { get; }
        public ILocationService Locations { get; }
        public INotificationService Notifications { get; }
        public IObligationService Obligations { get; }
        public IPersonService Persons { get; }
        public ITimeService Times { get; }
    }
}