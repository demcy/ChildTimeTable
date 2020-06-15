using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid FamilyId { get; set; } = default!;
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string? Logo { get; set; } = default!;
        public string? PersonType { get; set; } = default!;
        public int UnreadMessages { get; set; } = default!;
        public int LocationCount { get; set; } = default!;
        public int ParentObligationCount { get; set; } = default!;
        public int ChildObligationCount { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = default!;
        public string? CreatedBy { get; set; } = default!;
        public DateTime ChangedAt { get; set; } = default!;
        public string? ChangedBy { get; set; } = default!;
    }
}