using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }
        
        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public Person Sender { get; set; }
        
        [ForeignKey(nameof(Recipient))]
        public int RecipientId { get; set; }
        public Person Recipient { get; set; }
    }
}