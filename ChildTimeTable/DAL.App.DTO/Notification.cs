using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Notification : Notification<Guid>, IDomainBaseEntity
    {
    }

    public class Notification<TKey> : IDomainBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public virtual string Body { get; set; } = default!;
        public virtual bool Status { get; set; } = default!;

        
        [ForeignKey(nameof(Sender))]
        public virtual TKey SenderId { get; set; }
        public virtual Person? Sender { get; set; }
        
        
        [ForeignKey(nameof(Recipient))]
        public virtual TKey RecipientId { get; set; }
        public virtual Person? Recipient { get; set; }
    }
}