using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Family : Family<Guid>, IDomainBaseEntity
    {
    }

    public class Family<TKey> : IDomainBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public virtual ICollection<Person>? Persons { get; set; }
    }
}