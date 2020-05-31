using System;

namespace BLL.App.DTO
{
    public class PersonDisplay
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public Guid FamilyId { get; set; } = default!;
        public string PersonType { get; set; } = default!;
        public int UnreadMessages { get; set; } = default!;
    }
}