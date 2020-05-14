using System;
using System.Collections.Generic;

namespace PublicApi.DTO.v1
{
    public class TimeDTO
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ObligationCount { get; set; }
    }
}