using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF
{
    public class AppUnitOfWork: EFBaseUnitOfWork<ApplicationDbContext>, IAppUnitOfWork
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
        public IBaseRepository<Time> Times => 
            GetRepository<IBaseRepository<Time>>(()=> new EFBaseRepository<Time, ApplicationDbContext>(UOWDbContext));
        public IBaseRepository<Family> Families => 
            GetRepository<IBaseRepository<Family>>(()=> new EFBaseRepository<Family,ApplicationDbContext>(UOWDbContext));
        public IBaseRepository<Location> Locations =>
            GetRepository<IBaseRepository<Location>>(()=> new EFBaseRepository<Location,ApplicationDbContext>(UOWDbContext));
        
        
             

        
    }
}