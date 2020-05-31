using System;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.DAL.Base;

namespace PublicApi.DTO.v1
{
    public class Notification: IDomainEntityId
    {
        public Guid Id { get; set; }
        public string Body { get; set; } = default!;
        public bool Status { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
    }
}