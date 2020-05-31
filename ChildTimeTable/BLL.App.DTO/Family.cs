using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Family : IDomainEntityId
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }
        
    }
}