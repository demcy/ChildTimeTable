using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Notification : Notification<Guid>, IDomainEntity
        {
            
        }
    public class Notification<TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
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