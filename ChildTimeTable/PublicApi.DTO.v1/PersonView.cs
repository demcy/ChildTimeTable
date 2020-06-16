using System;

namespace PublicApi.DTO.v1
{
    public class PersonView: Person
    {
        public DateTime CreatedAt { get; set; } = default!;
        public string? CreatedBy { get; set; } = default!;
        public DateTime ChangedAt { get; set; } = default!;
        public string? ChangedBy { get; set; } = default!;
    }
}