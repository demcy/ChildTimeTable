using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class Person : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
        public AppUser? AppUser { get; set; }

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public Guid FamilyId { get; set; } = default!;
        
        
        
    }
}