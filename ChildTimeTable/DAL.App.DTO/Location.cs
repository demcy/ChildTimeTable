using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Location : Location<Guid>, IDomainBaseEntity
    {
    }

    public class Location<TKey> : IDomainBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; } = default!;
        public virtual string LocationValue { get; set; } = default!;
        public virtual TKey PersonId { get; set; } = default!;
        public virtual Person? Person { get; set; }

        public virtual ICollection<Obligation>? Obligations { get; set; }
    }
}