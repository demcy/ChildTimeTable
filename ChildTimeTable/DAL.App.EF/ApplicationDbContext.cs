using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.Base;
//using com.akaver.sportmap.Contracts.Domain;
using Domain.App;
using Domain.App.Identity;
using Domain.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IBaseEntityTracker
    {
        private IUserNameProvider _userNameProvider;
        public DbSet<Family> Families { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<Obligation> Obligations { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Time> Times { get; set; } = default!;
        
        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<TrackPoint> TrackPoints { get; set; } = default!;


        public DbSet<LangStr> LangStrs { get; set; } = default!;
        public DbSet<LangStrTranslation> LangStrTranslation { get; set; } = default!;
        


        private readonly Dictionary<IDomainEntityId<Guid>, IDomainEntityId<Guid>> _entityTracker =
            new Dictionary<IDomainEntityId<Guid>, IDomainEntityId<Guid>>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserNameProvider userNameProvider) : base(options)
        {
            _userNameProvider = userNameProvider;
        }
        
        public void AddToEntityTracker(IDomainEntityId<Guid> internalEntity, IDomainEntityId<Guid> externalEntity)
        {
            _entityTracker.Add(internalEntity, externalEntity);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model
                .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            // enable cascade delete on LangStr->LangStrTranslations
            builder.Entity<LangStr>()
                .HasMany(s => s.Translations)
                .WithOne(l => l.LangStr!)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<LangStrTranslation>().HasIndex(i => new {i.Culture, i.LangStrId}).IsUnique();
        }
        
        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            // enable cascade delete on GpsSession->GpsLocation
            builder.Entity<GpsSession>()
                .HasMany(s => s.GpsLocations)
                .WithOne(l => l.GpsSession!)
                .OnDelete(DeleteBehavior.Cascade);

            

            // indexes
            builder.Entity<GpsSession>().HasIndex(i => i.CreatedAt);
            builder.Entity<GpsSession>().HasIndex(i => i.RecordedAt);
            builder.Entity<GpsLocation>().HasIndex(i => i.CreatedAt);
            builder.Entity<GpsLocation>().HasIndex(i => i.RecordedAt);

            
        }*/

        private void SaveChangesMetadataUpdate()
        {
            // update the state of ef tracked objects
            ChangeTracker.DetectChanges();
            
            var markedAsAdded = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entityEntry in markedAsAdded)
            {
                if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;

                entityWithMetaData.CreatedAt = DateTime.Now;
                entityWithMetaData.CreatedBy = _userNameProvider.CurrentUserName;
                entityWithMetaData.ChangedAt = entityWithMetaData.CreatedAt;
                entityWithMetaData.ChangedBy = entityWithMetaData.CreatedBy;
            }

            var markedAsModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entityEntry in markedAsModified)
            {
                // check for IDomainEntityMetadata
                if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;

                entityWithMetaData.ChangedAt = DateTime.Now;
                entityWithMetaData.ChangedBy = _userNameProvider.CurrentUserName;

                // do not let changes on these properties get into generated db sentences - db keeps old values
                entityEntry.Property(nameof(entityWithMetaData.CreatedAt)).IsModified = false;
                entityEntry.Property(nameof(entityWithMetaData.CreatedBy)).IsModified = false;
            }
        }
        
        private void UpdateTrackedEntities()
        {
            foreach (var (key, value) in _entityTracker)
            {
                value.Id = key.Id;
            }
        }
        
        public override int SaveChanges()
        {
            SaveChangesMetadataUpdate();
            var result = base.SaveChanges();
            UpdateTrackedEntities();
            return result;
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SaveChangesMetadataUpdate();
            var result = base.SaveChangesAsync(cancellationToken);
            UpdateTrackedEntities();
            return result;
        }
    }
}