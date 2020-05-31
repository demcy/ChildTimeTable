using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.App.Identity;
using Domain.Base;
//using Domain.App.Identity;

namespace Domain.App
{
    public class Person : DomainEntityIdMetadataUser<AppUser>
    {
        [MinLength(1, ErrorMessageResourceName = "ErrorMessage_MinLength",
            ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(64)]
        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.Person))]
        public string FirstName { get; set; } = default!;
        
        [MinLength(1)] [MaxLength(64)] 
        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.Person))]
        public string LastName { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public Guid FamilyId { get; set; } 
        public Family? Family { get; set; }
        
        [Display(Name = nameof(PersonType), ResourceType = typeof(Resources.Domain.Person))]
        public PersonType PersonType { get; set; } 
        
        [InverseProperty(nameof(Notification.Sender))]
        public ICollection<Notification>? SenderNotifications { get; set; }
        
        [InverseProperty(nameof(Notification.Recipient))]
        public ICollection<Notification>? RecipientNotifications { get; set; }
        
        [InverseProperty(nameof(Obligation.Parent))]
        public ICollection<Obligation>? ParentObligations { get; set; }
        [InverseProperty(nameof(Obligation.Child))]
        public ICollection<Obligation>? ChildObligations { get; set; }
        
        public ICollection<Location>? Locations { get; set; }

        
    }

    
}