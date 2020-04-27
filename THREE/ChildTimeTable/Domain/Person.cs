﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;
 using Domain.Identity;
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

        public string Logo { get; set; }

        //[MaxLength(36)] 
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        //[MaxLength(255)]
        //public string IdentityUserId { get; set; }
        //public IdentityUser IdentityUser { get; set; }

        //public string FamilyName { get; set; }

        public int FamilyId { get; set; }
        public Family? Family { get; set; }
        
        
        public PersonType PersonType { get; set; }
        
        [InverseProperty(nameof(Notification.Sender))]
        public ICollection<Notification> SenderNotifications { get; set; }
        [InverseProperty(nameof(Notification.Recipient))]
        public ICollection<Notification> RecipientNotifications { get; set; }
        
        
        [InverseProperty(nameof(Obligation.Parent))]
        public ICollection<Obligation> ParentObligations { get; set; }
        [InverseProperty(nameof(Obligation.Child))]
        public ICollection<Obligation> ChildObligations { get; set; }
        

    
    }
}