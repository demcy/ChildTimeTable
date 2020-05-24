using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Person : Person<Guid, AppUser>, IDomainEntityBaseMetadata, IDomainEntityUser<AppUser>
    {
        
    }

    public class Person<TKey, TUser> : DomainEntityBaseMetadata<TKey>, IDomainEntityUser<TKey, TUser>
        where TKey : IEquatable<TKey>
        where TUser: AppUser<TKey>
    {
        [MinLength(1)] [MaxLength(64)]
        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.Person))]
        public virtual string FirstName { get; set; } = default!;
        [MinLength(1)] [MaxLength(64)] 
        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.Person))]
        public virtual string LastName { get; set; } = default!;
        public virtual string Logo { get; set; } = default!;
        public virtual TKey FamilyId { get; set; }
        public virtual Family? Family { get; set; }
        
        [Display(Name = nameof(PersonType), ResourceType = typeof(Resources.Domain.Person))]
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

        public TKey AppUserId { get; set; } = default!;
        public TUser? AppUser { get; set; }
    }
}