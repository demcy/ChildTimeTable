using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Time : IDomainEntityId
    {
        public Guid Id { get; set; } 
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; } = default!;
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; } = default!;
        [JsonIgnore]
        public ICollection<Obligation>? Obligations { get; set; }
    }
}