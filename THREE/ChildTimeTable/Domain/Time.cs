using System;
using System.Collections.Generic;

namespace Domain
{
    public class Time
    {
        public int TimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<Obligation> Obligations { get; set; } 
    }
}