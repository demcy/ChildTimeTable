#nullable enable
using System.Collections.Generic;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class PersonModel
    {
        public Person Person { get; set; } = default!;
        public List<string>? LogoList { get; set; }
    }
}