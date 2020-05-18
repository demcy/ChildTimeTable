using System;
using System.Collections.Generic;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Time : Time<Guid>, IDomainEntityBaseMetadata
    {
        
    }
    public class Time<TKey> : DomainEntityBaseMetadata
    {
        public virtual DateTime StartTime { get; set; } = default!;
        public virtual DateTime EndTime { get; set; } = default!;

        public virtual ICollection<Obligation>? Obligations { get; set; } 
    }
}