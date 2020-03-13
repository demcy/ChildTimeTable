﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }

        //[MaxLength(64)]
        public string FirstName { get; set; }
        
        //[MaxLength(64)]
        public string LastName { get; set; }

        //[MaxLength(255)]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public int FamilyId { get; set; } 
        public Family Family { get; set; }
        
        public int PersonTypeId { get; set; }
        public PersonType PersonType { get; set; }

        //public ICollection<Family> Families { get; set; }
    }
}