using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : AppUser<Guid>
    {
    }

    public class AppUser<TKey>: IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        //[MaxLength(36)] public override string Id { get; set; } = default!;
        [MaxLength(128)] [MinLength(1)] public string FirstName { get; set; } = default!;
        [MaxLength(128)] [MinLength(1)] public string LastName { get; set; } = default!;

        //public virtual PersonType PersonType { get; set; } = default!;

        //public virtual ICollection<Person>? Persons { get; set; }
        
            
                
        
    }
}