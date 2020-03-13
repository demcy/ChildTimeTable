using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Family
    {
        public int FamilyId { get; set; } 
        
        [MaxLength(64)]
        public string FamilyValue { get; set; }

        public ICollection<Person> Persons { get; set; }

        //public int PersonTypeId { get; set; }
        //public PersonType PersonType { get; set; }

        //public int PersonId { get; set; }
        //public Person Person { get; set; }
        
        //[MaxLength(255)]
        //public string IdentityUserId { get; set; }
        //public IdentityUser IdentityUser { get; set; }
    }
}