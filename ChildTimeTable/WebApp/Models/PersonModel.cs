using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class PersonModel
    {
        public Person Person { get; set; } = default!;

        public SelectList? AppUserIdSelectList { get; set; }
    }
}