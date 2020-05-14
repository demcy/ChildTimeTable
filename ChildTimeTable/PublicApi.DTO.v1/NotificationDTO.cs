using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicApi.DTO.v1
{
    public class NotificationDTO
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
    }
}