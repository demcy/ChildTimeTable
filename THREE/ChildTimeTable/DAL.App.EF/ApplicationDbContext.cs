using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public DbSet<Family> Families { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<Obligation> Obligations { get; set; } = default!;
        
        public DbSet<Notification> Notifications { get; set; } = default!;

        public DbSet<Location> Locations { get; set; } = default!;

        public DbSet<Time> Times { get; set; } = default!;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}