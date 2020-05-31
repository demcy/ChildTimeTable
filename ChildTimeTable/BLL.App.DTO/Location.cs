using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Location : IDomainEntityId
    {
        public Guid Id { get; set; }
        public string LocationValue { get; set; } = default!;
        public Guid PersonId { get; set; } = default!;
        [JsonIgnore]
        public Person? Person { get; set; }
        [JsonIgnore]
        public ICollection<Obligation>? Obligations { get; set; }
    }
}