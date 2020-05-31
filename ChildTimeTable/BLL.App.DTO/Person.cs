using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;
using BLL.App.DTO.Identity;



namespace BLL.App.DTO
{
    public class Person : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser? AppUser { get; set; }

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public Guid FamilyId { get; set; } = default!;
        [JsonIgnore]
        public Family? Family { get; set; }
        public PersonType PersonType { get; set; } = default!;
        [InverseProperty(nameof(Notification.Sender))]
        [JsonIgnore]
        public ICollection<Notification>? SenderNotifications { get; set; }
        [InverseProperty(nameof(Notification.Recipient))]
        [JsonIgnore]
        public ICollection<Notification>? RecipientNotifications { get; set; }
        [InverseProperty(nameof(Obligation.Parent))]
        [JsonIgnore]
        public ICollection<Obligation>? ParentObligations { get; set; }
        [InverseProperty(nameof(Obligation.Child))]
        [JsonIgnore]
        public ICollection<Obligation>? ChildObligations { get; set; }
        [JsonIgnore]
        public ICollection<Location>? Locations { get; set; }
        public int UnreadMessages { get; set; } = default!;
    }
    
    


    
    
    
    
}




    
