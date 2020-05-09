using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;

namespace Domain
{
    public class Notification : DomainEntityMetadata
    {
        //public int NotificationId { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }
        
        [MaxLength(36)]
        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; }
        public Person Sender { get; set; }
        
        [MaxLength(36)]
        [ForeignKey(nameof(Recipient))]
        public string RecipientId { get; set; }
        public Person Recipient { get; set; }
    }
}