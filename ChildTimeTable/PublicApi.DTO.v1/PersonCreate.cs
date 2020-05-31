using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicApi.DTO.v1
{
    /*public class Person : PersonEdit
    {
        public int NotificationCount { get; set; }
        public int ObligationCount { get; set; }
        public int LocationCount { get; set; }
    }*/

    public class PersonCreate
    {
        [MinLength(1)] [MaxLength(64)] public string FirstName { get; set; } = default!;
        [MinLength(1)] [MaxLength(64)] public string LastName { get; set; } = default!;
        public Guid FamilyId { get; set; }
        public string Logo { get; set; } = default!;
        public string PersonType { get; set; } = default!;
    }

    /*public class PersonEdit : PersonCreate
    {
        public Guid Id { get; set; }
    }*/


}