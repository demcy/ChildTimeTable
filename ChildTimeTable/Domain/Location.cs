using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Location : Location<Guid>, IDomainEntityBaseMetadata
    {
        
    }
    public class Location<TKey> : DomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual string LocationValue { get; set; } = default!;
        
        public virtual TKey PersonId { get; set; }
        public virtual Person? Person { get; set; }

        public virtual ICollection<Obligation>? Obligations { get; set; }
    }
}