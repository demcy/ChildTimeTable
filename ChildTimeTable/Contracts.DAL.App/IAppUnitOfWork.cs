using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork, IBaseEntityTracker
    {
        INotificationRepository Notifications { get; }
        IObligationRepository Obligations { get; }
        IPersonRepository Persons { get; }
        IFamilyRepository Families { get; }
        ILocationRepository Locations { get; }
        ITimeRepository Times { get; }
        
        ILangStrRepository LangStrs { get; }
        ILangStrTranslationRepository LangStrTranslations { get; }
        ITrackPointRepository TrackPoints { get; }
        ITrackRepository Tracks { get; }
    }
}