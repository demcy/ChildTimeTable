#nullable enable
using System;
using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.Models
{
    public class PersonDataModel
    {
        public IEnumerable<Person>? Persons { get; set; }
        public List<DateTime>? DatesList { get; set; }
        public int UnreadMessages { get; set; } = default!;
    }
}