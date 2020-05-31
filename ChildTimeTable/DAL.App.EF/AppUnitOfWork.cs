using System;
using System.Collections.Generic;
using System.ComponentModel;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<Guid, ApplicationDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(ApplicationDbContext uowDbContext) : base(uowDbContext)
        {
        }
        
        public INotificationRepository Notifications => 
            GetRepository<INotificationRepository>(()=> new NotificationRepository(UOWDbContext));
        public IObligationRepository Obligations => 
            GetRepository<IObligationRepository>(()=> new ObligationRepository(UOWDbContext));
        public IPersonRepository Persons => 
            GetRepository<IPersonRepository>(()=> new PersonRepository(UOWDbContext));

        public IFamilyRepository Families => 
            GetRepository<IFamilyRepository>(()=> new FamilyRepository(UOWDbContext));

        public ILocationRepository Locations => 
            GetRepository<ILocationRepository>(()=> new LocationRepository(UOWDbContext));
        public ITimeRepository Times => 
            GetRepository<ITimeRepository>(()=> new TimeRepository(UOWDbContext));
        
        public ILangStrRepository LangStrs =>
            GetRepository<ILangStrRepository>(() => new LangStrRepository(UOWDbContext));

        public ILangStrTranslationRepository LangStrTranslations =>
            GetRepository<ILangStrTranslationRepository>(() => new LangStrTranslationRepository(UOWDbContext));

        public ITrackPointRepository TrackPoints =>
            GetRepository<ITrackPointRepository>(() => new TrackPointRepository(UOWDbContext));

        public ITrackRepository Tracks =>
            GetRepository<ITrackRepository>(() => new TrackRepository(UOWDbContext));

    }
}