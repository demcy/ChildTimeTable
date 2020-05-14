using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicApi.DTO.v1
{
    public class ObligationDTO
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }
        public Guid LocationId { get; set; }
        public Guid TimeId { get; set; }
        public string ObligationType { get; set; }
        public Guid ParentId { get; set; }
        public Guid ChildId { get; set; }
    }
}