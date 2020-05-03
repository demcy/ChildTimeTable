using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser: IdentityUser
    {
        [MaxLength(36)] public override string Id { get; set; } = default!;
        //[MaxLength(128)] [MinLength(1)] public string FirstName { get; set; } = default!;
        //[MaxLength(128)] [MinLength(1)] public string LastName { get; set; } = default!;

        public PersonType PersonType { get; set; }

        public ICollection<Person> Persons { get; set; }
        
            
                
        
    }
}