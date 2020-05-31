using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Time : IDomainEntityId
    {
        public Guid Id { get; set; } 
        public DateTime StartTime { get; set; } = default!;
        public DateTime EndTime { get; set; } = default!;
        [JsonIgnore]
        public ICollection<Obligation>? Obligations { get; set; }
    }
}