using System;
using System.Collections.Generic;

namespace PublicApi.DTO.v1
{
    public class LocationDTO
    {
        public Guid Id { get; set; }
        public string LocationValue { get; set; }
        public Guid PersonId { get; set; }
        public int ObligationCount { get; set; }
    }
}