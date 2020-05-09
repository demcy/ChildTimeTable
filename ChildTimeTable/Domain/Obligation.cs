using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;

namespace Domain
{
    public class Obligation : DomainEntityMetadata
    {
        //public int ObligationId { get; set; }

        public string Body { get; set; }

        public bool Status { get; set; }

        [MaxLength(36)]
        public string LocationId { get; set; }
        public Location Location { get; set; }

        [MaxLength(36)]
        public string TimeId { get; set; }
        public Time Time { get; set; }

        public ObligationType ObligationType { get; set; }

        [MaxLength(36)]
        [ForeignKey(nameof(Parent))]
        public string ParentId { get; set; }
        public Person Parent { get; set; }
        
        [MaxLength(36)]
        [ForeignKey(nameof(Child))]
        public string ChildId { get; set; }
        public Person Child { get; set; }
    }
}