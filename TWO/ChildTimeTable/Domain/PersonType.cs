using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        
        [MaxLength(64)]
        public string PersonTypeValue { get; set; }
        
        public ICollection<Person> Persons { get; set; }

        //public ICollection<Family> Families { get; set; }
    }
}