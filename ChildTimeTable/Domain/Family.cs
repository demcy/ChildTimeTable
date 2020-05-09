using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Family : DomainEntityMetadata
    {
        //public int FamilyId { get; set; } 
        
        //[MaxLength(64)]
        //public string FamilyValue { get; set; }

        public ICollection<Person> Persons { get; set; }
        
    }
}