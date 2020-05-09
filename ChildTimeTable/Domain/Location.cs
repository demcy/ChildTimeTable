using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class Location : DomainEntityMetadata

    {
    //public int LocationId { get; set; }
    public string LocationValue { get; set; }

    [MaxLength(36)]
    public string PersonId { get; set; }
    public Person Person { get; set; }

    public ICollection<Obligation> Type { get; set; }
    }
}