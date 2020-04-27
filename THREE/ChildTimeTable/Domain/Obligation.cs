using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Obligation
    {
        public int ObligationId { get; set; }

        public string Body { get; set; }

        public bool Status { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int TimeId { get; set; }
        public Time Time { get; set; }

        public ObligationType ObligationType { get; set; }

        [ForeignKey(nameof(Parent))]
        public int ParentId { get; set; }
        public Person Parent { get; set; }
        
        [ForeignKey(nameof(Child))]
        public int ChildId { get; set; }
        public Person Child { get; set; }
    }
}