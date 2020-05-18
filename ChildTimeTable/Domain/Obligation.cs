using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Obligation : Obligation<Guid>, IDomainEntityBaseMetadata
    {
            
    }
    public class Obligation<TKey> : DomainEntityBaseMetadata
    {
        public virtual string Body { get; set; } = default!;

        public virtual bool Status { get; set; } = default!;

        
        public virtual TKey LocationId { get; set; } = default!;
        public virtual Location? Location { get; set; }

        
        public virtual TKey TimeId { get; set; } = default!;
        public virtual Time? Time { get; set; }

        public virtual ObligationType ObligationType { get; set; } = default!;

        
        [ForeignKey(nameof(Parent))]
        public virtual TKey ParentId { get; set; } = default!;
        public virtual Person? Parent { get; set; }
        
        
        [ForeignKey(nameof(Child))]
        public virtual TKey ChildId { get; set; } = default!;
        public virtual Person? Child { get; set; }
    }
}