using System;
using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class Time : DomainEntityMetadata
    {
        //public int TimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<Obligation> Obligations { get; set; } 
    }
}