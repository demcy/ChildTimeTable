﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;
 using Contracts.DAL.Base;
 using DAL.Base;
 using Domain.Identity;
 using Microsoft.AspNetCore.Identity;

namespace Domain
{

    public class Person : Person<Guid>, IDomainEntity
    {
        
    }
    public class Person<TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [MinLength(1)] [MaxLength(64)] public virtual string FirstName { get; set; } = default!;
        [MinLength(1)] [MaxLength(64)] public virtual string LastName { get; set; } = default!;
        public virtual string Logo { get; set; } = default!;
        
        public virtual TKey AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
        
        public virtual TKey FamilyId { get; set; }
        public virtual Family? Family { get; set; }
        
        public virtual PersonType PersonType { get; set; } = default!;
        
        [InverseProperty(nameof(Notification.Sender))]
        public virtual ICollection<Notification>? SenderNotifications { get; set; }
        [InverseProperty(nameof(Notification.Recipient))]
        public virtual ICollection<Notification>? RecipientNotifications { get; set; }
        
        
        [InverseProperty(nameof(Obligation.Parent))]
        public virtual ICollection<Obligation>? ParentObligations { get; set; }
        [InverseProperty(nameof(Obligation.Child))]
        public virtual ICollection<Obligation>? ChildObligations { get; set; }
        
        public virtual ICollection<Location>? Locations { get; set; }
    
    }
}