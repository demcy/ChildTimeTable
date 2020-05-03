using System.Collections.Generic;

namespace Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationValue { get; set; }

        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public ICollection<Obligation> Type { get; set; }
    }
}