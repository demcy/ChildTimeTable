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
        public AppBLL(IAppUnitOfWork uow) : base(uow)
        {
        }

        public ILangStrService LangStrs =>
            GetService<ILangStrService>(() => new LangStrService(UOW));

        public ILangStrTranslationService LangStrTranslation =>
            GetService<ILangStrTranslationService>(() => new LangStrTranslationService(UOW));

        public ITrackPointService TrackPoints =>
            GetService<ITrackPointService>(() => new TrackPointService(UOW));

        public ITrackService Tracks =>
            GetService<ITrackService>(() => new TrackService(UOW));
        public IFamilyService Families =>
            GetService<IFamilyService>(() => new FamilyService(UOW));
        public ILocationService Locations =>
            GetService<ILocationService>(() => new LocationService(UOW));
        public INotificationService Notifications =>
            GetService<INotificationService>(() => new NotificationService(UOW));
        public IObligationService Obligations =>
            GetService<IObligationService>(() => new ObligationService(UOW));
        public IPersonService Persons =>
            GetService<IPersonService>(() => new PersonService(UOW));
        public ITimeService Times =>
            GetService<ITimeService>(() => new TimeService(UOW));

        
    }
}