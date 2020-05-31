using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace PublicApi.DTO.v1
{
    public class Time: IDomainEntityId
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ObligationCount { get; set; }
    }
}