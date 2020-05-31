using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Base;

namespace  Domain.App
{
    public class Notification : DomainEntityIdMetadata
    {
        public string Body { get; set; } = default!;
        public bool Status { get; set; } = default!;
        
        [ForeignKey(nameof(Sender))]
        public Guid SenderId { get; set; }
        public Person? Sender { get; set; }

        [ForeignKey(nameof(Recipient))]
        public Guid RecipientId { get; set; }
        public Person? Recipient { get; set; }
    }
}