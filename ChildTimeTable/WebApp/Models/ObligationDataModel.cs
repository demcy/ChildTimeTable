#nullable enable
using System;
using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.Models
{
    public class ObligationDataModel
    {
        public IEnumerable<Obligation>? Obligations { get; set; }
        public DateTime Date { get; set; } = default!;
        public string HtmlDate { get; set; } = default!;
        public Boolean Today { get; set; } = default!;
        public Guid PersonId { get; set; } = default!;
    }
}