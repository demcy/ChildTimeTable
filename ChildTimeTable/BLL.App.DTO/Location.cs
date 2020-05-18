using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Location : Location<Guid>, IDomainBaseEntity
    {
    }

    public class Location<TKey> : IDomainBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public virtual string LocationValue { get; set; } = default!;
        
        public virtual TKey PersonId { get; set; }
        public virtual Person? Person { get; set; }

        public virtual ICollection<Obligation>? Obligations { get; set; }
    }
}