using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Time : Time<Guid>, IDomainBaseEntity
    {
    }

    public class Time<TKey> : IDomainBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public virtual DateTime StartTime { get; set; } = default!;
        public virtual DateTime EndTime { get; set; } = default!;

        public virtual ICollection<Obligation>? Obligations { get; set; }
    }
}