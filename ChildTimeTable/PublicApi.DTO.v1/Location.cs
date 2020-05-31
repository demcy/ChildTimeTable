using System;
using System.Collections.Generic;
using Contracts.DAL.Base;

namespace PublicApi.DTO.v1
{
    public class Location: IDomainEntityId
    {
        public Guid Id { get; set; }
        public string LocationValue { get; set; } = default!;
        public Guid PersonId { get; set; }
        public int ObligationCount { get; set; }
    }
}