using System;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;

namespace PublicApi.DTO.v1
{
    public class Obligation: IDomainEntityId
    {
        public Guid Id { get; set; }
        public string Body { get; set; } = default!;
        public bool Status { get; set; }
        public Guid LocationId { get; set; }
        public Guid TimeId { get; set; }
        public string ObligationType { get; set; } = default!;
        public Guid ParentId { get; set; }
        public Guid ChildId { get; set; }
    }
}