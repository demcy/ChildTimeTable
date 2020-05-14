using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicApi.DTO.v1
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MinLength(1)]
        [MaxLength(64)]
        public string LastName { get; set; }
        public string Logo { get; set; }
        public Guid FamilyId { get; set; }
        public string PersonType { get; set; }
        public int NotificationCount { get; set; }
        public int ObligationCount { get; set; }
        public int LocationCount { get; set; }
    }
}