using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Base;

namespace Domain.App
{
    public class Time : DomainEntityIdMetadata
    {
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; } = default!;
        
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; } = default!;

        public ICollection<Obligation>? Obligations { get; set; } 
    }
}