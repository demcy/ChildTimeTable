using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Base;

namespace Domain.App
{
    public class Obligation : DomainEntityIdMetadata
    {
        public string Body { get; set; } = default!;
        public bool Status { get; set; } = default!;
        public Guid LocationId { get; set; } = default!;
        public Location? Location { get; set; }
        public Guid TimeId { get; set; } = default!;
        public Time? Time { get; set; }
        public ObligationType ObligationType { get; set; } = default!;
        
        [ForeignKey(nameof(Parent))]
        public Guid ParentId { get; set; } = default!;
        public Person? Parent { get; set; }
        
        [ForeignKey(nameof(Child))]
        public Guid ChildId { get; set; } = default!;
        public Person? Child { get; set; }
    }
}