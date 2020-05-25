using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Time : Time<Guid>, IDomainEntityBaseMetadata
    {
        
    }
    public class Time<TKey> : DomainEntityBaseMetadata
    {
        [DataType(DataType.DateTime)]
        public virtual DateTime StartTime { get; set; } = default!;
        [DataType(DataType.DateTime)]
        public virtual DateTime EndTime { get; set; } = default!;

        public virtual ICollection<Obligation>? Obligations { get; set; } 
    }
}