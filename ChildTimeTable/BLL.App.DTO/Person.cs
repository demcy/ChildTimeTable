using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BLL.App.DTO.Identity;
using Contracts.DAL.Base;


namespace BLL.App.DTO
{
    public class Person : Person<Guid>, IDomainBaseEntity
    {
    }

    public class Person<TKey> : IDomainBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        
        public virtual string FirstName { get; set; } = default!;
        public virtual string LastName { get; set; } = default!;
        public virtual string Logo { get; set; } = default!;
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

        public TKey AppUserId { get; set; }
        public AppUser<TKey>? AppUser { get; set; }
        
        public virtual int LocationCount { get; set; }
    }
}