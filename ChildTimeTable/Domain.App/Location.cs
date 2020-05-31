using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Base;

namespace Domain.App
{
    public class Location : DomainEntityIdMetadata
    {
        public string LocationValue { get; set; } = default!;
        public Guid PersonId { get; set; } = default!;
        public Person? Person { get; set; }
        public ICollection<Obligation>? Obligations { get; set; }
    }
}