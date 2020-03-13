using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Family> Families { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<PersonType> PersonTypes { get; set; } = default!;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}