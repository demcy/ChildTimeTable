using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Obligation : IDomainEntityId
    {
        public Guid Id { get; set; }
        public string Body { get; set; } = default!;
        public bool Status { get; set; } = default!;
        
        public Guid LocationId { get; set; } = default!;
        [JsonIgnore]
        public Location? Location { get; set; }
        
        public Guid TimeId { get; set; } = default!;
        [JsonIgnore]
        public Time? Time { get; set; }

        public ObligationType ObligationType { get; set; } = default!;
        
        [ForeignKey(nameof(Parent))]
        public Guid ParentId { get; set; } = default!;
        [JsonIgnore]
        public Person? Parent { get; set; }
        
        [ForeignKey(nameof(Child))]
        public Guid ChildId { get; set; } = default!;
        [JsonIgnore]
        public Person? Child { get; set; }
    }
}