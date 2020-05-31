using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Notification : IDomainEntityId
    {
        public Guid Id { get; set; } 
        public string Body { get; set; } = default!;
        public bool Status { get; set; } = default!;
        
        [ForeignKey(nameof(Sender))]
        public Guid SenderId { get; set; } = default!;
        [JsonIgnore]
        public Person? Sender { get; set; }
        
        [ForeignKey(nameof(Recipient))]
        public Guid RecipientId { get; set; } = default!;
        [JsonIgnore]
        public Person? Recipient { get; set; }
    }
}