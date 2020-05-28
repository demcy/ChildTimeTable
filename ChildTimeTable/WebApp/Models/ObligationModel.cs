#nullable enable
using System.Collections;
using System.Collections.Generic;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class ObligationModel
    {
        public Obligation Obligation { get; set; } = default!;
        public string Data { get; set; } = default!;
        public SelectList? LocationValues { get; set; }
        public IEnumerable<SelectListItem>? FullNames { get; set; }
        public string StartTime { get; set; } = default!;
        public string EndTime { get; set; } = default!;
        public string LocationValue { get; set; } = default!;
        public int ChildIndex { get; set; } = default!;

    }
}