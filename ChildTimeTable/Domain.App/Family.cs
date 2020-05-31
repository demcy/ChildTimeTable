using System.Collections.Generic;
using Domain.Base;

namespace Domain.App
{
    public class Family : DomainEntityIdMetadata
    {
        public virtual ICollection<Person>? Persons { get; set; }
    }
}